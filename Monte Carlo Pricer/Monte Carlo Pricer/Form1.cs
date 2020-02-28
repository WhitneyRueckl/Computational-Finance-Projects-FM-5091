using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monte_Carlo_Pricer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox_Spot.Text = "50";
            textBox_Strike.Text = "50";
            textBox_Rate.Text = "0.05";
            textBox_Tenor.Text = "1";
            textBox_Volatility.Text = "0.50";
            textBox_Drift.Text = "0.05";
            textBox_Steps.Text = "2";
            textBox_Trials.Text = "100000";

            radioButton_Call.Checked = true;
        }




        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Spot_TextChanged(object sender, EventArgs e)
        {



        }

        private void button_GO_Click(object sender, EventArgs e)
        {

            //Pass inputs from textboxes to InputOutput class
            InputOutput.SpotPrice = Convert.ToDouble(textBox_Spot.Text);
            InputOutput.StrikePrice = Convert.ToDouble(textBox_Strike.Text);
            InputOutput.Rate = Convert.ToDouble(textBox_Rate.Text);
            InputOutput.Vol = Convert.ToDouble(textBox_Volatility.Text);
            InputOutput.Drift = Convert.ToDouble(textBox_Drift.Text);
            InputOutput.Tenor = Convert.ToDouble(textBox_Tenor.Text);

            InputOutput.N_Steps = Convert.ToInt32(textBox_Steps.Text);
            InputOutput.Trials = Convert.ToInt32(textBox_Trials.Text);



            if (radioButton_Call.Checked)
            {

                InputOutput.PutCall = 0;

            }
            else if (radioButton_Put.Checked)
            {
                InputOutput.PutCall = 1;

            }


            InputOutput.getResults();

            textBox_OptionPrice.Text = Convert.ToString(InputOutput.O_Price);
            textBox_Delta.Text = Convert.ToString(InputOutput.O_Delta);
            textBox_Gamma.Text = Convert.ToString(InputOutput.O_Gamma);
            textBox_Theta.Text = Convert.ToString(InputOutput.O_Theta);
            textBox_Vega.Text = Convert.ToString(InputOutput.O_Vega);
            textBox_Rho.Text = Convert.ToString(InputOutput.O_Rho);

            textBox_StdErr.Text = Convert.ToString(InputOutput.O_StdErr);



        }


    }

}
