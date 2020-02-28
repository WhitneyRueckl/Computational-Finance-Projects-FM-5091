using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo_Pricer
{
    public class Option : FinancialInstrument
    {

                /*
            public double S{ get; set; }
            public double K{ get; set; }
            public double T { get; set; }
            public double R{ get; set; }
            public double vol { get; set; }
        */

        public string UnderlyingAssetType { get; set; }
          

        double S = InputOutput.SpotPrice;
        double K = InputOutput.StrikePrice;
        double r = InputOutput.Rate;
        double T = InputOutput.Tenor;
        double vol = InputOutput.Vol;
        double drift = InputOutput.Rate;
        int put_call = InputOutput.PutCall;

        int n_steps = InputOutput.N_Steps;
        int trials = InputOutput.Trials;

        Simulator sim = new Simulator();



        public double calcDelta(double[,] rands)
        {

            double S_up, S_down;
            double delta_S = S * 0.001;
            double[] C1_arr, C2_arr;
            double C1, C2;
            

            S_up = S + delta_S;
            S_down = S - delta_S;

           // Simulator sim = new Simulator();
          

            C1_arr = sim.calcSimPrices(S_up, K, r, T, drift, vol, trials, n_steps, put_call, rands);
            C2_arr = sim.calcSimPrices(S_down, K, r, T, drift, vol, trials, n_steps, put_call, rands);

            C1 = sim.calcAverage(C1_arr, trials);
            C2 = sim.calcAverage(C2_arr, trials);



            double delta = (C1 - C2) / (2 * delta_S);


            return delta;


        }


        public double calcGamma(double[,] rands)
        {

            double S_up, S_down;
            double delta_S = S * 0.001;
            double[] C1_arr, C2_arr, C3_arr;
            double C1, C2, C3;


            S_up = S + delta_S;
            S_down = S - delta_S;

            //Simulator sim = new Simulator();
         

            C1_arr = sim.calcSimPrices(S_up, K, r, T, drift, vol, trials, n_steps, put_call, rands);
            C2_arr = sim.calcSimPrices(S, K, r, T, drift, vol, trials, n_steps, put_call, rands);
            C3_arr = sim.calcSimPrices(S_down, K, r, T, drift, vol, trials, n_steps, put_call, rands);


            C1 = sim.calcAverage(C1_arr, trials);
            C2 = sim.calcAverage(C2_arr, trials);
            C3 = sim.calcAverage(C3_arr, trials);

            double gamma = (C1 - 2 * C2 + C3) / Math.Pow(delta_S, 2);

            return gamma;



        }


        public double calcTheta(double[,] rands)
        {

            //double S = this.S;
            double T_up, T_down;
            double delta_T = 0.001;
            double[] C1_arr, C2_arr;
            double C1, C2;


            T_up = T + delta_T;
           // T_down = T - delta_T;

            C1_arr = sim.calcSimPrices(S, K, r, T, drift, vol, trials, n_steps, put_call, rands);
            C2_arr = sim.calcSimPrices(S, K, r, T_up, drift, vol, trials, n_steps, put_call, rands);

            C1 = sim.calcAverage(C1_arr, trials);
            C2 = sim.calcAverage(C2_arr, trials);



            double theta = (C2 - C1) / (delta_T);


            return theta;




        }

        public double calcVega(double[,] rands)
        {
           // double S = this.S;
           // double vol = this.vol;
            double delta_vol = vol * 0.001;
            double[] C1_arr, C2_arr;
            double C1, C2;

            
            double vol_up, vol_down;

            vol_up = vol + delta_vol;
            vol_down = vol - delta_vol;

            C1_arr = sim.calcSimPrices(S, K, r, T, drift, vol_up, trials, n_steps, put_call, rands);
            C2_arr = sim.calcSimPrices(S, K, r, T, drift, vol_down, trials, n_steps, put_call, rands);

            C1 = sim.calcAverage(C1_arr, trials);
            C2 = sim.calcAverage(C2_arr, trials);

            double vega = (C1 - C2) / (2 * delta_vol);


            return vega;


        }


       public double calcRho(double[,] rands)
        {
            double delta_r = r * 0.001;
            double[] C1_arr, C2_arr;
            double C1, C2;


            double r_up, r_down;

            r_up = r + delta_r;
            r_down = r - delta_r;

            C1_arr = sim.calcSimPrices(S, K, r_up, T, drift, vol, trials, n_steps, put_call, rands);
            C2_arr = sim.calcSimPrices(S, K, r_down, T, drift, vol, trials, n_steps, put_call, rands);

            C1 = sim.calcAverage(C1_arr, trials);
            C2 = sim.calcAverage(C2_arr, trials);


            double rho = (C1 - C2) / (2 * delta_r);

            return rho;


        }

    }
}
