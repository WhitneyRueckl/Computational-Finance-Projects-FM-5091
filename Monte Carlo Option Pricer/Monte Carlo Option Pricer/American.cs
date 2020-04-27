using System;
using System.Collections.Generic;
using System.Text;

namespace Monte_Carlo_Option_Pricer
{
    public class American: Option
    {


        public double calcPayoff(double S, double K, bool isput)
        {
            // may want to add n_steps back in if want to see payoff at different steps

            double payoff = 0;
            bool put_call_switch = isput;

            // call = 0, put = 1
            if (put_call_switch == false)
            {
                payoff = Math.Max(0, S - K);
            }

            else if (put_call_switch == true)
            {
                payoff = Math.Max(0, K - S);
            }

            return 10*payoff;


        }





    }
}
