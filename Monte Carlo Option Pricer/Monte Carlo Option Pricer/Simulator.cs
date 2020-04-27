using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Monte_Carlo_Option_Pricer
{
    public static class Simulator
    {
        
        public static int steps { get; set; }
        public static int trials { get; set; }


        public static int cores { get; set; }
        public static double[,] randMatrix { get; set; }
        public static double[,] neg_randMatrix { get; set; }
        public static double[,] simPaths { get; set; }
        public static double[,] neg_simPaths { get; set; }

        public static double[,] simPaths_Sup { get; set; }
        public static double[,] simPaths_Sdown { get; set; }
        public static double[,] simPaths_Volup { get; set; }
        public static double[,] simPaths_Voldown { get; set; }
        public static double[,] simPaths_Rup { get; set; }
        public static double[,] simPaths_Rdown { get; set; }
        public static double[,] simPaths_Tup { get; set; }

        public static double[,] neg_simPaths_Sup { get; set; }
        public static double[,] neg_simPaths_Sdown { get; set; }
        public static double[,] neg_simPaths_Volup { get; set; }
        public static double[,] neg_simPaths_Voldown { get; set; }
        public static double[,] neg_simPaths_Rup { get; set; }
        public static double[,] neg_simPaths_Rdown { get; set; }
        public static double[,] neg_simPaths_Tup { get; set; }




        //SDE sde = new SDE();

        
        static Simulator()
        {

            // Use N number of cores in simulation, default is 1 core
            if (IO.Multithread == true)
            {
                cores = IO.Num_Cores;
            }
            else cores = 1;


            steps = IO.N_Steps;
            trials = IO.Trials;

            randMatrix = new double[IO.Trials + 1, IO.N_Steps + 1];
            neg_randMatrix = new double[IO.Trials + 1, IO.N_Steps + 1];
            simPaths = new double[IO.Trials + 1, IO.N_Steps + 1];
            neg_simPaths = new double[IO.Trials + 1, IO.N_Steps + 1];

            simPaths_Sup = new double[IO.Trials + 1, IO.N_Steps + 1];
            simPaths_Sdown = new double[IO.Trials + 1, IO.N_Steps + 1];
            simPaths_Volup = new double[IO.Trials + 1, IO.N_Steps + 1];
            simPaths_Voldown = new double[IO.Trials + 1, IO.N_Steps + 1];
            simPaths_Rup = new double[IO.Trials + 1, IO.N_Steps + 1];
            simPaths_Rdown = new double[IO.Trials + 1, IO.N_Steps + 1];
            simPaths_Tup = new double[IO.Trials + 1, IO.N_Steps + 1];

            neg_simPaths_Sup = new double[IO.Trials + 1, IO.N_Steps + 1];
            neg_simPaths_Sdown = new double[IO.Trials + 1, IO.N_Steps + 1];
            neg_simPaths_Volup = new double[IO.Trials + 1, IO.N_Steps + 1];
            neg_simPaths_Voldown = new double[IO.Trials + 1, IO.N_Steps + 1];
            neg_simPaths_Rup = new double[IO.Trials + 1, IO.N_Steps + 1];
            neg_simPaths_Rdown = new double[IO.Trials + 1, IO.N_Steps + 1];
            neg_simPaths_Tup = new double[IO.Trials + 1, IO.N_Steps + 1];


        }





        public static void setRandomMatrix()
        {

           // RandomGenerator rnd = new RandomGenerator();

            Simulator.randMatrix = RandomGenerator.createRandoms();

            Simulator.neg_randMatrix = RandomGenerator.createNegRandoms(Simulator.randMatrix);

        }


        // Get random values from random generator:
        public static double[,] getRandomMatrix()
        {
            //RandomGenerator rnd = new RandomGenerator();
            double[,] rands_matrix = new double[IO.Trials + 1, IO.N_Steps + 1];
            //double[,] neg_rands_matrix = new double[IO.Trials + 1, IO.N_Steps + 1];

            rands_matrix = RandomGenerator.createRandoms();
            //neg_rands_matrix = rnd.createNegRandoms(rands_matrix);

            return rands_matrix;

        }




        // void method to set asset sim paths for Paralell.For, can use this for nonParallel by not using the Paralell.For
        public static void setSimulatePaths(Underlying under, double T, int steps, int trials)
        {


            Simulator.simPaths = simulatePaths(under, T, steps, trials, Simulator.randMatrix);

            Simulator.simPaths_Sup = simulatePathsGreeks(under, T, steps, trials, Simulator.randMatrix).simPaths_Sup;
            Simulator.simPaths_Sdown = simulatePathsGreeks(under, T, steps, trials, Simulator.randMatrix).simPaths_Sdown;
            Simulator.simPaths_Volup = simulatePathsGreeks(under, T, steps, trials, Simulator.randMatrix).simPaths_Volup;
            Simulator.simPaths_Voldown = simulatePathsGreeks(under, T, steps, trials, Simulator.randMatrix).simPaths_Voldown;
            Simulator.simPaths_Rup = simulatePathsGreeks(under, T, steps, trials, Simulator.randMatrix).simPaths_Rup;
            Simulator.simPaths_Rdown = simulatePathsGreeks(under, T, steps, trials, Simulator.randMatrix).simPaths_Rdown;
            Simulator.simPaths_Tup = simulatePathsGreeks(under, T, steps, trials, Simulator.randMatrix).simPaths_Tup;


            if (IO.Var_Reduc == true)
            {

                Simulator.neg_simPaths = simulatePaths(under, T, steps, trials, Simulator.neg_randMatrix);

                Simulator.neg_simPaths_Sup = simulatePathsGreeks(under, T, steps, trials, Simulator.neg_randMatrix).simPaths_Sup;
                Simulator.neg_simPaths_Sdown = simulatePathsGreeks(under, T, steps, trials, Simulator.neg_randMatrix).simPaths_Sdown;
                Simulator.neg_simPaths_Volup = simulatePathsGreeks(under, T, steps, trials, Simulator.neg_randMatrix).simPaths_Volup;
                Simulator.neg_simPaths_Voldown = simulatePathsGreeks(under, T, steps, trials, Simulator.neg_randMatrix).simPaths_Voldown;
                Simulator.neg_simPaths_Rup = simulatePathsGreeks(under, T, steps, trials, Simulator.neg_randMatrix).simPaths_Rup;
                Simulator.neg_simPaths_Rdown = simulatePathsGreeks(under, T, steps, trials, Simulator.neg_randMatrix).simPaths_Rdown;
                Simulator.neg_simPaths_Tup = simulatePathsGreeks(under, T, steps, trials, Simulator.neg_randMatrix).simPaths_Tup;

            }


        }




        // Method that generates paths (double S, double vol, double r, double T, int steps, int trials)
        public static double[,] simulatePaths(Underlying under, double T, int steps, int trials, double[,] rands_matrix)
        {
            //SDE sde = new SDE();
            double delta_t = T / steps;

            //Console.WriteLine("Value of cores in Simulator class:  " + cores);

            // set first column to initial spot price
            for (int i = 0; i <= trials; i++)
            {
                simPaths[i, 0] = under.SpotPrice;

            }

            //new ParallelOptions { MaxDegreeOfParallelism = System.Environment.ProcessorCount }
            // for (int i = 0; i < trials; i++)
            Parallel.ForEach(IEnum.Step(0, Convert.ToInt64(IO.Trials), 1), new ParallelOptions { MaxDegreeOfParallelism = cores }, i =>
            {

                for (int j = 0; j < steps; j++)
                {
                    simPaths[i, j + 1] = simPaths[i, j] * SDE.GBM(delta_t, under.Rate, under.Vol, rands_matrix[i, j]);

                    // Console.WriteLine("Simulator asset prices at " + i + " trials and " + j + "steps + 1 = " + simPaths[i, j + 1])
                    // Console.ReadLine();


                }

            });


            return (simPaths);
            //(simPaths, simPaths_Delta, simPaths_Gamma, simPaths_Vega, simPaths_Rho, simPaths_Theta);



        }


        // Simulate paths for greeks:

        public static (double[,] simPaths_Sup, double[,] simPaths_Sdown, double[,] simPaths_Volup,
                        double[,] simPaths_Voldown, double[,] simPaths_Rup, double[,] simPaths_Rdown, double[,] simPaths_Tup)
                 simulatePathsGreeks(Underlying under, double T, int steps, int trials, double[,] rands_matrix)
        {
            SDE sde = new SDE();
            double delta_t = T / steps;

            double delta_vol = under.Vol * 0.001;
            double delta_r = under.Rate * 0.001;
            double delta_S = under.SpotPrice * 0.001;
            double delta_T = (0.001 / steps);
            // Note on delta_T above: for Theta path, need to scale the change with the
            // number of steps so have delta_t = T/N = (T + 0.001)/N = T/N + .001/N --> screwed this up first time




            // set first column to initial spot price
            for (int i = 0; i <= trials; i++)
            {
                // Spot price shocks for Delta
                simPaths_Sup[i, 0] = under.SpotPrice + delta_S;
                simPaths_Sdown[i, 0] = under.SpotPrice - delta_S;

                // Volatility shocks for Vega
                simPaths_Volup[i, 0] = under.SpotPrice;
                simPaths_Voldown[i, 0] = under.SpotPrice;

                // rate shocks for Rho
                simPaths_Rup[i, 0] = under.SpotPrice;
                simPaths_Rdown[i, 0] = under.SpotPrice;

                // Tenor adjustment for Theta
                simPaths_Tup[i, 0] = under.SpotPrice;
                //simPaths_Tdown[i, 0] = under.SpotPrice;
            }

            //new ParallelOptions { MaxDegreeOfParallelism = System.Environment.ProcessorCount }
            // for (int i = 0; i < trials; i++)
            Parallel.ForEach(IEnum.Step(0, Convert.ToInt64(IO.Trials), 1), new ParallelOptions { MaxDegreeOfParallelism = cores }, i =>
            {

                for (int j = 0; j < steps; j++)
                {


                    simPaths_Sup[i, j + 1] = simPaths_Sup[i, j] * SDE.GBM(delta_t, under.Rate, under.Vol, rands_matrix[i, j]);
                    simPaths_Sdown[i, j + 1] = simPaths_Sdown[i, j] * SDE.GBM(delta_t, under.Rate, under.Vol, rands_matrix[i, j]);


                    simPaths_Volup[i, j + 1] = simPaths_Volup[i, j] * SDE.GBM(delta_t, under.Rate, (under.Vol + delta_vol), rands_matrix[i, j]);
                    simPaths_Voldown[i, j + 1] = simPaths_Voldown[i, j] * SDE.GBM(delta_t, under.Rate, (under.Vol - delta_vol), rands_matrix[i, j]);


                    simPaths_Rup[i, j + 1] = simPaths_Rup[i, j] * SDE.GBM(delta_t, (under.Rate + delta_r), under.Vol, rands_matrix[i, j]);
                    simPaths_Rdown[i, j + 1] = simPaths_Rdown[i, j] * SDE.GBM(delta_t, (under.Rate - delta_r), under.Vol, rands_matrix[i, j]);


                    simPaths_Tup[i, j + 1] = simPaths_Tup[i, j] * SDE.GBM((delta_t + delta_T), under.Rate, under.Vol, rands_matrix[i, j]);
                    // simPaths_Tdown[i, j + 1] = simPaths_Tdown[i, j] * sde.GBM((delta_t - delta_T), under.Rate, under.Vol, Simulator.randMatrix[i, j]);

                    // Console.WriteLine("Simulator asset prices at " + i + " trials and " + j + "steps + 1 = " + simPaths[i, j + 1])
                    // Console.ReadLine();


                }

            });



            return (simPaths_Sup, simPaths_Sdown, simPaths_Volup,
                   simPaths_Voldown, simPaths_Rup, simPaths_Rdown, simPaths_Tup);

            //(simPaths, simPaths_Delta, simPaths_Gamma, simPaths_Vega, simPaths_Rho, simPaths_Theta);



        }









        // void for Parallel.For - the trials and steps are set in the RandomGenerator class
        /*
         public static void setRandomMatrix(int i)
         {

             RandomGenerator rnd = new RandomGenerator();

             Simulator.randMatrix = rnd.createRandoms().randnums;
             Simulator.neg_randMatrix = rnd.createRandoms().neg_randnums;

         }
         */




        /*
        for (int i = 0; i < IO.Trials; i++)
        {
            for (int j = 0; j < IO.N_Steps; j++)
            {

                Console.WriteLine("randoms matirx:  " + Simulator.randMatrix[i, j]);
            }

        }
        */





    }
}
