using System;
using System.Collections.Generic;
using System.Text;

namespace Monte_Carlo_Option_Pricer
{
    public class Underlying
    {

        public double SpotPrice { get; set; }
        public double DivYield {get; set;}
        public double Rate { get; set; }
        public double Vol { get; set; }
        
        public double[,] simPrices { get; set; }

        public Underlying()
        {

            SpotPrice = IO.SpotPrice;
            DivYield = 0.00;
            Rate = IO.Rate;
            Vol = IO.Vol;

        }
        
        public void tellMeValues()
        {

            Console.WriteLine("Spot price of underlying is " + Convert.ToString(SpotPrice));
            Console.WriteLine("Rate of underlying is " + Convert.ToString(Rate));
            Console.WriteLine("Dividend Yield of underlying is " + Convert.ToString(SpotPrice));
            Console.WriteLine("Volatility of underlying is " + Convert.ToString(SpotPrice));
           

        }

       

    }
}
