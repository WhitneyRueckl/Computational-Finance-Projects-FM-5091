using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;


namespace Monte_Carlo_Option_Pricer
{
    public class Builder
    {


        public static void generateResults()
        {


            PriceCalculator pricer = new PriceCalculator();
            RandomGenerator rnd = new RandomGenerator();

            Underlying underlying = new Underlying();
            Option opt = new Option();

            Other calc = new Other();

            OptionGreeks greek = new OptionGreeks();


            //Console.WriteLine("Tell me the property values of underlying: ");
            //underlying.tellMeValues();

            //Console.WriteLine("Number of cores available :  " + IO.Num_Cores);


            // start stopwatch to time performance
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            // Create random number matrix and negative random number matrix for simulator
            // automatically create the negative random matrix (no if else logic for setting negative rand matrix for simulator)
            // doing this because don't think it takes too many extra resources to create the negative version of the random
            // matrix once the random matrix is created.

            //Simulator.randMatrix = Simulator.getRandomMatrix();
            //Simulator.neg_randMatrix = rnd.createNegRandoms(Simulator.randMatrix);

             Simulator.setRandomMatrix();

            // set all paths including greeks, the simulation of paths is kicked off here
            // inside it uses the simulatePaths() method inside the Simulator class.
            // Logic for whether to apply Antithetic (negative paths) is in this method
            Simulator.setSimulatePaths(underlying, IO.Tenor, IO.N_Steps, IO.Trials);


            Console.WriteLine("sim Paths working????  :  " + Simulator.simPaths[2, 1]);

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            //Console.WriteLine("Elapsed time to create random matrices:  " + ts);


            //Console.WriteLine(" --- Calculating WITH the PriceCalculator: ----");

            IO.optionPrices = pricer.computePrices().optionPrices;

            // averaging done inside pricer method
            IO.O_Price = pricer.computePrices().option_price;

            //IO.O_StdErr = calc.calcStandardError(IO.optionPrices, IO.Trials);

            IO.O_StdErr = 55.5;
 


            IO.O_Delta = greek.calcDeltaGamma(underlying, opt).delta;
            IO.O_Gamma = greek.calcDeltaGamma(underlying, opt).gamma;
            IO.O_Vega = greek.calcVega(underlying, opt);
            IO.O_Rho = greek.calcRho(underlying, opt);
            IO.O_Theta = greek.calcTheta(underlying, opt);



        }



    }
}
