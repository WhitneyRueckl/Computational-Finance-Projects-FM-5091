using System;
using System.Collections.Generic;
using System.Text;

namespace Monte_Carlo_Option_Pricer
{
    class SDE
    {
        //Geomertic Brownian Motion solution to SDE:
        public static double GBM(double delta_t, double drift, double vol, double randnum)
        {

            double nextPriceMultiplier = Math.Exp((drift - Math.Pow(vol, 2) / 2) * delta_t + vol * Math.Sqrt(delta_t)* randnum);

            return nextPriceMultiplier;

        }

    }
}
