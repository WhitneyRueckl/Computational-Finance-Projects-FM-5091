using System;
using System.Collections.Generic;
using System.Text;

namespace Monte_Carlo_Option_Pricer
{
    public class Option
    {

        //public bool put_call = false;

        public int OptionID { get; set; }

        private string optype;
        public string OptType { get { return optype; } set { optype = value; } }

        public bool IsPut { get; set; }

        public double Strike{ get; set; }
        public double Tenor { get; set; }
        public double[,] paths { get; set; }

        public double[] optionPriceArr { get; set; }

        public static int steps { get; set; }
        public static int trials { get; set; }


        public Option()
        {

            Strike = IO.StrikePrice;
            Tenor = IO.Tenor;
            OptType = IO.OptionType;
            IsPut = IO.IsPut;
            int steps = IO.N_Steps;
            int trials = IO.Trials;

        }


        double K = IO.StrikePrice;
        double r = IO.Rate;
        double T = IO.Tenor;
        double vol = IO.Vol;
        //double drift = IO.Rate;
        bool put_call = IO.IsPut;


        //Simulator sim = new Simulator();
        Other calc = new Other();

        //European euro = new European();


        public double[,] getSimPaths(Underlying under, double T, int steps, int trials, double[,] rands)
        {

            double[,] paths = Simulator.simulatePaths(under, T, steps, trials, rands);
            
            return paths;

        }








        // ------- Methods to calculate greeks -------


        /// <calcDelta>
        /// 
        /// </summary>
        /// <param name="under"></param>
        /// <returns></returns>
        public double calcDelta(Underlying under)
            {
            European euro = new European();

            // Delta needs paths for S+, S- (S = SpotPrice of underlying)

            // Underlying object is passed as a parameter, 'under' is an instance that represents the original underlying object
            // the instance 'copy_under' is created to modify only the propertiy of the underlying I want to 
            // modify to calculate greeks, in the case of delta, that's the spot price
            // Make copy of original underlying asset then overwrite the Spot price for S_up and S_down
            Underlying copy_under = new Underlying();


           // double S_up, S_down;
            double delta_S = under.SpotPrice * 0.001;
            double[] C1_arr, C2_arr;
            double C1, C2;
           
            // Update spot price in copy of underlying for increase in spot price (S_up)
            copy_under.SpotPrice = under.SpotPrice + delta_S;
            C1_arr = euro.calcOptionPrices(copy_under, K, T, steps, trials, put_call);

            //Console.WriteLine("S_up = " + copy_under.SpotPrice);

            // Update spot price in copy of underlying for decrease in spot price (S_down)
            copy_under.SpotPrice = under.SpotPrice - delta_S;
            C2_arr = euro.calcOptionPrices(copy_under, K, T, steps, trials, put_call);

            //Console.WriteLine("S_down = " + copy_under.SpotPrice);

            C1 = calc.calcAverage(C1_arr, trials);
            C2 = calc.calcAverage(C2_arr, trials);

            double delta = (C1 - C2) / (2 * delta_S);


            return delta;


        }

        
        public double calcGamma(Underlying under)
        {
            European euro = new European();

            // Gamma needs paths for S+, S-, and S (S = SpotPrice of underlying)

            // Underlying object is passed as a parameter, under represents the original underlying object
            // copy_under is created to modify only the propertiy of the underlying I want to 
            // modify to calculate greeks, in the case of delta, that's the spot price
            // Make copy of original underlying asset then overwrite the Spot price for S_up and S_down
            Underlying copy_under = new Underlying();

            //double S_up, S_down;
            double delta_S = under.SpotPrice * 0.001;
            double[] C1_arr, C2_arr, C3_arr;
            double C1, C2, C3;

            C2_arr = euro.calcOptionPrices(under, K, T, steps, trials, put_call);

            // Update spot price for an increase then calc option price
            copy_under.SpotPrice = under.SpotPrice + delta_S;
            C1_arr = euro.calcOptionPrices(copy_under, K, T, steps, trials, put_call);


            // Update spot price for a decrease then calc option price
            copy_under.SpotPrice = under.SpotPrice - delta_S;
            C3_arr = euro.calcOptionPrices(copy_under, K, T, steps, trials, put_call);

            C1 = calc.calcAverage(C1_arr, trials);
            C2 = calc.calcAverage(C2_arr, trials);
            C3 = calc.calcAverage(C3_arr, trials);

            Console.WriteLine("Orig gamma output: ");
            Console.WriteLine("C1 = " + C1 + "  C2 =  " + C2 + " C3 = " + C3 + "  delta_s =  " + delta_S + "  delta sq = " + Math.Pow(delta_S, 2));


            double gamma = (C1 - 2 * C2 + C3) / Math.Pow(delta_S, 2);

            return gamma;


        }


        
        // Theta adjusts the tenor up and uses T and T_up - underlying NOT modified
        // Underlying is passed to calcTheta() method, retains all underlying original values but adjusts tenor of option
        public double calcTheta(Underlying under)
        {
 
            European euro = new European();
            double delta_T = 0.001;
            double[] C1_arr, C2_arr;
            double C1, C2;

            double T_up = T + delta_T;

            C1_arr = euro.calcOptionPrices(under, K, T, steps, trials, put_call);
            C2_arr = euro.calcOptionPrices(under, K, T_up, steps, trials, put_call);

            C1 = calc.calcAverage(C1_arr, trials);
            C2 = calc.calcAverage(C2_arr, trials);

            
            double theta = (C2 - C1) / (delta_T);


            return theta;

        }

        
        public double calcVega(Underlying under)
        {

            European euro = new European();
            double vol_up, vol_down;
            double delta_vol = vol * 0.001;
            double[] C1_arr, C2_arr;
            double C1, C2;

            Underlying copy_under = new Underlying();

            // Update Vol in copy of underlying for increase in Vol
            copy_under.Vol = under.Vol + delta_vol;
            C1_arr = euro.calcOptionPrices(copy_under, K, T, steps, trials,  put_call);

            // Update Vol in copy of underlying for decrease in Vol
            copy_under.Vol = under.Vol - delta_vol;
            C2_arr = euro.calcOptionPrices(copy_under, K, T, steps, trials,  put_call);

            C1 = calc.calcAverage(C1_arr, trials);
            C2 = calc.calcAverage(C2_arr, trials);

            double vega = (C1 - C2) / (2 * delta_vol);

            return vega;

        }



