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
        double[,] randnums = new double[trials, steps];


        // Create matrix of random numbers:
        public double[,] createRandoms()
        {

           for(long i = 0; i < trials; i++)
            {
                for(long j = 0; j < steps; j++)
                {
                    randnums[i, j] = NormRand_BoxMuller();

                }
            }

            return randnums;

        }


        // Method to calculate random numbers using box-muller (add other methods of random num generation later)
        private double NormRand_BoxMuller()
        {

            var obj = new Object();
            double randnum1 = 0, randnum2 = 0;


            lock (rand) randnum1 = rand.NextDouble();
            lock (rand) randnum2 = rand.NextDouble();

            double z1 = 0;
            z1 = Math.Sqrt((-2) * Math.Log(randnum1)) * Math.Cos(2 * Math.PI * randnum2);
            return z1;

        }

    }
}
