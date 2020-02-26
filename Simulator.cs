using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo_Pricer
{
    public class Simulator
    {
        // Simulator class calculates all price paths using methods of calculation defined within the Option subclasses

        
        double delta_t = InputOutput.Tenor / InputOutput.N_Steps;

        public double[,] getRandomMatrix()
        {

            RandomGenerator rnd = new RandomGenerator();
            double[,] rand = new double[InputOutput.N_Steps, InputOutput.N_Steps];
            rand = rnd.createRandoms();

            return rand;

        } 


        public double[] calcSimPrices(double S, double K, double r, double T, double drift, double vol, int trials, int n_steps, int put_call, double[,] rand)
        {
            // need to modify to get random numbers from the randm number generator - do later

            double delta_t = T / n_steps;
            double[,] assetSimPrices = new double[trials + 1, n_steps + 1];
            double[] payoffValues = new double[trials];
            

            
            SDE sde = new SDE();
            European euro = new European();
          


            // set first column to initial spot price
            for (int i = 0; i <= trials; i++)
            {
                assetSimPrices[i, 0] = S;
            }

            // for loop to calculate monte carlo prices of underlying. Trails = i and number of steps = j.
            for (int i = 0; i < trials; i++)
            {
                

                for (int j = 0; j < n_steps; j++)
                {

                    double randnum = rand[i, j];

                    assetSimPrices[i, j + 1] = assetSimPrices[i, j] * sde.GBM(delta_t, drift, vol, randnum);


                }



            }

            //Console.WriteLine("assetPrice[trials, n_steps] = " + assetSimPrices[trials +1, n_steps + 1]);

            double[] optionPrices = new double[trials + 1];


            for (int i = 0; i <= trials; i++)
            {

                double asset_px = assetSimPrices[i, n_steps];
                optionPrices[i] = euro.calcOptionPrice(asset_px, K, r, T, n_steps, put_call);



            }

            return optionPrices;

        }



            public double calcAverage(double[] valueArray, double trials)
            {
                double sum = 0;

                for (int i = 0; i <= trials; i++)
                {
                    sum += valueArray[i];
                }

                double avg = Convert.ToDouble(sum / trials);


                return avg;

            }

           

        

    }
    

}
