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

        
        /*    
        // Pass input values to Simulator variables
        double S = InputOutput.SpotPrice;
        double K = InputOutput.StrikePrice;
        double r = InputOutput.Rate;
        double T = InputOutput.Tenor;
        double N = InputOutput.N_Steps;
        int trials = InputOutput.Trials;

        double drift = InputOutput.Rate;
        */

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
            

            //Random rnd = new Random();
            SDE sde = new SDE();
            //RandomGenerator rnd = new RandomGenerator();
            //double[,] rand = new double[InputOutput.N_Steps, InputOutput.N_Steps];
            //rand = rnd.createRandoms();

            


            European euro = new European();


            // set first column to initial spot price
            for (int i = 0; i <= trials; i++)
            {
                assetSimPrices[i, 0] = S;
            }

            // for loop to calculate monte carlo prices of underlying. Trails = i and number of steps = j.
            for (int i = 0; i < trials; i++)
            {

                //Console.WriteLine("trial # i =" + i);
                //Console.ReadLine();


                for (int j = 0; j <= n_steps - 1; j++)
                {

                    double randnum = rand[i, j];
                    //Console.WriteLine("step # j = " + j);

                    assetSimPrices[i, j + 1] = assetSimPrices[i, j] * sde.GBM(delta_t, drift, vol, randnum);
                    //assetSimPrices[i, j + 1] = assetSimPrices[i, j] * Math.Exp((drift - Math.Pow(vol, 2) / 2) * delta_t + vol * Math.Sqrt(delta_t) * randnum);

                    //Console.WriteLine("assetPrice[j, i + 1] = " + assetSimPrices[i, j + 1]);

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
