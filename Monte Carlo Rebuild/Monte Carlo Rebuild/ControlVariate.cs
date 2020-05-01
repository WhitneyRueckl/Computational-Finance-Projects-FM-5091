using System;
using System.Collections.Generic;
using System.Text;

namespace Monte_Carlo_Rebuild
{
    public class ControlVariate
    {

        PriceCalculator pricer = new PriceCalculator();
        Underlying under = new Underlying();
        Other calc = new Other();


        // Lambda expression for calculatin g balck scholes D1:
        //Func<double, double, double, double, double, double, double> black_scholes_d1 = (S, K, r, vol, T, t) =>
        //  (Math.Log(S / K)) + (r + 0.5 * Math.Pow(vol, 2) * (T - t) / (vol * Math.Sqrt(T - t)));

        // Lambda expression for calculatin g balck scholes D1:
        Func<double, double, double, double, double, double, double> black_scholes_d1 = (S, K, r, vol, T, t) =>
            (Math.Log(S / K) + (r + 0.5 * Math.Pow(vol, 2)) * (T - t)) / (vol * Math.Sqrt(T - t));



        public (double cv, double beta) calcControlVariate(Underlying under, Option option, double[,] asset_prices, int trials, int steps)
        {



            double[] opt_price_arr = new double[trials + 1];
            double cv = 0;
            double beta = -1;
            double d1 = 0, bs_delta = 0;

            //Assign shorter variable names for option properties needed
            double S = under.SpotPrice;
            double vol = under.Vol;
            double r = under.Rate;
            double K = option.Strike;
            double T = option.Tenor;
            bool put_call = option.IsPut;


            for (int i = 0; i < trials; i++)
            {

                double delta_t = T / steps;

                //double St = assetPrices[i, 0];
                cv = 0;

                for (int j = 1; j < steps + 1; j++)
                {
                    //St_n = assetPrices[i, j + 1];
                    double t = (j - 1) * delta_t;

                    if (put_call == false)
                    {
                        d1 = black_scholes_d1(asset_prices[i, j - 1], K, r, vol, T, t);
                        bs_delta = calc.NormDistCDF(d1);

                    }
                    else if (put_call == true)
                    {

                        d1 = black_scholes_d1(asset_prices[i, j - 1], K, r, vol, T, t);
                        bs_delta = calc.NormDistCDF(d1) - 1;

                    }


                    cv += bs_delta * (asset_prices[i, j] - asset_prices[i, j - 1] * Math.Exp(-r * (delta_t)));

                }

                //double adj_opt_price = pricer.calcOptionPrices(asset_prices[i, steps], K, r, T, steps, put_call, beta1, cv);
            }

            return (cv, beta);

        }
    }

}
