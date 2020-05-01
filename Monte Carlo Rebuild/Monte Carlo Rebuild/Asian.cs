using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Monte_Carlo_Rebuild
{
    public class Asian: Option
    {

        Other calc = new Other();

        public double calcPayoff(double[,] paths, double K, bool isput, int trial_cnt)
        {
            // ===> Asian option payoff:  C = Max(0, (S_avg - K)) and P =  Math.Max(0, (K - S_avg))


            int steps = IO.N_Steps;
            double[] prices = new double[IO.N_Steps + 1];
            double sum = 0;

            // trials count is fixed to the value of the counter in the for loop in the pricer calcOPtionPrice()
            // method in the PriceCalculator class. trial_cnt is passed the value of j in that loop.
            for(int i = 0; i <= steps; i++)
            {

                prices[i] = paths[trial_cnt, i];
                sum += prices[i];

               // Console.WriteLine("prices in price array at step " + i + "price =  " + prices[i]);

            }

             //double S = calc.calcAverage(prices, steps);
            double S = Convert.ToDouble(sum / (steps + 1));

            //Console.WriteLine(" Average price calc on Asian   " + S);

            double payoff = 0;

            // call = 0, put = 1
            if (isput == false)
            {
                payoff = Math.Max(0, (S - K));  //Math.Max(0, Math.Abs(S - K))
            }

            else if (isput == true)
            {
                payoff = Math.Max(0, (K - S));
            }


            return payoff;


        }




        // Created an option price calculator for asian inside asian class for testing only
        public double[] calcOptionPrices(Underlying under, double[,] pricePaths, double K, double T, int steps, int trials, bool isput)
        {
            // Asian option payoff takes the max of the absolute difference between the average stock price and the strike

            //int steps = IO.N_Steps;
            double[] optionPrices = new double[IO.Trials + 1];
            
            double[] assetPrices = new double[IO.N_Steps + 1];

            double r = under.Rate;

            double discfactor = Math.Pow(Math.E, -r * T);

            for (int j = 0; j <= trials; j++)
            {
                double sum = 0;

                for (int i = 0; i <= steps; i++)
                {

                    assetPrices[i] = pricePaths[j, i];
                    sum += assetPrices[i];

                    Console.WriteLine("prices in price array at step " + i + "  price =  " + assetPrices[i]);

                }


                double S = Convert.ToDouble(sum / (steps + 1));

                Console.WriteLine("Average of prices in price array at in trial " + j + ",  price =  " + S);

                double payoff = 0;
                bool put_call_switch = isput;

                // call = 0, put = 1
                if (put_call_switch == false)
                {
                    payoff = Math.Max(0, (S - K));  //Math.Max(0, Math.Abs(S - K))
                }

                else if (put_call_switch == true)
                {
                    payoff = Math.Max(0, (K - S));
                }

                optionPrices[j] = payoff * discfactor;


            }

            

            //double S = calc.calcAverage(prices, steps);
         

            //Console.WriteLine(" Average price calc on Asian   " + S);

           


            return optionPrices;


        }




    }
}
