using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinomial_Tree_Pricing_Model
{
    class SDE
    {


        public double calcProbabilityUp(double r, double t, double q, double n, double sigma, double x, double v)
        {

            double p, delta_t, delta_x;
            delta_t = t;
            delta_x = x;


            //v = calcV(r, q, sigma);

            //double a = (Math.Pow(sigma, 2) * delta_t + Math.Pow(v, 2) * Math.Pow(delta_t, 2)) / (Math.Pow(delta_x, 2));
           // double b = (v * delta_t) / delta_x;

            p = 0.5 * ((Math.Pow(sigma, 2) * delta_t + Math.Pow(v, 2) * Math.Pow(delta_t, 2)) / (Math.Pow(delta_x, 2)) - (v * delta_t)/delta_x) ;

            //p = 0.5 * (a + b);

            return p;


        }

        public double calcProbabilityDown(double r, double t, double q, double n, double sigma, double x, double v)
        {

            double p, delta_t, delta_x;
            delta_t = t;
            delta_x = x;


            //v = calcV(r, q, sigma);


            p = 0.5 * ((Math.Pow(sigma, 2) * delta_t + Math.Pow(v, 2) * Math.Pow(delta_t, 2)) / (Math.Pow(delta_x, 2)) + (v * delta_t) / delta_x);


            return p;


        }


        private double calcV(double r, double q, double sigma)
        {

            double v = r - q - 0.5 * sigma;

            return v;

        }

        public double calcUpTick(double sigma, double t, double x, double n)
        {

            // calulate edx:

            double delta_t, delta_x;
            delta_t = t;
            delta_x = x;


            double edx  = Math.Pow(Math.E, delta_x);

            return edx;


        }

        public double calcDownTick(double sigma, double t, double x, double n)
        {
            // calulate down tick ---> 1/edx:

            double delta_t, delta_x;
            delta_t = t;
            delta_x = x;


            double recip_edx = 1/(Math.Pow(Math.E, delta_x));


            return recip_edx;


        }



        
        public double calcDiscountFactor(double r, double t)
        {
            double d = Math.Exp(-1.0 * r * t);

            return d;

        }




        /*
           public double calcProbability(double r, double T, double q, double n, double u, double d)
        {

            double p, t;
            t = T / n;

            //TrinomialTree prob_down = new TrinomialTree();
            //double u = calcUpTick()
            p = (Math.Exp((r - q) * t) - d) / (u - d);

            return p;


        }
         
    */



    }
}
