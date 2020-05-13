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
using System.Data.SqlClient;
using Portfolio_Manager_Main;
using System.Data.Entity;

namespace PortfolioManagerGUI
{
    public partial class NewTradeForm : Form
    {
        public NewTradeForm()
        {
            InitializeComponent();

            label_TodaysDate.Text = Convert.ToString(DateTime.Now);
            dataGridView_NewTradesEntry.EditMode = DataGridViewEditMode.EditOnEnter;
          

        }


        /*
        private void UpdateTickerList()
        {

            
            comboBox_Tickers.Items.Add()


        }
        */



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_AddTrades_Click(object sender, EventArgs e)
        {

            bool isbuy_tag = true;

            if(comboBox_BuySell.Text == "BUY")
            {
                isbuy_tag = true;
            }
            else if(comboBox_BuySell.Text == "SELL")
            {
                isbuy_tag = false;
            }


            using (var context = new Portfolio_Manager_Main.PortfolioDataModelContainer())
            {


                int inst_id = context.Instruments.Max(i => i.Id);
                    
                    //(from i in context.Instruments where i.Id.Max().ToList();


                context.Trades.Add(new Trades()
                {
                    IsBuy = Convert.ToBoolean(isbuy_tag),
                    Ticker = Convert.ToString(comboBox_Tickers.SelectedItem),
                    Quantity = Convert.ToInt32(textBox_Quantity.Text),
                    TradePrice = Convert.ToDouble(textBox_TradePrice.Text),
                    TradeDate = Convert.ToDateTime(label_TodaysDate.Text),
                    InstrumentId = Convert.ToInt32(inst_id)

                });


                context.SaveChanges();

            }



        }
    }
}
