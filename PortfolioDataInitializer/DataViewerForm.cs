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
using Portfolio_Manager_Main;

namespace PortfolioDataInitializer
{
    public partial class DataViewerForm : Form
    {
        
        string filePath = "C:/Users/whitn/OneDrive/Documents/School/FM 5092/Projects/Portfolio_Manager_Main/Portfolio_Instruments_Import.csv";

      

        DataTable dt;


        public DataViewerForm()
        {
            InitializeComponent();

            
        }



        private void button1_Click(object sender, EventArgs e)
        {
            // Read CSV data and show in data grid view
            ShowDataTable(filePath);

          

        }

        private void button2_Click(object sender, EventArgs e)
        {

            WriteDataToDb(filePath);

        }


        private void ShowDataTable(string filePath)
        {
            // **** Target file MUST BE IN CSV FORMAT for this to work --> because using lines.Split(',')) ****

            //Console.WriteLine("Creating DataTable form text file: ");


            DataTable tbl = new DataTable();

            string[] lines = File.ReadAllLines(filePath);
            lines = lines.Skip(1).ToArray();

            //Number of rows including header
            var numRows = lines.Count();

            //Number of rows columns
            var numCols = lines[0].Split(',').Count();

            for (int col = 0; col < numCols; col++)
                tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));


            foreach (string line in lines)
            {
                var cols = line.Split(',');

                DataRow dr = tbl.NewRow();

                for (int cIndex = 0; cIndex < numCols; cIndex++)
                {

                    //Console.WriteLine("cIndex : " + cIndex);
                    dr[cIndex] = cols[cIndex];

                    //Console.ReadLine();

                }

                tbl.Rows.Add(dr);
            }

            dataGridView1.DataSource = tbl;

            //return tbl;


        }


        private void WriteDataToDb(string filePath)
        {

            string[] lines = File.ReadAllLines(filePath);
            lines = lines.Skip(1).ToArray();

            //Number of rows including header
            var rows = lines.Count();

            //Number of rows columns
            var cols = lines[0].Split(',').Count();
            //Console.WriteLine("Number of rows =  " + rows + "Number of columns = " + cols);


            foreach (string row in lines)
            {

                string[] values = row.Split(',').ToArray();

                using (var context = new Portfolio_Manager_Main.PortfolioDataModelContainer())
                {
                    ///var inst = new Instrument() { CompanyName = "The Trade Desk", Ticker = "TTD", Price = 319, InstrType = "Stock" };

                    var inst = new Instrument()
                    {
                        CompanyName = values[0],
                        Ticker = values[1],
                        Exchange = values[2],
                        InstrumentTypeId = Convert.ToInt32(values[3])
                    };

                    context.Instruments.Add(inst);
                    context.SaveChanges();

                }


            }




        }




        private void WriteDataToDb2(string filePath)
        {

            string[] lines = File.ReadAllLines(filePath);
            lines = lines.Skip(1).ToArray();

            //Number of rows including header
            var rows = lines.Count();

            //Number of rows columns
            var cols = lines[0].Split(',').Count();
            //Console.WriteLine("Number of rows =  " + rows + "Number of columns = " + cols);


            foreach (string row in lines)
            {

                string[] values = row.Split(',').ToArray();

                using (var context = new Portfolio_Manager_Main.PortfolioDataModelContainer())
                {
                    ///var inst = new Instrument() { CompanyName = "The Trade Desk", Ticker = "TTD", Price = 319, InstrType = "Stock" };

                    var inst = new InstrumentType()
                    {
                        TypeName = values[0],
                    };

                    context.InstrumentTypes.Add(inst);
                    context.SaveChanges();

                }


            }




        }














    }
}
