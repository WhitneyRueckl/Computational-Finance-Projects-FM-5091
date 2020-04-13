using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Threading;

namespace Monte_Carlo_Pricer
{
    static class Program
    {


        static Form1 GUI = new Form1();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            Thread a1 = new Thread(new ThreadStart(RunGUI));

            Thread a2 = new Thread(new ThreadStart(FormCalc));
            a1.Start();
            a2.Start();


            a1.Join();
            a2.Join();


        }




        static void RunGUI()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(GUI);


        }





        public static void FormCalc()
        {
            Console.WriteLine("FormCalc()  ");
            int[,] abc = new int[5000, 5000];

            for (long c = 0; c < 5000; c++)
            {

                for (long a = 0; a < 5000; a++)
                {

                    for (long b = 0; b < 5000; b++) abc[a, b] = 50 * 50;

                }

                // f.label1.Text = c.ToString(); ---> this throw error, instead use Invoke()
                GUI.BeginInvoke(GUI.myDelegate);

            }

            return;
        }






    }
}
