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
    public partial class NewHistPriceForm : Form
    {
        public NewHistPriceForm()
        {
            InitializeComponent();
            PricesQuery();

        }



        private void PricesQuery()
        {
            
            var context = new PortfolioDataModelContainer();

            var dataList = context.Prices.ToList();
            var query = (from p in dataList.AsEnumerable()
                         select new { p.AsOfDate, p.ClosingPrice}).ToList();

            dataGridView_HistPrices.DataSource = query;


        }

        private void button_AddNewPricesToDb_Click(object sender, EventArgs e)
        {

            int inst_id = 0;//assignInstrId();


            using (var context = new Portfolio_Manager_Main.PortfolioDataModelContainer())
            {

                var iid = (from i in context.Instruments select i.Id).ToList();
                inst_id = Convert.ToInt32(Convert.ToString((iid.Max() + 1)));

                var inst = new Prices()
                {
                    AsOfDate = Convert.ToDateTime(dateTimePicker_HistPrices.Value),
                    ClosingPrice = Convert.ToDouble(textBox_NewPrice.Text),
                    InstrumentId = inst_id

                   // if(comboBox_TickersForHistPrice.Text)
                };

                context.Prices.Add(inst);
                context.SaveChanges();

            }

            PricesQuery();


        }



        private int assignInstrId()
        {

            int inst_id = 0;

            if (comboBox_TickersForHistPrice.Text == "AAPL")
            {

                inst_id = 20;


            }
            if (comboBox_TickersForHistPrice.Text == "NVDA")
            {

                inst_id = 21;


            }
            if (comboBox_TickersForHistPrice.Text == "TTD")
            {

                inst_id = 22;


            }
            if (comboBox_TickersForHistPrice.Text == "FB")
            {

                inst_id = 23;


            }
            if (comboBox_TickersForHistPrice.Text == "AMZN")
            {

                inst_id = 24;


            }

            return inst_id;

        }



    }
}
