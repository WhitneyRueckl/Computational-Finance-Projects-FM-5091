using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Monte_Carlo_Option_Pricer
{
    public class OptionGreeks
    {


        double S = IO.SpotPrice;
        double K = IO.StrikePrice;
        double r = IO.Rate;
        double T = IO.Tenor;
        double vol = IO.Vol;
        double drift = IO.Rate;
        bool put_call = IO.IsPut;

        int steps = IO.N_Steps;
        int trials = IO.Trials;


        Other calc = new Other();

        
        public (double delta, double gamma) calcDeltaGamma(Underlying under, Option option)
        {


            PriceCalculator pricer = new PriceCalculator();

            double[,] Sup_paths = Simulator.simPaths_Sup;
            double[,] S_paths = Simulator.simPaths;
            double[,] Sdown_paths = Simulator.simPaths_Sdown;


            // Delta needs paths for S+, S- (S = SpotPrice of underlying)

            double[] C1_arr, C2_arr, C3_arr, negC1_arr, negC2_arr, negC3_arr;
            double C1 = 0; 
            double C2 = 0; 
            double C3 = 0;
            double delta_s = under.SpotPrice * 0.001;

            C1_arr = pricer.calcOptionPrices(under, Simulator.simPaths_Sup, option, steps, trials);
            C2_arr = pricer.calcOptionPrices(under, Simulator.simPaths, option, steps, trials);
            C3_arr = pricer.calcOptionPrices(under, Simulator.simPaths_Sdown, option, steps, trials);


            if (IO.Var_Reduc == true)
            {

                negC1_arr = pricer.calcOptionPrices(under, Simulator.neg_simPaths_Sup, option, steps, trials);
                negC2_arr = pricer.calcOptionPrices(under, Simulator.neg_simPaths, option, steps, trials);
                negC3_arr = pricer.calcOptionPrices(under, Simulator.neg_simPaths_Sdown, option, steps, trials);
           

                C1 = 0.5 * (calc.calcAverage(C1_arr, trials) + calc.calcAverage(negC1_arr, trials));
                C2 = 0.5 * (calc.calcAverage(C2_arr, trials) + calc.calcAverage(negC2_arr, trials));
                C3 = 0.5 * (calc.calcAverage(C3_arr, trials) + calc.calcAverage(negC3_arr, trials));


            }
            else if (IO.Var_Reduc == false)
            {
 
                C1 = calc.calcAverage(C1_arr, trials);
                C2 = calc.calcAverage(C2_arr, trials);
                C3 = calc.calcAverage(C3_arr, trials);

            }


          // Console.WriteLine("Updated gamma output:  ");
           // Console.WriteLine("C1 = " + C1 + "  C2 =  " + C2 + " C3 = " + C3 + "  delta_s =  " + delta_s + "  delta sq = " + Math.Pow(delta_s, 2));

            double delta = (C1 - C3) / (2 * delta_s);

            double gamma = (C1 - 2 * C2 + C3) / Math.Pow(delta_s, 2);


            return (delta, gamma);


        }


        public double calcVega(Underlying under, Option option)
        {


            PriceCalculator pricer = new PriceCalculator();
          

            double[] C1_arr, C2_arr, negC1_arr, negC2_arr;
            double C1 = 0;
            double C2 = 0;
            double delta_vol = under.Vol * 0.001;

            C1_arr = pricer.calcOptionPrices(under, Simulator.simPaths_Volup, option, steps, trials);
            C2_arr = pricer.calcOptionPrices(under, Simulator.simPaths_Voldown, option, steps, trials);

            if (IO.Var_Reduc == true)
            {

                negC1_arr = pricer.calcOptionPrices(under, Simulator.neg_simPaths_Volup, option, steps, trials);
                negC2_arr = pricer.calcOptionPrices(under, Simulator.neg_simPaths_Voldown, option, steps, trials);

                //Console.WriteLine(" New delta calc, negative paths up:  " + Simulator.neg_simPaths_Sup[1, 1]);
                //Console.WriteLine(" New delta calc, negative C1_arr and C2_arr:  " + negC1_arr[2] + ",  " + negC2_arr[2]);

                C1 = 0.5 * (calc.calcAverage(C1_arr, trials) + calc.calcAverage(negC1_arr, trials));
                C2 = 0.5 * (calc.calcAverage(C2_arr, trials) + calc.calcAverage(negC2_arr, trials));


            }
            else if (IO.Var_Reduc == false)
            {

                C1 = calc.calcAverage(C1_arr, trials);
                C2 = calc.calcAverage(C2_arr, trials);
          

            }

                double vega = (C1 - C2) / (2 * delta_vol);

                return vega;

        }


        public double calcRho(Underlying under, Option option)
        {


            PriceCalculator pricer = new PriceCalculator();
            Underlying copy_under = new Underlying();


            double[] C1_arr, C2_arr, negC1_arr, negC2_arr;
            double C1 = 0;
            double C2 = 0;
            double delta_r = under.Rate * 0.001;
          

            if (IO.Var_Reduc == true)
            {

                // need copy of underlying here fopr the discount factor in calculating the option price
                copy_under.Rate = under.Rate + delta_r;
                C1_arr = pricer.calcOptionPrices(copy_under, Simulator.simPaths_Rup, option, steps, trials);
                negC1_arr = pricer.calcOptionPrices(copy_under, Simulator.neg_simPaths_Rup, option, steps, trials);


                copy_under.Rate = under.Rate - delta_r;
                C2_arr = pricer.calcOptionPrices(copy_under, Simulator.simPaths_Rdown, option, steps, trials);
                negC2_arr = pricer.calcOptionPrices(copy_under, Simulator.neg_simPaths_Rdown, option, steps, trials);

                //Console.WriteLine(" New delta calc, negative paths up:  " + Simulator.neg_simPaths_Sup[1, 1]);
                //Console.WriteLine(" New delta calc, negative C1_arr and C2_arr:  " + negC1_arr[2] + ",  " + negC2_arr[2]);

                C1 = 0.5 * (calc.calcAverage(C1_arr, trials) + calc.calcAverage(negC1_arr, trials));
                C2 = 0.5 * (calc.calcAverage(C2_arr, trials) + calc.calcAverage(negC2_arr, trials));


            }
            else if (IO.Var_Reduc == false)
            {

                copy_under.Rate = under.Rate + delta_r;
                C1_arr = pricer.calcOptionPrices(copy_under, Simulator.simPaths_Rup, option, steps, trials);

                copy_under.Rate = under.Rate - delta_r;
                C2_arr = pricer.calcOptionPrices(copy_under, Simulator.simPaths_Rdown, option, steps, trials);

                C1 = calc.calcAverage(C1_arr, trials);
                C2 = calc.calcAverage(C2_arr, trials);


            }

            double rho = (C1 - C2) / (2 * delta_r);

            return rho;

        }



        public double calcTheta(Underlying under, Option option)
        {


            PriceCalculator pricer = new PriceCalculator();
            Option copy_opt = new Option();


            double[] C1_arr, C2_arr, negC1_arr, negC2_arr;
            double C1 = 0;
            double C2 = 0;
            double delta_t = (0.001);


            Console.WriteLine(" New theta, option Tenor is :  " + copy_opt.Tenor);

            if (IO.Var_Reduc == true)
            {


                C1_arr = pricer.calcOptionPrices(under, Simulator.simPaths, option, steps, trials);
                negC1_arr = pricer.calcOptionPrices(under, Simulator.neg_simPaths, option, steps, trials);

                copy_opt.Tenor = option.Tenor + delta_t;
                C2_arr = pricer.calcOptionPrices(under, Simulator.simPaths_Tup, copy_opt, steps, trials);
                negC2_arr = pricer.calcOptionPrices(under, Simulator.neg_simPaths_Tup, copy_opt, steps, trials);


                C1 = 0.5 * (calc.calcAverage(C1_arr, trials) + calc.calcAverage(negC1_arr, trials));
                C2 = 0.5 * (calc.calcAverage(C2_arr, trials) + calc.calcAverage(negC2_arr, trials));


            }
            else if (IO.Var_Reduc == false)
            {

                C1_arr = pricer.calcOptionPrices(under, Simulator.simPaths, option, steps, trials);

                copy_opt.Tenor = option.Tenor + delta_t;
                C2_arr = pricer.calcOptionPrices(under, Simulator.simPaths_Tup, copy_opt, steps, trials);


                C1 = calc.calcAverage(C1_arr, trials);
                C2 = calc.calcAverage(C2_arr, trials);


            }

            double theta = (C2 - C1) / (delta_t);

            return theta;


        }


    }
}
