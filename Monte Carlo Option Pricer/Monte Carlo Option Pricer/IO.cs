using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Monte_Carlo_Option_Pricer
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
        public static double S = 50;
        public static double K = 50;
        public static int trials = 100000;
        public static int n_steps = 1;
        public static double T = 1;

        public static double vol = 0.50;
        public static double r = 0.05;
        public static double drift = .05;
        public static double delta_t = Convert.ToDouble(T / n_steps);
        public static int put_call = 0;

        public static double[,] randoms = new double[trials, n_steps];


        public static double O_Price { get; set; }
        */





    }
}
