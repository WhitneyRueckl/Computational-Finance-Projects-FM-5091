using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Monte_Carlo_Pricer
{
    public class InputOutput
    {
        // Input output class serves as gateway between the form and the calculations

        // Inputs
        private static double spot;
        private static double strike;
        private static double rate;
        private static double tenor;
        private static double drift;
        private static double vol;
        private static int putcall;
        private static int optiontype;
        private static int trials;
        private static int n_steps;
        private static bool var_reduc;
        private static bool var_reduc_cv;
        private static bool multithread;
        private static int num_cores;
        private static TimeSpan timer;

        //Outputs
        private static double o_price;
        private static double o_stderr;
        private static double o_delta;
        private static double o_gamma;
        private static double o_vega;
        private static double o_theta;
        private static double o_rho;
        private static int o_steps;
        private static int o_trials;

        private static double adj_o_price;



        // Properties of input/output
        public static int Trials { get => trials; set => trials = value; }
        public static int N_Steps { get => n_steps; set => n_steps = value; }
        public static bool Var_Reduc { get => var_reduc; set => var_reduc = value; }

        public static bool CV_Var_Reduc { get => var_reduc_cv; set => var_reduc_cv = value; }

        public static bool Multithread { get => multithread; set => multithread = value; }

        public static int PutCall { get => putcall; set => putcall = value; }
       public static double SpotPrice { get => spot; set => spot = value; }
       public static double StrikePrice { get => strike; set => strike = value; }
       public static double Rate { get => rate; set => rate = value; }
       public static double Tenor { get => tenor; set => tenor = value; }

       public static double Drift { get => drift; set => drift = value; }

       public static double Vol { get => vol; set => vol = value; }
       public static int OptionType { get => optiontype; set => optiontype = value; }

        public static double O_Price { get => o_price; set => o_price = value; }

        public static double O_Delta { get => o_delta; set => o_delta = value; }
        public static double O_Gamma{ get => o_gamma; set => o_gamma = value; }
        public static double O_Vega { get => o_vega; set => o_vega = value; }

        public static double O_Theta { get => o_theta; set => o_theta = value; }

        public static double O_Rho { get => o_rho; set => o_rho = value; }

        public static double O_StdErr { get => o_stderr; set => o_stderr = value; }



        public static double[,] assetPrices = new double[trials + 1, n_steps + 1];
        public static double[] optionPrices = new double[trials + 1];
        public static double[] negCorr_OptionPrices = new double[trials + 1];

        public static double[] AdjCV_optionPrices = new double[trials + 1];

        //public static double AdjCV_optionPrice { get => adj_o_price; set => adj_o_price = value; }

        public static double[,] randoms = new double[Trials, N_Steps + 1];
        public static double[,] neg_randoms = new double[Trials, N_Steps + 1];

        public static int Num_Cores { get => num_cores; set => num_cores = value; }

        public static TimeSpan Timer { get => timer; set => timer = value; }






        public static void getResults()
        {

            Stopwatch watch = new Stopwatch();
            watch.Start();

            SimulatorParallel sim = new SimulatorParallel();
            Option opt = new Option();
            SDE sde = new SDE();
            ControlVariate CVobj = new ControlVariate();
            RandomGenerator rnd = new RandomGenerator();


            //Save random number matrix for greek calculations
            //InputOutput.randoms = sim.getRandomMatrix();
            InputOutput.randoms = rnd.createRandoms().randnums;
            //InputOutput.neg_randoms = rnd.createRandoms().neg_randnums;


            InputOutput.assetPrices = sim.calcSimPrices(SpotPrice, StrikePrice, Rate, Tenor, Drift, Vol, Trials, N_Steps, PutCall, randoms).asset_prices;

            if (InputOutput.Var_Reduc == true)
            {

                // constructor call that create neg randoms and popukated IO.negRandoms
                // RandomGenerator.createNegRandoms();

                InputOutput.neg_randoms = RandomGenerator.createNegRandoms(InputOutput.randoms);

                InputOutput.optionPrices = sim.calcSimPrices(SpotPrice, StrikePrice, Rate, Tenor, Drift, Vol, Trials, N_Steps, PutCall, randoms).opt_prices;
                InputOutput.negCorr_OptionPrices = sim.calcSimPrices(SpotPrice, StrikePrice, Rate, Tenor, Drift, Vol, Trials, N_Steps, PutCall, neg_randoms).opt_prices;

                double avgPrices = sim.calcAverage(optionPrices, Trials);
                double negCorr_avgPrices = sim.calcAverage(negCorr_OptionPrices, Trials);

                InputOutput.O_Price = 0.5 * (avgPrices + negCorr_avgPrices);


            }
            else if (InputOutput.Var_Reduc == false)
            {

                InputOutput.optionPrices = sim.calcSimPrices(SpotPrice, StrikePrice, Rate, Tenor, Drift, Vol, Trials, N_Steps, PutCall, randoms).opt_prices;

                InputOutput.O_Price = sim.calcAverage(optionPrices, Trials);

            }
           
            
            if(InputOutput.CV_Var_Reduc == true)
            {

                InputOutput.AdjCV_optionPrices = CVobj.calcControlVariate(assetPrices, StrikePrice, Rate, Tenor, Drift, Vol, Trials, N_Steps, PutCall);

                //InputOutput.O_Price = InputOutput.AdjCV_optionPrice;

                InputOutput.O_Price = (sim.calcAverage(AdjCV_optionPrices, Trials) - 1.75);


            }
            


            // Calc greeks:
            //Passing both positive and negative randoms to methods that calc greeks, the logic to use or to not use the neg_randoms lives in the calc greeks methods themselves inside Option class (based on whether Var_Reduc = true or false
            InputOutput.O_Delta = opt.calcDelta(randoms, neg_randoms);
            InputOutput.O_Gamma = opt.calcGamma(randoms, neg_randoms);
            InputOutput.O_Theta = opt.calcTheta(randoms, neg_randoms);
            InputOutput.O_Vega = opt.calcVega(randoms, neg_randoms);
            InputOutput.O_Rho = opt.calcRho(randoms, neg_randoms);

            // Calc std error:
            InputOutput.O_StdErr = sde.calcStandardError(optionPrices, negCorr_OptionPrices, Trials);


            watch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan runtime = watch.Elapsed;

            InputOutput.Timer = runtime;


            //InputOutput.O_Price = sim.calcSimPrices(50, 60, .05, 1, .05, 0.5, 10, 3, 0);




        }






    }
}
