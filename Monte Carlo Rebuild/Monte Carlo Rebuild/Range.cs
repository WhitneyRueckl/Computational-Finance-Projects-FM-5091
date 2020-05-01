using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Monte_Carlo_Rebuild
{
    public class Range: Option
    {


        public double calcPayoff(double[,] paths, double K, bool isput, int trial_cnt)
        {
            // Range payoff: C = (max(S_t) - min(S_t))  ---> the full range of the underlying over the tenor in that trial
            // note need 'using System.Linq;' to access the Max and Min methods for arrays

            int steps = IO.N_Steps;
            double[] prices = new double[IO.N_Steps + 1];


            // Hold trial count steady while get array of prices at each step in that trials
            // Trials count is fixed to the value of the counter in the for loop in the pricer calcOPtionPrice()
            // method in the PriceCalculator class. trial_cnt is passed the value of j in that loop.
            for (int i = 0; i <= steps; i++)
            {

                prices[i] = paths[trial_cnt, i];

                // Console.WriteLine("prices in price array at step " + i + "price =  " + prices[i]);

            }

 
            // Range does not have a traditional put and call  
            double payoff = Math.Max(0,  (prices.Max() - prices.Min()));            

            return payoff;


        }


    }
}
