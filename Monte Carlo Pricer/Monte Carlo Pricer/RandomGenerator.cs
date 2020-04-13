using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo_Pricer
{
    public class RandomGenerator
    {
         Random rand = new Random();
        //InputOutput IO = new InputOutput();
        

        
        static int trials = InputOutput.Trials;
        static int steps = InputOutput.N_Steps;
        double[,] randnums = new double[trials + 1, steps + 1];
       // double[,] neg_randnums = new double[trials + 1, steps + 1];


        // Create matrix of random numbers:
        public (double[,] randnums, double[,] neg_randnums) createRandoms()
        {
            double[,] randnums = new double[trials + 1, steps + 1];
            double[,] neg_randnums = new double[trials + 1, steps + 1];

            Parallel.ForEach(IEnum.Step(0, Convert.ToInt64(InputOutput.Trials), 1), new ParallelOptions { MaxDegreeOfParallelism = InputOutput.Num_Cores }, i =>
            {
                //Random rand = new Random();

                for (long j = 0; j < steps; j++)
                {
                    randnums[i, j] = NormRand_BoxMuller();

                    neg_randnums[i, j] = randnums[i, j] * -1;

                }
            });

            return (randnums, neg_randnums);

        }


        // Method to calculate random numbers using box-muller (add other methods of random num generation later)
        private double NormRand_BoxMuller()
        {

            //var obj = new Object();
            double randnum1 = 0, randnum2 = 0;


            lock (rand) randnum1 = rand.NextDouble();
            lock (rand) randnum2 = rand.NextDouble();

            double z1 = 0;
            z1 = Math.Sqrt((-2) * Math.Log(randnum1)) * Math.Cos(2 * Math.PI * randnum2);
            return z1;

        }


     
        public static double[,] createNegRandoms(double[,] rand_matrix)
        {
            double[,] neg_matrix = new double[InputOutput.Trials, InputOutput.N_Steps + 1];

            for (long i = 0; i < InputOutput.Trials; i++)
            {
                for (long j = 0; j < InputOutput.N_Steps; j++)
                {
                    //Console.WriteLine("random num " + IO.randoms[i, j]);

                    //InputOutput.neg_randoms[i, j] = InputOutput.randoms[i, j] * -1;

                    neg_matrix[i, j] = rand_matrix[i, j] * -1;

                    //Console.WriteLine("Neg randoms: " + IO.neg_randoms[i, j]);

                }
            }

            return neg_matrix;

        }

        /*
        // Create matrix of random numbers:
        public double[,] createRandoms()
        {

            for (long i = 0; i < trials; i++)
            {
                for (long j = 0; j < steps; j++)
                {
                    randnums[i, j] = NormRand_BoxMuller();

                }
            }

            return randnums;

        }
        */



    }
}