        public double calcRho(Underlying under)
        {
            European euro = new European();
            double delta_r = r * 0.001;
            double[] C1_arr, C2_arr;
            double C1, C2;

            Underlying copy_under = new Underlying();

            

            // Update Rate in copy of underlying for increase in Rate
            copy_under.Rate = under.Rate + delta_r;
            C1_arr = euro.calcOptionPrices(copy_under, K, T, steps, trials,  put_call);

            // Update Rate in copy of underlying for decrease in Rate
            copy_under.Rate = under.Rate - delta_r;
            C2_arr = euro.calcOptionPrices(copy_under, K, T, steps, trials,  put_call);

            C1 = calc.calcAverage(C1_arr, trials);
            C2 = calc.calcAverage(C2_arr, trials);

            double rho = (C1 - C2) / (2 * delta_r);

            return rho;


        }

        

       


    }














    // Originally put Rueopean class in same script as Option class, moved to its own script
    /*
    public class European : Option
    {



        public double[] calcOptionPrice(double S, double K, double vol, double r, double T, int steps, int trials, bool isput)
        {

           // double[,] assetSimPrices = new double[trials + 1, steps + 1];


            double[,] assetSimPrices = getSimPaths(S, vol, r, T, steps, trials);

            double[] optionPrices = new double[trials + 1];

            double discfactor = Math.Pow(Math.E, -r * T);

            for (int i = 0; i <= trials; i++)
            {
                //Console.WriteLine("trials = " + trials);

                //int x = assetSimPrices.GetLength(0);            //paths.GetLength(0);
                //int y = assetSimPrices.GetLength(1);


               // Console.WriteLine("asset matrix dimensions: " + x + ", " + y);

                //Console.WriteLine("asset price at i and steps = " + assetSimPrices[i, steps]);
                //Console.ReadLine();
                double asset_px = assetSimPrices[i, steps];
                double payoff = calcPayoff(asset_px, K, isput);


                optionPrices[i] = payoff * discfactor;

            }


            //double optionSimPrice = calcAverage(optionPrices, trials);
            //double discfactor = calcDiscountFactor(r, T);
           

            return optionPrices;

        }


        public double calcPayoff(double S, double K, bool isput)
        {
            // may want to add n_steps back in if want to see payoff at differente steps


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

            return payoff;


        }

    }


    */


    /* this code was in the option parent class -- old, was a test/trying new way
    public double[,] GetSimPaths(double S, double r, double T, double vol, int trials, int n_steps, bool new_rands)
    {
        double drift = r;
        double[,] sims;
        if(new_rands = false)
        {
            double[,] rands = IO.randoms;
            sims = Simulator.simulatePaths(S, r, T, drift, vol, trials, n_steps, rands);

        }
        else
        {
            double[,] rands = Simulator.getRandomMatrix();
            sims = Simulator.simulatePaths(S, r, T, drift, vol, trials, n_steps, rands);
        }


        return sims;



    }

        */


}
