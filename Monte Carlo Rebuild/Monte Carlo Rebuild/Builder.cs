using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo_Rebuild
{
    public class Builder
    {


  


        public void generateResults()
        {




            //IO.getInput();

            //Simulator sim = new Simulator();
            Underlying underlying = new Underlying();
            Option opt = new Option();
            European euro = new European();
            //SDE sde = new SDE();
            RandomGenerator rnd = new RandomGenerator();
            Other calc = new Other();
            PriceCalculator pricer = new PriceCalculator();

            Console.WriteLine("Property values of underlying are below: ");
            underlying.tellMeValues();

            Console.WriteLine("Number of cores available :  " + IO.Num_Cores);



            // start stopwatch to time performance
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            // Create random number matrix and negative random number matrix for simulator
            // automatically create the negative random matrix (no if else logic for setting negative rand matrix for simulator)
            // doing this because don't think it takes too many extra resources to create the negative version of the random
            // matrix once the random matrix is created. The negative version of the matrix is made inside the createRandoms()
            // in the same for loop with the random matirx

            // --->> need ot add logic for if want to use multithreading or not****

            //Simulator.randMatrix = Simulator.getRandomMatrix();
            //Simulator.neg_randMatrix = rnd.createNegRandoms(Simulator.randMatrix);

            Simulator.setRandomMatrix();

            // set all paths including greeks, the simulation of paths is kicked off here
            // inside it uses the simulatePaths() method inside the Simulator class.
            // Logic for whether to apply Antithetic (negative paths) is in this method
            Simulator.setSimulatePaths(underlying, IO.Tenor, IO.N_Steps, IO.Trials);



            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            IO.Timer = ts;

            Console.WriteLine("Elapsed time to create random matrices and simulate underlying paths:  " + ts);

            Console.WriteLine("Press key to continue");
            Console.ReadLine();


            Console.WriteLine("Calculating prices:");

            ComputeResultswPricer();

            Console.WriteLine("Press key to exit");
            Console.ReadLine();


        }


        void ComputeResultswPricer()
        {

                    
            Underlying underlying = new Underlying();
            Option opt = new Option();
            European euro = new European();
            RandomGenerator rnd = new RandomGenerator();
            Other calc = new Other();
            PriceCalculator pricer = new PriceCalculator();


            // Execute version using the PriceCalculator
            // greeks calculated using the static sim paths

            Console.WriteLine(" --- Calculating WITH the PriceCalculator: ----");

            IO.optionPrices = pricer.computePrices().optionPrices;


            // averaging done inside pricer method
            IO.O_Price = pricer.computePrices().option_price;

            IO.O_StdErr = calc.calcStandardError(IO.optionPrices, IO.Trials);

            Console.WriteLine();


            Console.WriteLine("PRICER ====>  " + IO.OptionType + "  Price  =  " + IO.O_Price + "  Standard Error = " + IO.O_StdErr);


            Console.WriteLine();


            OptionGreeks greek = new OptionGreeks();

            IO.O_Delta = greek.calcDeltaGamma(underlying, opt).delta;
            IO.O_Gamma = greek.calcDeltaGamma(underlying, opt).gamma;
            IO.O_Vega = greek.calcVega(underlying, opt);
            IO.O_Rho = greek.calcRho(underlying, opt);
            IO.O_Theta = greek.calcTheta(underlying, opt);


            Console.WriteLine("OPTION PRICER ====>  " + IO.OptionType + "  Price  =  " + IO.O_Price + "  Standard Error = " + IO.O_StdErr);

            Console.WriteLine("Greeks are:");
            Console.WriteLine("Delta = " + IO.O_Delta + "  Gamma = " + IO.O_Gamma +
                               "  Theta = " + IO.O_Theta + "  Vega = " + IO.O_Vega + "  Rho = " + IO.O_Rho);


            Console.WriteLine();
            Console.WriteLine();


        }


    }
       
}
