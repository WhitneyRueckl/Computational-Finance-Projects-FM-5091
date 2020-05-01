using System;
using System.Collections.Generic;
using System.Text;

namespace Monte_Carlo_Rebuild
{
    public static class IO
    {


        // Input output class serves as gateway between the form and the calculations

        // Inputs
        private static double spot;
        private static double strike;
        private static double rate;
        private static double tenor;
        private static double drift;
        private static double vol;
        private static bool isPut;
        private static string optiontype;
        private static int trials;
        private static int n_steps;
        private static bool var_reduc;
        private static bool var_reduc_cv;
        private static bool multithread;
        private static int num_cores;
        private static TimeSpan timer;

        private static string barriertype;
        private static double barrierprice;


        //Outputs
        private static double o_price;
        private static double o_stderr;
        private static double o_delta;
        private static double o_gamma;
        private static double o_vega;
        private static double o_theta;
        private static double o_rho;
        private static int o_steps;
        private static int o_trials;




        // --- Properties of input/output ----


        // Simulator 
        public static int Trials { get => trials; set => trials = value; }
        public static int N_Steps { get => n_steps; set => n_steps = value; }



        // Underlying 

        public static double SpotPrice { get => spot; set => spot = value; }
        public static double Vol { get => vol; set => vol = value; }

        public static double Rate { get => rate; set => rate = value; }

        public static double Drift { get => drift; set => drift = value; }



        // Option

        public static double StrikePrice { get => strike; set => strike = value; }
        public static double Tenor { get => tenor; set => tenor = value; }
        public static bool IsPut { get => isPut; set => isPut = value; }

        public static string OptionType { get => optiontype; set => optiontype = value; }

        public static string BarrierType { get => barriertype; set => barriertype = value; }

        public static double BarrierPrice { get => barrierprice; set => barrierprice = value; }


        public static double O_Price { get => o_price; set => o_price = value; }


        // Greeks

        public static double O_Delta { get => o_delta; set => o_delta = value; }
        public static double O_Gamma { get => o_gamma; set => o_gamma = value; }
        public static double O_Vega { get => o_vega; set => o_vega = value; }

        public static double O_Theta { get => o_theta; set => o_theta = value; }

        public static double O_Rho { get => o_rho; set => o_rho = value; }


        // Variance reduction

        public static double O_StdErr { get => o_stderr; set => o_stderr = value; }

        public static bool Var_Reduc { get => var_reduc; set => var_reduc = value; }

        public static bool CV_Var_Reduc { get => var_reduc_cv; set => var_reduc_cv = value; }

        public static bool Multithread { get => multithread; set => multithread = value; }





        public static double[] optionPrices = new double[trials + 1];

        public static double[,] assetPrices = new double[trials + 1, n_steps + 1];

        public static double[] neg_optionPrices = new double[trials + 1];

        public static double[] AdjCV_optionPrices = new double[trials + 1];

        public static double[,] randoms = new double[Trials, N_Steps + 1];

        public static int Num_Cores { get => num_cores; set => num_cores = value; }

        public static TimeSpan Timer { get => timer; set => timer = value; }


        /*
        static IO()
        {

            // Underlying inputs
            IO.SpotPrice = 50;
            IO.Rate = 0.05;
            IO.Vol = 0.50;
            IO.Drift = IO.Rate;


            // Option inputs
            IO.OptionType = "European";
            IO.StrikePrice = 50;
            IO.Tenor = 1;



            // If not a barrier type, these input with my ignored
            IO.BarrierType = "Down-In";
            IO.BarrierPrice = 53.00;

            IO.N_Steps = 2;
            IO.Trials = 10000;
            IO.IsPut = false;
            IO.Var_Reduc = true;
            IO.CV_Var_Reduc = false;
            IO.Multithread = true;
            IO.Num_Cores = System.Environment.ProcessorCount;


        }
        */


        /*

        public static void getInput()
        {

            
            Console.WriteLine("Enter spot price: ");
            IO.SpotPrice = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Rate : ");
            IO.Rate = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter volatility of the underlying: ");
            IO.Vol = Convert.ToDouble(Console.ReadLine());
            


            Console.WriteLine("Enter the option style, please choose from the following:  European, Asian, Lookback, Digital, Barrier, or Range  ");
            IO.OptionType = Convert.ToString(Console.ReadLine());


            
            Console.WriteLine("Enter option strike price : ");
            IO.StrikePrice = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("Enter tenor: ");
            IO.Tenor = Convert.ToDouble(Console.ReadLine());
            


            
             
            Console.WriteLine("Is this a put option? 'Y' for a put and 'N' for a call: ");
            string isput_q = Console.ReadLine();

            if (isput_q == "Y")
            {
                IO.IsPut = true;
            }
            else if (isput_q == "N")
            {
                IO.IsPut = false;
            }

            Console.WriteLine("Variance reduction: Turn on antithetic? (Y or N): ");
            string var_reduc = Convert.ToString(Console.ReadLine());


            if (var_reduc == "Y")
            {
                IO.Var_Reduc = true;
            }
            else if (var_reduc == "N")
            {
                IO.Var_Reduc = false;
            }

            Console.WriteLine("Turn on control variate? (Y or N): ");
            string cv_var_reduc = Convert.ToString(Console.ReadLine());


            if (cv_var_reduc == "Y")
            {
                IO.CV_Var_Reduc = true;
            }
            else if (cv_var_reduc == "N")
            {
                IO.CV_Var_Reduc = false;
            }


            Console.WriteLine("Turn on multithreading?: ");
            string multi_thd = Convert.ToString(Console.ReadLine());

            if (cv_var_reduc == "Y")
            {
                IO.Multithread = true;
            }
            else if (cv_var_reduc == "N")
            {
                IO.Multithread = false;
            }



                
                 

        }
        */

    }
}
