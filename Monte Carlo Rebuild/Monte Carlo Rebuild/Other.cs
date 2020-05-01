using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Monte_Carlo_Rebuild
{
    public class Other
    {

        // ------ Methods for calculating average price and standard error ------

        public double calcAverage(double[] valueArray, double trials)
        {
            double sum = 0;

            for (int i = 0; i <= trials; i++)
            {
                sum += valueArray[i];
            }

            double avg = Convert.ToDouble(sum / trials);


            return avg;

        }




        public double calcStandardError(double[] prices, int trials)
        {

            double std_err_result;
            double sum_prices = 0;
            double sum_dev = 0;
            double avg_prices = 0;
            double avg_dev = 0;

            // sum of simulated prices
            for (long i = 0; i < trials; i++)
            {
                sum_prices += prices[i];

            }

            avg_prices = sum_prices / trials;

            // calc std deviation
            for (long i = 0; i < trials; i++)
            {
                sum_dev += Math.Pow((prices[i] - avg_prices), 2);

            }

            // calc average deviation
            avg_dev = Math.Sqrt(sum_dev / (trials - 1));

            std_err_result = avg_dev / (2 * Math.Sqrt(trials));

            return std_err_result;


        }



        // ------ Methods for calculating Normal Distribution CDF ------


        // Lambda expression for calculatin g balck scholes D1:
        Func<double, double, double, double, double, double, double> black_scholes_d1 = (S, K, r, vol, T, t) =>
            (Math.Log(S / K) + (r + 0.5 * Math.Pow(vol, 2)) * (T - t)) / (vol * Math.Sqrt(T - t));


        public double NormDistCDF(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of d1
            int sign = 1;
            if (x < 0)
                sign = -1;

            x = Math.Abs(x) / Math.Sqrt(2.0);

            // 
            double t = 1.0 / (1.0 + p * x);
            double erf = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            double output = 0.5 * (1.0 + sign * erf);
            //double a = 5.2;

            return output;


        }




    }
}
