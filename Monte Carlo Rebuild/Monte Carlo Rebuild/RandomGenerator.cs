using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo_Rebuild
{
    public class RandomGenerator
    {
        Random rand = new Random();


        static int trials { get; set; }
        static int steps { get; set; }

        public RandomGenerator()
        {
            trials = IO.Trials;
            steps = IO.N_Steps;

        }

        // Create matrix of random numbers:
        // This method generates a matrix of random numbers, it can also create a matrix of negative random
        // numbers (same rands but negative) for antithetic variance reduction
        public double[,] createRandoms()
        {
            double[,] randnums = new double[trials + 1, steps + 1];
            double[,] neg_randnums = new double[trials + 1, steps + 1];


            //for (long i = 0; i < trials; i++)
            Parallel.ForEach(IEnum.Step(0, Convert.ToInt64(IO.Trials), 1), new ParallelOptions { MaxDegreeOfParallelism = IO.Num_Cores }, i =>
            {
                for (long j = 0; j < steps; j++)
                {
                    
                    randnums[i, j] = NormRand_BoxMuller();

                    ///neg_randnums[i, j] = randnums[i, j] * -1;

                }
            });

            return randnums;
        }


        // Method to calculate random numbers using box-muller (add other methods of random num generation later)
        private double NormRand_BoxMuller()
        {
            //var obj = new Object();
            double randnum1 = 0, randnum2 = 0;

            // lock is used because is thread safe
            lock (rand) randnum1 = rand.NextDouble();
            lock (rand) randnum2 = rand.NextDouble();

            double z1 = 0;
            z1 = Math.Sqrt((-2) * Math.Log(randnum1)) * Math.Cos(2 * Math.PI * randnum2);
            return z1;

        }



        public double[,] createNegRandoms(double[,] rand_matrix)
        {
            double[,] neg_matrix = new double[IO.Trials, IO.N_Steps + 1];

            for (long i = 0; i < IO.Trials; i++)
            {
                for (long j = 0; j < IO.N_Steps; j++)
                {
                    //Console.WriteLine("random num " + rand_matrix[i, j]);

                    //IO.neg_randoms[i, j] = IO.randoms[i, j] * -1;

                    neg_matrix[i, j] = rand_matrix[i, j] * -1;

                    //Console.WriteLine("Neg randoms: " + neg_matrix[i, j]);

                }
            }

            return neg_matrix;

        }
    }
}
