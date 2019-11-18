using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This program gernate random numbers using three methods:
// 1.) SimpleApproxRandNum(): Simple approx algorthim (generate 12 random uniformly distributed numbers, add the 12 values, then subract 6. 
// 2.) BoxMullerMethod() - Box-muller method
// 3.) Polar-rejection method
// It also 


namespace GenerateRandomNumbers
{
    class Program
    {

        // Define SimpleApproxRandNum:

        public double SimpleApproxRandNum()
        {
           
            // Number of random values to generate is n = 12.
            // Array should be of length n-1 because in code add all array values to 'sumr' (1st random number) so then ultimately sumr is the sum of [(n-1)+1] = n values.
            double[] myarray = new double[11];
            double randn, r1, sumr;

            Random rnd = new Random();
            r1 = rnd.NextDouble();
            sumr = r1;

            Console.WriteLine("First r value:" + r1);

            for (int i = 0; i < 11; i++)
            {
                randn = rnd.NextDouble();
                myarray[i] = randn;

                sumr = sumr + myarray[i];

                Console.WriteLine("Print new randn: " + randn);

                //Console.WriteLine("----- Sum of random values = " + sumr);

            }


            double normrandn = sumr - 6;

            //Write values to CSV for validate:
            //string workingDirectory = Environment.CurrentDirectory;
            //string projectDirectory = System.IO.Directory.GetParent(workingDirectory).Parent.FullName;
           
            //Console.WriteLine("Write text file");
           // System.IO.File.WriteAllLines(projectDirectory + @"\SimpleApproxRandNums.txt",
                                       //  myarray.Select(a => a.ToString())); 

            Console.WriteLine("New array length:" + myarray.Length);
            Console.WriteLine("Sum of random values = " + sumr);
            //Console.WriteLine("Random number by SimpleApprox = " + normrandn);

            return normrandn;


        }

        // Define Box-Muller method:
        public string BoxMullerMethod(double x1, double x2) //not using tuple return type
        {
            Console.WriteLine("random num x1 " + x1);
            Console.WriteLine("random num x2 " + x2);

            double z1 = Math.Sqrt(-2 * Math.Log(x1)) * Math.Cos(2 * Math.PI * x2);
            double z2 = Math.Sqrt(-2 * Math.Log(x1)) * Math.Sin(2 * Math.PI * x2);

            // double result = z1;
            string result = "Random Box-Muller values: z1 = " + z1 + ", z2 = " + z2;
            return result;
            //return (z1, z2); //turple literal

        }

   
        
        public string PolarRejectMethod(double x1, double x2)
        {

            double a, b, A, B, w, c, z1, z2;
            int i = 0;
            
            Console.WriteLine("Doing polar rejection method");
           
            Random rnd = new Random();
            a = rnd.NextDouble();
            b = rnd.NextDouble();

            // sum the square of a and b
            w = Math.Pow(a, 2) + Math.Pow(b, 2);

            do
            {

                //Need random value to be [-1,1], so multiple by 2, then subtract 1,
                // then change uniform random from [0,1]to[0,2]to[-1,1]

                A = rnd.NextDouble();
                a = A * 2 -  1;
                B = rnd.NextDouble();
                b = B * 2 - 1;

                w = Math.Pow(a, 2) + Math.Pow(b, 2);

                i = i++;
                Console.WriteLine("iteration num: " + i);

                if (i >= 1000)
                {
                    break;
                }

            } while (w > 1.0);

            c = Math.Sqrt(-2 * Math.Log(w) / w);
            z1 = c * a;
            z2 = c * b;

            string result = "Random Polar Rejection values: z1 = " + z1 + ", z2 = " + z2;
            return result;

        }
          

        // Define method to generate two joint normal pairs given a correlation coefficient:
        public string JointNormDistMethod(double RHO, double E1, double E2)
        {

            double z1, z2;
           // double[] outArr;

            z1 = E1;
            z2 = RHO * E1 + Math.Sqrt(1 - Math.Pow(RHO, 2) * E2);

            string result = "Random jointly distributed random values: z1 = " + z1 + ", z2 = " + z2;
            return result;


        }


        // Inside main below is where methods are called:
        static void Main(string[] args)
        {

            Console.WriteLine("This program generates random numbers using a simple approximation, Box-Muller, polar rejection methods. It also generates two joint normal random variables given a correlation value:");


            // ---- Generate joint normals given correlation value ----
            //Declare vars for gen joint norms:
            double rho, e1, e2;
            string jointnorm, rho2;

            Random newrnd = new Random();
            e1 = newrnd.NextDouble();
            e2 = newrnd.NextDouble();


            Program outjoint = new Program();

            Console.WriteLine("Enter a correlation value, value must be between [-1,1]");
            rho2 = Console.ReadLine();
            rho = Convert.ToDouble(rho2);


            if (rho < -1 || rho > 1)
            {
                Console.WriteLine("!! Invalid input. Correlation value must be between [-1,1]");
                Console.WriteLine(" Re-enter value  between [-1,1]");

                // re-read input:
                rho2 = Console.ReadLine();
                rho = Convert.ToDouble(rho2);

                // Return random numbers:
                jointnorm = outjoint.JointNormDistMethod(rho, e1, e2);
                Console.WriteLine("Joint normal random values output: " + jointnorm);

            }

            else
            {
                // Return random numbers:
                jointnorm = outjoint.JointNormDistMethod(rho, e1, e2);

                Console.WriteLine("Joint normal random values output: " + jointnorm);

            }


           /* Program outjoint = new Program();
            jointnorm = outjoint.JointNormDistMethod(rho, e1, e2);

            Console.WriteLine("Joint norm output: " + jointnorm); */


            // ---- Simple Approx Method ----

            Console.WriteLine("--- First, SIMPLE APPROX ---");
            Console.WriteLine("Press enter to generate random number");
            Console.ReadLine();


            //Declare variables and types
            double x1, x2, simpapprox_out; // boxm_out, min_r, max_r,;
            string boxm_out, polarm_out;
            //int k = 11;

            // Do simple approx
            Program simpapprox = new Program();
            simpapprox_out = simpapprox.SimpleApproxRandNum();

            Console.WriteLine("Simple Approx output: " + simpapprox_out);



            // ---- Box-Muller method: ----- 

            Console.WriteLine("--- Next, BOX-MULLER ---");
            Console.WriteLine("Press enter to generate random number");
            Console.ReadLine();

            // Generate random numbers for box-muller inputs ------
            // create new instance of class Random then load x1 and x2 with random numbers
            //Random newrnd = new Random();
            x1 = newrnd.NextDouble();
            x2 = newrnd.NextDouble();

            // Made BoxMullerMethod() an instance method (see p.50 of Accelerated C#), so need to declare new instance of Program class then call BoxMullerMethod using new instance:
            Program boxm = new Program();
            boxm_out = boxm.BoxMullerMethod(x1, x2);
            Console.WriteLine("Box Muller output: " + boxm_out);


           
           // ---- Polar Rejection Method ----
            Console.WriteLine("--- Next, POLAR REJECTION ---");
            Console.WriteLine("Press enter to generate random number");
            Console.ReadLine();

            Program polarm = new Program();
            polarm_out = polarm.PolarRejectMethod(x1, x2);
            Console.WriteLine("Polar Rejection output: " + polarm_out);


        
        }
    }
}





