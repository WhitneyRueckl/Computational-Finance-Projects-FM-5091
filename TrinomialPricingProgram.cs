using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Files SDE.cs and PriceCalculator.cs are needed for this program. The following three scripts posted comprise this prject: TrinomialPricingProgram.cs, SDE.cs, and PriceCalculator.cs
namespace Trinomial_Tree_Pricing_Model
{
    class TrinomialPricingProgram
    {
        static void Main(string[] args)
        {

            Console.WriteLine("======== FM 5091 Project: Trinomial Tree Option Pricing Model in C#: ========");

            // Console.WriteLine("Press Enter to start");
            // Console.ReadLine();

            
            Console.WriteLine("Please provide the following inputs for option pricing =");
            Console.WriteLine("");

            Console.Write("Enter underlying price = ");
           
            double asset_price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the strike price = ");
            
            double strike = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the risk-free rate (in decimal form) = ");
            
            double rate = Convert.ToDouble(Console.ReadLine());


            Console.Write("Enter volatility (in decimal format) = ");
            double vol = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter tenor of the option= ");
            double tenor = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter number of steps (this is the # of nodes in the trinomial tree) = ");
            int n_steps = Convert.ToInt16(Console.ReadLine());

            Console.Write("Enter dividend yield of the underlying = ");
            double div_yield = Convert.ToDouble(Console.ReadLine());


            Console.Write("Enter 0 for put or 1 for call option = ");
            double put_call_type = Convert.ToDouble(Console.ReadLine());


            Console.Write("Enter option type, enter 0 for 'american' or  1 for 'european' option = ");
            double o_type = Convert.ToDouble(Console.ReadLine());

            


            //asset_price = 100;     // price of underlying (stock in this case) (corresponds to S)
            //strike = 100;     // Strike price (corresponds to K)
            //rate = 0.06;   // risk-free rate  (corresponds to r)
            //div_yield = 0;       // Dividend yield  (corresponds to q)
            //vol = 0.2; // Volitility (corresponds to sigma)
            //tenor = 1;      // Tenor    (corresponds to T)
            //n_steps = 3;      // number of steps in tree (corresponds to n)
           // american = true;


            // declare vars out here (for now, or maybe perm if use this keyword in method)
            double S, K, r, q, sigma, T, t, n, d1, d2, put_call, option_type;
            //string put_call, option_type;

            S = asset_price;     // price of underlying (stock in this case)
            K = strike;         // Strike price
            r = rate;           // risk-free rate
            q = div_yield;      // Dividend yield
            sigma = vol;        // Volitility
            T = tenor;          // Tenor    
            n = n_steps;        // number of steps in tree
            t = T / n;
            put_call = put_call_type;
            option_type = o_type;            // option_type = 1 is american, option_type = 0 is european

           


            // Write paramters to interface:
            Console.WriteLine("Option pricing paramters: ");
            Console.WriteLine("   asset_price = " + S);
            Console.WriteLine("   strike = " + K);
            Console.WriteLine("   rate = " + r);
            Console.WriteLine("   div_yield = " + q);
            Console.WriteLine("   vol = " + sigma);
            Console.WriteLine("   tenor = " + T);
            Console.WriteLine("   n_steps = " + n);
            Console.WriteLine("   call or put?  = " + put_call);
            Console.WriteLine("   option type = " + option_type);


            // Instantiate objects for classes:
            PriceCalculator pricer = new PriceCalculator();
            SDE sde = new SDE();


            // Get SDE parameters
            double delta_t = T / n_steps;
            double delta_x = sigma * Math.Sqrt(3 * delta_t);
            double v = r - q - 0.5 * sigma;

            double u = sde.calcUpTick(sigma, delta_t, delta_x, n);             // u = edx
            double d = sde.calcDownTick(sigma, delta_t, delta_x, n);           // d = 1/edx

            double pu = sde.calcProbabilityUp(r, delta_t, q, n, sigma, delta_x, v);
            double pd = sde.calcProbabilityDown(r, delta_t, q, n, sigma, delta_x, v);
            double pm = 1 - pu - pd;

            double disc = pricer.calcDiscountFactor(r, delta_t);


            Console.WriteLine("Uptick factor: u = edx = " + u);
            Console.WriteLine("Downtick factor: d = 1/edx = " + d);
            Console.WriteLine("Probability of up = " + pu);
            Console.WriteLine("Probability of down = " + pd);
            Console.WriteLine("Probability of flat = " + pm);
            Console.WriteLine("Discount factor = " + disc);


            Console.WriteLine("Check inputs make sense:");
            Console.WriteLine("Do sum of transition probabilities equal 1?: " + ((pu + pd + pm) == 1));
            Console.WriteLine("Do up/down moves multi to 1?: " + (u * d == 1));



            
            Console.ReadLine();



            Console.WriteLine("========== Pricing an" + option_type + "  " + put_call + " option: ==========");


            //Console.WriteLine("----- Calculating underlying stock price array:");

            double[,] stockvalue = new double[2 * n_steps + 1, n_steps + 1];
            double[,] payoff = new double[2 * n_steps + 1, n_steps + 1];
            double[,] optionprice = new double[2 * n_steps + 1, n_steps + 1];

            stockvalue = pricer.calcAssetPrice(S, u, d, n_steps);


            Console.WriteLine("Stockvalue array: write to console line commented out for tidyness when N gets big");
            //  Array.ForEach(stockvalue, Console.WriteLine);
           // Console.WriteLine(String.Join(" ", stockvalue.Cast<double>()));

            // payoff matrix is used as option prices final node in pricer method
           payoff = pricer.calcPayoff(stockvalue, K, n_steps, put_call);

           Console.WriteLine("Payoff/option value (at final node): write to console line commented out for tidyness when N gets big");
           //Console.WriteLine(String.Join(" ", payoff.Cast<double>()));
          



            optionprice = pricer.calcOptionPrices(stockvalue, K, disc, pu, pd, pm, n_steps, put_call, option_type);


            Console.WriteLine("Option pricing (at final node): write to console line commented out for tidyness when N gets big. Single option price is printed below for grading");
            //Console.WriteLine(String.Join(" ", optionprice.Cast<double>()));
            //Console.WriteLine(" ----> Price of option = " + optionprice[0, 0]);



            // Printing output for greeks:

            Console.Write("  Price of option: ");
            Console.WriteLine(optionprice[0, 0]);


            Console.Write("  Greeks for option: ");
            Console.Write(" ");
            double delta = pricer.calcDelta(optionprice, stockvalue);
            Console.Write("  Delta: ");
            Console.WriteLine(delta);

            double gamma = pricer.calcGamma(optionprice, stockvalue);
            Console.Write("  Gamma: ");
            Console.WriteLine(gamma);

            double theta = pricer.calcTheta(optionprice, delta_t);
            Console.Write("  Theta: ");
            Console.WriteLine(theta);

             /*
            SDE sde_v = new SDE();

            double pu_v_plus = sde_v.calcProbabilityUp(r, t, q, n_steps, sigma + .0001, delta_x, v);
            double pd_v_plus = sde_v.calcProbabilityDown(r, t, q, n_steps, sigma + .0001, delta_x, v);

            double pu_v_minus = sde_v.calcProbabilityUp(r, t, q, n, sigma - .0001, delta_x, v);
            double pd_v_minus = sde_v.calcProbabilityDown(r, t, q, n, sigma - .0001, delta_x, v);

            double[,] optionprice_sigplus = pricer.calcOptionPrices(stockvalue, K, disc, pu_v_plus, pd_v_plus, pm, n_steps, put_call, option_type);

            double[,] optionprice_sigminus = pricer.calcOptionPrices(stockvalue, K, disc, pu_v_minus, pd_v_minus, pm, n_steps, put_call, option_type);

            double veg = (optionprice_sigplus[0, 0] - optionprice_sigminus[0, 0])/(2 * .0001);

            Console.Write("  Vega =  ");
            Console.WriteLine(veg);


            double pu_r_plus = sde_v.calcProbabilityUp(r + .0001, t, q, n_steps, sigma, delta_x, v);
            double pd_r_plus = sde_v.calcProbabilityDown(r - .0001, t, q, n_steps, sigma, delta_x, v);

            double pu_r_minus = sde_v.calcProbabilityUp(r - .0001, t, q, n, sigma, delta_x, v);
            double pd_r_minus = sde_v.calcProbabilityDown(r + .0001, t, q, n, sigma, delta_x, v);

            double[,] optionprice_sigplusr = pricer.calcOptionPrices(stockvalue, K, disc, pu_v_plus, pd_v_plus, pm, n_steps, put_call, option_type);

            double[,] optionprice_sigminusr = pricer.calcOptionPrices(stockvalue, K, disc, pu_r_minus, pd_r_minus, pm, n_steps, put_call, option_type);

            double rho = (optionprice_sigplusr[0, 0] - optionprice_sigminusr[0, 0]) / (2 * .0001);

            Console.Write("  Rho =  ");
            Console.WriteLine(rho);

            */
            
            
            

            // ====================== END SCRIPT FOR PROJECT ==========================



