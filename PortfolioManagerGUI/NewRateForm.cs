using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
//using System.Data.DataSetExtenstions;
using System.Data.SqlClient;
using Portfolio_Manager_Main;
using System.Data.Entity;

namespace PortfolioManagerGUI
{
    public partial class NewRateForm : Form
    {
        public NewRateForm()
        {
            InitializeComponent();
            RatesQuery();
        }



        private void RatesQuery()
        {

            var context = new PortfolioDataModelContainer();

            var dataList = context.InterestRates.ToList();
            var query = (from r in dataList.AsEnumerable()
                         select new { r.Tenor, r.Rate }).ToList();

            dataGridView_Rates.DataSource = query;


        }

        private void button_SaveNewRate_Click(object sender, EventArgs e)
        {
            using (var context = new Portfolio_Manager_Main.PortfolioDataModelContainer())
            {


                var inst = new InterestRates()
                {
                    Tenor = Convert.ToInt32(numericUpDown_Tenor.Value),
                    Rate = Convert.ToInt32(textBox_NewRate.Text)
                    

                    // if(comboBox_TickersForHistPrice.Text)
                };

                context.InterestRates.Add(inst);
                context.SaveChanges();

            }

            RatesQuery();

        }
    }
}
