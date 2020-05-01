using System;
using System.Collections.Generic;
using System.Text;

namespace Monte_Carlo_Rebuild
{
    public class Digital: Option
    {

        // Lambda expression for calculatin g balck scholes D2:
        Func<double, double, double, double, double, double, double> black_scholes_d2 = (S, K, r, vol, T, t) =>
            (Math.Log(S / K) + (r - 0.5 * Math.Pow(vol, 2)) * (T - t)) / (vol * Math.Sqrt(T - t));

        Other calc = new Other();

        public double calcPayoff(Underlying under, double K, double T,  bool isput)
        {
            // may want to add n_steps back in if want to see payoff at differente steps

            double S = under.SpotPrice;
            double r = under.Rate;
            double vol = under.Vol;

            double t = T / IO.N_Steps;
           

            double d2 = black_scholes_d2(S, K, r, vol, T, t);
        

            double payoff = 0;
            bool put_call_switch = isput;

            // call = 0, put = 1
            if (put_call_switch == false)
            {
                payoff = Math.Pow(Math.E, (-r * T)) * calc.NormDistCDF(-d2);
            }

            else if (put_call_switch == true)
            {
                
                payoff = Math.Pow(Math.E, (-r * T)) * calc.NormDistCDF(d2);

            }

            return payoff;


        }


    }
}
