using System;
using System.Collections.Generic;
using System.Text;

namespace Monte_Carlo_Option_Pricer
{
    public class Barrier : Option
    {

        public string BarrierType{get; set;}
        public double BarrierPrice { get; set; }
        
        public Barrier()
        {
            BarrierType = IO.BarrierType;
            BarrierPrice = IO.BarrierPrice;

        }

        public double calcPayoff(double[,] paths, double K, bool isput, int trial_cnt)
        {
            // Range payoff: C = (max(S_t) - min(S_t))  ---> the full range of the underlying over the tenor in that trial
            // note need 'using System.Linq;' to access the Max and Min methods for arrays

            int steps = IO.N_Steps;
            double[] prices = new double[IO.N_Steps + 1];
            double payoff = 0;
            double B = this.BarrierPrice;
            int knock = 0;

            double S = paths[trial_cnt, steps];


            // Hold trial count steady while get array of prices at each step in that trials
            // Trials count is fixed to the value of the counter in the for loop in the pricer calcOPtionPrice()
            // method in the PriceCalculator class. trial_cnt is passed the value of j in that loop.
            for (int i = 0; i <= steps; i++)
            {

                prices[i] = paths[trial_cnt, i];


                if (isput == false)
                {

                    if (BarrierType == "Down-Out" & prices[i] <= B)
                    {
                        knock = 0;
                    }
                    else if (BarrierType == "Up-Out" & prices[i] >= B)
                    {
                        knock = 0;
                    }
                    else if (BarrierType == "Down-In" & prices[i] <= B)
                    {
                        knock = 1;
                    }
                    else if (BarrierType == "Up-In" & prices[i] >= B)
                    {
                        knock = 1;

                    }


                    payoff = Math.Max(0, S - K) * knock;


                }

                if (isput == true)
                {


                    if (BarrierType == "Down-Out" & prices[i] <= B)
                    {
                        knock = 1;
                    }
                    else if (BarrierType == "Up-Out" & prices[i] >= B)
                    {
                        knock = 1;
                    }
                    else if (BarrierType == "Down-In" & prices[i] <= B)
                    {
                        knock = 0;
                    }
                    else if (BarrierType == "Up-In" & prices[i] >= B)
                    {
                        knock = 0;

                    }

                    payoff = Math.Max(0, K - S) * knock;

                }          

            }


            return payoff;


        }


    }
}
