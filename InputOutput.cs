using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private static int var_reduc;


        // Properties of input/output
       public static int Trials { get => trials; set => trials = value; }
       public static int N_Steps { get => n_steps; set => n_steps = value; }
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


        public static double[] optionPrices = new double[trials + 1];
        public static double[,] randoms = new double[Trials, N_Steps + 1];




        public static void getResults()
        {

            Simulator sim = new Simulator();
            Option opt = new Option();
            SDE sde = new SDE();
           

            //Save random number matrix for greek calculations
            InputOutput.randoms = sim.getRandomMatrix();

            InputOutput.optionPrices = sim.calcSimPrices(SpotPrice, StrikePrice, Rate, Tenor, Drift, Vol, Trials, N_Steps, PutCall, randoms);

            InputOutput.O_Price = sim.calcAverage(optionPrices, Trials);

            InputOutput.O_Delta = opt.calcDelta(randoms);
            InputOutput.O_Gamma = opt.calcGamma(randoms);
            InputOutput.O_Theta = opt.calcTheta(randoms);
            InputOutput.O_Vega = opt.calcVega(randoms);
            InputOutput.O_Rho = opt.calcRho(randoms);
            InputOutput.O_StdErr = sde.calcStandardError(optionPrices, Trials);



            //InputOutput.O_Price = sim.calcSimPrices(50, 60, .05, 1, .05, 0.5, 10, 3, 0);




        }






    }
}
