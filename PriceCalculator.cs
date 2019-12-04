using System;

namespace Trinomial_Tree_Pricing_Model
{
    class PriceCalculator
    {
        // This class contains the following methods:
        // 1. calcAssetPrice
        // 2. calcPayoff
        // 3. calcOptionPrices
        // 4. calcDelta
        // 5. calcGamma
        // 6. calcTheta


        public double[,] calcAssetPrice(double S, double u, double d, int n_steps)
        {

            // ask about how get u and d here, for best practice should I pass u and d as an agrument (current way) or create a new instance of SDE class and calc u and d inside this method?

            double[,] stockvalue = new double[2 * n_steps + 1, n_steps + 1];
            double edx = u;

            for (int i = 0; i <= n_steps; i++)
            {
                for (int j = 0; j < 2 * i + 1; j++)
                {

                    //stockvalue[j, i] = S * Math.Pow(u, (j)) * Math.Pow(d, (n_steps - j));

                    stockvalue[j, i] = S * Math.Pow(edx, i - j);


                }

                //Console.WriteLine("j = " + j + " i = " + i + " j - i = " + (j - i));
                // Console.WriteLine("j = " + j + " steps = " + n_steps + " n_steps - i = " + (j - n_steps));
                //Console.WriteLine("stockvalue[j] = " + stockvalue[j]);
                // }


            }

            return stockvalue;

        }



        public double[,] calcPayoff(double[,] asset_px, double K, int n_steps, double put_call)
        {

            double[,] payoff = new double[2 * n_steps + 1, n_steps + 1];
            //double[] payoff_put = new double[n_steps + 1];

            double[,] stockvalue = asset_px;
            double put_call_switch = put_call;

            
            for (int j = 0; j <= 2 * n_steps; j++)
            {


               // Console.WriteLine("STEP THRU PAYOFF/FINAL NODE LOOP");
               // Console.WriteLine("j = " + j);
               // Console.ReadLine();

                //Console.WriteLine("stockvalue[j, n_steps] = " + stockvalue[j, n_steps]);

                payoff[j, n_steps] = Math.Max(0, stockvalue[j, n_steps] - K);

                
                if (put_call_switch == 1)
                {

                    payoff[j, n_steps] = Math.Max(0, stockvalue[j, n_steps] - K);

                }
                else if (put_call_switch == 0)
                {

                    payoff[j, n_steps] = Math.Max(0, K - stockvalue[j, n_steps]);

                } 
                



                //Console.WriteLine("j = " + j);
               // Console.WriteLine("payoff[j,n_steps] = " + payoff[j, n_steps]);
                // }


            }

            return payoff;

        }

        public double calcDiscountFactor(double r, double t)
        {
            double delta_t = t;

            double disc = Math.Pow(Math.E, -r * delta_t);

            return disc;

        }


        public double[,] calcOptionPrices(double[,] asset_px,  double strike, double discfactor, double prob_up, double prob_down, double prob_flat, int n_steps, double put_call, double option_type)
        {

            //double [,]final_node_option_px,
            double[,] option_px = new double[2 * n_steps + 1, n_steps + 1];

            //option_px = final_node_option_px;

            option_px = calcPayoff(asset_px, strike, n_steps, put_call);


            //Console.WriteLine("***Payoff matrix: " + option_px);

            double o_type = option_type;
            //double[,] stockvalue = asset_px;
            double K = strike;
            double pu = prob_up;
            double pd = prob_down;
            double pm = prob_flat;
            double disc = discfactor;

            

            for (int i = n_steps; i > 0; i--)
            {
                for (int j = 0; j < 2 * i - 1; j++)
                {
                    /*
                    Console.WriteLine("WATCH OPTION PRICE LOOP: counters and values:");
                    Console.WriteLine("j , i:" + j + "," + i);
                    Console.WriteLine("option_px[j, i] = " + option_px[j, i]);
                    Console.WriteLine("option_px[j + 1, i] = " + option_px[j + 1, i]);
                    Console.WriteLine("option_px[j + 2, i] = " + option_px[j + 2, i]);

                     */

                    // for european option:
                    option_px[j, i - 1] = disc * (pu * option_px[j, i] + pm * option_px[j + 1, i] + pd * option_px[j + 2, i]);

                    //Console.WriteLine("Node value --->  option_px[j, i - 1] = " +  option_px[j, i - 1]);

                    
                    // If pricing american option:
                    if (o_type == 1)
                    {
                        if (put_call == 1)
                        {
                            option_px[j, i - 1] = Math.Max(option_px[j, i - 1], asset_px[j, i - 1] - K);
                        }

                        else if (put_call == 0)
                        {
                            option_px[j, i - 1] = Math.Max(option_px[j, i - 1], K - asset_px[j, i - 1]);
                        }

                    }

                    

                }


            }


            return option_px;

        }



        public double calcDelta(double[,] option_px, double[,] asset_px)
        {

            double delta = (option_px[0, 1] - option_px[2, 1]) / (asset_px[0, 1] - asset_px[2, 1]);

            return delta;


        }


        public double calcGamma(double[,] option_px, double[,] asset_px)
        {

            double gamma = ((option_px[0, 1] - option_px[1, 1]) / (asset_px[0, 1] - asset_px[1, 1]) -
                    (option_px[1, 1] - option_px[2, 1]) / (asset_px[1, 1] - asset_px[2, 1])) /
                    (0.5 * (asset_px[0, 1] - asset_px[2, 1]));

            return gamma;


        }



        public double calcTheta(double[,] option_px, double delta_t)
        {

            double theta = (option_px[2, 2] - option_px[0, 0]) / (2 * delta_t);

            return theta;



        }
        /*
        public double calcVega(double r, double t, double q, double n, double sigma, double x, double v)
        {

            SDE sde_v = new SDE();

            double up_sig_prob = sde_v.calcProbabilityUp(r, t, q, n, sigma + .00001, x, v);
            double down_sig_prob = sde_v.calcProbabilityUp(r, t, q, n, sigma - .00001, x, v);



            //double vega = calcOptionPrices();


            //return vega;
        }
        */

    }




    

}
