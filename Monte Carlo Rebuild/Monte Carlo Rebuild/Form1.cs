using System;
using System.Windows.Forms;


namespace Monte_Carlo_Rebuild
{
    public partial class Form1 : Form
    {


        Other calc = new Other();

        OptionGreeks greek = new OptionGreeks();

        Builder build = new Builder();


        int progress = 0;

        public delegate void IncrementProgress();
        public IncrementProgress myDelegate;





        public Form1()
        {

            InitializeComponent();

            //myDelegate = new IncrementProgress(IncrementProgressMethod);


            // set default input values (this should price the option ~ $10.89)
            textBox_Spot.Text = "50";
            textBox_Strike.Text = "50";
            textBox_Rate.Text = "0.05";
            textBox_Tenor.Text = "1";
            textBox_Volatility.Text = "0.50";
            textBox_Drift.Text = "0.05";
            textBox_Steps.Text = "2";
            textBox_Trials.Text = "10000";
            textBox_Cores.Text = "8";

            comboBox1.Text = "Barrier";

            radioButton_Call.Checked = true;
            checkBox_VarReduc.Checked = true;
            checkBox_CV_VarReduc.Checked = false;
            checkBox_Multithread.Checked = true;


            comboBox_BarrierType.Text = "Down-In";
            textBox_BarrierPrice.Text = "40.00";

            comboBox_BarrierType.Visible = false;
            label_BarrierType.Visible = false;
            label_BarrierPrice.Visible = false;
            textBox_BarrierPrice.Visible = false;

            


        }


        public void IncrementProgressMethod()
        {
            if (progress < 100)
            {

                progress++;
                label_Progress.Text = progress.ToString();
                progressBar1.Value = progress;
            }
            else
            {
                progressBar1.Value = 100;
            }

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Spot_TextChanged(object sender, EventArgs e)
        {



        }

        private void button_GO_Click(object sender, EventArgs e)
        {


            // Reset the progress bar value with each click
            progress = 0;

            myDelegate = new IncrementProgress(IncrementProgressMethod);

            //Pass inputs from textboxes to IO class
            IO.SpotPrice = Convert.ToDouble(textBox_Spot.Text);
            IO.Rate = Convert.ToDouble(textBox_Rate.Text);
            IO.Vol = Convert.ToDouble(textBox_Volatility.Text);
            IO.Drift = Convert.ToDouble(textBox_Drift.Text);

            IO.OptionType = comboBox1.Text;
            IO.StrikePrice = Convert.ToDouble(textBox_Strike.Text);
            IO.Tenor = Convert.ToDouble(textBox_Tenor.Text);

            IO.N_Steps = Convert.ToInt32(textBox_Steps.Text);
            IO.Trials = Convert.ToInt32(textBox_Trials.Text);

            IO.Num_Cores = Convert.ToInt32(textBox_Cores.Text);

            
            if(IO.OptionType == "Barrier")
            {

                comboBox_BarrierType.Visible = true;
                label_BarrierType.Visible = true;
                label_BarrierPrice.Visible = true;
                textBox_BarrierPrice.Visible = true;

                IO.BarrierType = comboBox_BarrierType.Text;
                IO.BarrierPrice = Convert.ToDouble(textBox_BarrierPrice.Text);

            }
            else
            {

                comboBox_BarrierType.Visible = false;
                label_BarrierType.Visible = false;
                label_BarrierPrice.Visible = false;
                textBox_BarrierPrice.Visible = false;

            }


            //comboBox1_SelectedIndexChanged();

            // Determine if put or call 
            if (radioButton_Call.Checked)
            {

                IO.IsPut = false;

            }
            else if (radioButton_Put.Checked)
            {
                IO.IsPut = true;

            }



            // Determine if varaiance reduction is requested and assign bool to Var_Reduc
            // note - if I remove this code below it doesn't seem to matter as long as I have the private void
            // called checkBox_VarReduc_CheckedChanged (below).....???
            if (checkBox_VarReduc.Checked)
            {

                IO.Var_Reduc = true;

            }
            else
            {
                IO.Var_Reduc = false;

            }



            //Thread C = new Thread(new ThreadStart(IO.getResults));
            //C.Start();

            Builder build = new Builder();
            build.generateResults();

            
            textBox_OptionPrice.Text = Convert.ToString(IO.O_Price);
            textBox_Delta.Text = Convert.ToString(IO.O_Delta);
            textBox_Gamma.Text = Convert.ToString(IO.O_Gamma);
            textBox_Theta.Text = Convert.ToString(IO.O_Theta);
            textBox_Vega.Text = Convert.ToString(IO.O_Vega);
            textBox_Rho.Text = Convert.ToString(IO.O_Rho);

            textBox_StdErr.Text = Convert.ToString(IO.O_StdErr);

            textBox_Timer.Text = Convert.ToString(IO.Timer);
            


        }

        private void checkBox_VarReduc_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_VarReduc.Checked)
            {

                IO.Var_Reduc = true;

            }
            else //if (checkBox_VarReduc.Checked)
            {
                IO.Var_Reduc = false;

            }


        }


        private void checkBox_CV_VarReduc_CheckedChanged(object sender, EventArgs e)
        {


            if (checkBox_CV_VarReduc.Checked)
            {

                IO.CV_Var_Reduc = true;

            }
            else //if (checkBox_CV_VarReduc.Checked)
            {
                IO.CV_Var_Reduc = false;

            }


        }


        private void checkBox_Multithread_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_Multithread.Checked)
            {
                IO.Multithread = true;
                IO.Num_Cores = Convert.ToInt32(textBox_Cores.Text);
            }
            else
            {
                IO.Multithread = false;
                IO.Num_Cores = 1;
            }

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (IO.OptionType == "Barrier")
            {

                comboBox_BarrierType.Visible = true;
                label_BarrierType.Visible = true;
                label_BarrierPrice.Visible = true;
                textBox_BarrierPrice.Visible = true;

                IO.BarrierType = comboBox_BarrierType.Text;
                IO.BarrierPrice = Convert.ToDouble(textBox_BarrierPrice.Text);

            }
            else
            {

                comboBox_BarrierType.Visible = false;
                label_BarrierType.Visible = false;
                label_BarrierPrice.Visible = false;
                textBox_BarrierPrice.Visible = false;

            }


        }
    }

}
