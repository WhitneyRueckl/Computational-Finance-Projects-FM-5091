using System;
using System.Collections.Generic;
using System.Text;

namespace Monte_Carlo_Option_Pricer
{
    class NormalDist
    {


        Func<double, double, double, double, double, double> black_scholes_d1 = (S, K, r, vol, T) => (Math.Log(S / K)) + (r + 0.5 * Math.Pow(vol, 2) * T / (vol * Math.Sqrt(T)));




        public (double output, double a) NormDistCDF(double x)
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
            double a = 5.2;

            return (output, a);


        }



        public void test()
        {


            int a, b, c, x, y, z;
            bool choice;

            a = 5;
            b = 15;
            choice = false;

            //Console.WriteLine("Enter True or False for tester:");
            //choice = Convert.ToBoolean(Console.ReadLine());

            // x = 20
             x = a + b;

            if(choice == true)
            {
                y = x * 2;
                z = 100;

                // should get 40 as putput
                Console.WriteLine("TESTING OUTPUT ----> " + (y + x));

            }
            else
            {
                y = (x + 4)/2;
                z = 2;

                //should get 12 as output
                Console.WriteLine("TESTING OUTPUT ----> " + y);

            }


            double avg = (x + y + z) / 2;
            Console.WriteLine("TESTING OUTPUT ----> " + avg);

        }
    }


    
}
