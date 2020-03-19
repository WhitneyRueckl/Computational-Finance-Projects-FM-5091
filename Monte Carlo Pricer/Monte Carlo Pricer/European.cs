using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo_Pricer
{
   
    public class European : Option
    {

            /// <summary Calculate the price of the option. Uses calcPayoff method.>
            /// </summary>
            /// <param name="avgSimPrices"></param>
            /// <param name="K"></param>
            /// <param name="r"></param>
            /// <param name="delta_t"></param>
            /// <param name="n_steps"></param>
            /// <param name="put_call"></param>
            /// <returns The price of a call or put option></returns>
            /// 


            public double calcOptionPrice(double avgSimPrices, double K, double r, double T, int n_steps, int put_call)
            {
                    //not average prices - fix name later
                double payoff = calcPayoff(avgSimPrices, K, put_call);

                double discfactor = Math.Pow(Math.E, -r * T);
                //double discfactor = calcDiscountFactor(r, T);
                double option_px = payoff * discfactor;

                return option_px;

            }


        //Overloaded calcOptionPrice method for control variate varianc reduction
        public double calcOptionPrice(double avgSimPrices, double K, double r, double T, int n_steps, int put_call, double beta, double cv)
        {
            //not average prices - fix name later
            double payoff = calcPayoff(avgSimPrices, K, put_call) + beta * cv;

            double discfactor = Math.Pow(Math.E, -r * T);
            //double discfactor = calcDiscountFactor(r, T);
            double option_px = payoff * discfactor;

            return option_px;

        }







        public double calcPayoff(double avgSimPrices, double K, int put_call)
            {
                // may want to add n_steps back in if want to see payoff at differente steps
                //double[,] payoff = new double[2 * n_steps + 1, n_steps + 1];

                double payoff = 0;
                double put_call_switch = put_call;


                // call = 0, put = 1
                if (put_call_switch == 0)
                {
                    payoff = Math.Max(0, avgSimPrices - K);
                }

                else if (put_call_switch == 1)
                {
                    payoff = Math.Max(0, K - avgSimPrices);
                }

                return payoff;


            }

      
        public double calcDiscountFactor(double r, double t)
            {
                double delta_t = t;

                double disc = Math.Pow(Math.E, -r * delta_t);

                return disc;

            }





        

     }
}
