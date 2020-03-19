using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo_Pricer
{
    class ControlVariate
    {

        double S = InputOutput.SpotPrice;
        double K = InputOutput.StrikePrice;
        double r = InputOutput.Rate;
        double T = InputOutput.Tenor;
        double vol = InputOutput.Vol;
        double drift = InputOutput.Rate;
        int put_call = InputOutput.PutCall;

        int n_steps = InputOutput.N_Steps;
        int trials = InputOutput.Trials;


        Func<double, double, double, double, double, double, double> black_scholes_d1 = (S, K, r, vol, T, t) => (Math.Log(S / K)) + (r + 0.5 * Math.Pow(vol, 2) * (T - t) / (vol * Math.Sqrt(T - t)));


        public double[] calcControlVariate(double[,] assetPrices, double K, double r, double T, double drift, double vol, int trials, int n_steps, int put_call)
        {

            //assetPrices, double K, double r, double T, int n_steps, int trials
            // double S, double K, double r, double T, double drift, double vol, int trials, int n_steps, int put_call, double[,] rand

            Simulator sim = new Simulator();
            NormalDist norm = new NormalDist();
            European euro = new European();
            SDE sde = new SDE();

            //double[,] assetPrices = sim.calcSimPrices(S, K, r, T, drift, vol, trials, n_steps, put_call, InputOutput.randoms).asset_prices;
            // double[] optPrices = sim.calcSimPrices(S, K, r, T, drift, vol, trials, n_steps, put_call, InputOutput.randoms).opt_prices;

            double[] opt_price_arr = new double[trials + 1];
            double cv = 0;
            double beta1 = -1;
            double d1 = 0, bs_delta = 0;
            //double[]

            for (int i = 0; i < trials; i++)
            {
                double delta_t = T / n_steps;

                //double St = assetPrices[i, 0];
                cv = 0;

                for (int j = 1; j < n_steps + 1; j++)
                {
                    //St_n = assetPrices[i, j + 1];
                    double t = (j - 1) * delta_t;

                    if(put_call == 1)
                    {
                       d1 = black_scholes_d1(assetPrices[i, j - 1], K, r, vol, T, t);
                       bs_delta = norm.NormDistCDF(d1);

                    }
                    else if (put_call == 0)
                    {
                       
                        d1 = black_scholes_d1(assetPrices[i, j - 1], K, r, vol, T, t);
                        bs_delta = norm.NormDistCDF(d1) - 1;
                    }
                 
                    

                    //St_n = St * sde.GBM(delta_t, drift, vol, rand[i, j]);
                    
                    // assetPrices array has the simulated asset prices, no need to create St and Stn like in the book/class sample code
                    cv += bs_delta * (assetPrices[i, j] - assetPrices[i, j - 1] * Math.Exp(-r * (delta_t)));
                                      
                    

                }

               
                double adj_opt_price = euro.calcOptionPrice(assetPrices[i, n_steps], K, r, T, n_steps, put_call, beta1, cv);

               
                opt_price_arr[i] = adj_opt_price;

                //double opt_px = sim.calcAverage(opt_price_arr, trials);


            }

            return opt_price_arr;

        }



    }
}
