using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace Monte_Carlo_Option_Pricer
{
    public class Lookback: Option
    {
        Other calc = new Other();


        public double calcPayoff(double[,] paths, double K, bool isput, int trial_cnt)
        {
            // Lookback (fixed) payoff: C = Max((max(S_t), K), P = Max((K, max(S_t))
            // note need 'using System.Linq;' to access the Max and Min methods for arrays


            int steps = IO.N_Steps;
            double[] prices = new double[IO.N_Steps + 1];
            double payoff = 0;



            // Hold trial count steady while get array of prices at each step in that trials.
            // Trials count is fixed to the value of the counter in the for loop in the pricer calcOPtionPrice()
            // method in the PriceCalculator class. trial_cnt is passed the value of j in that loop.
            for (int i = 0; i <= steps; i++)
            {

                prices[i] = paths[trial_cnt, i];

                // Console.WriteLine("prices in price array at step " + i + "price =  " + prices[i]);

            }
            
            
            if (isput == false)
            {   
                // Call payoff = Max(0, (max_S - K))
                double S = prices.Max();
                payoff = Math.Max(0, S - K);
            }

            else if (isput == true)
            {   
                // Put payoff = Max(0, (K = min_S))
                double S = prices.Min();
                payoff = Math.Max(0, K - S);
            }

            return payoff;


        }




    }
}
