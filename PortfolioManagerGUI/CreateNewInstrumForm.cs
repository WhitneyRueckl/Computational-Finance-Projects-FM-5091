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
    public partial class CreateNewInstrumForm : Form
    {

       

        public CreateNewInstrumForm()
        {
            InitializeComponent();
            //radioButton_NewCall.CheckedChanged += radioButton_NewCall_CheckedChanged;

            

        }



        private void button_AddNewInstr_Click(object sender, EventArgs e)
        {

            string inst_type = comboBox_InstrTypeNewInstrum.Text;

            label_InstTypeId.Text = Convert.ToString(assignInstTypeId(inst_type));

            if (radioButton_NewCall.Checked)
            {
                label_IsPut.Text = "0";

            }
            else if(radioButton_NewPut.Checked)
            {
                label_IsPut.Text = "1";
            }


            AddNewInstrToDb();

        }



        private void AddNewInstrToDb()
        {

            using (var context = new Portfolio_Manager_Main.PortfolioDataModelContainer())
            {
                ///var inst = new Instrument() { CompanyName = "The Trade Desk", Ticker = "TTD", Price = 319, InstrType = "Stock" };                

                int instype_id = 0;

               

                if (comboBox_InstrTypeNewInstrum.Text == "Stock")
                {
                    instype_id = 14;

                    context.Instruments.Add(new Instrument()
                    {
                        CompanyName = textBox_CompName.Text,
                        Ticker = textBox_Ticker.Text,
                        Exchange = textBox_Exchange.Text,
                        InstrumentTypeId = Convert.ToInt32(label_InstTypeId.Text),
                    


                    });

                }
                else if (comboBox_InstrTypeNewInstrum.Text == "EuropeanOption")
                {
                    instype_id = 15;


                    context.Instruments.Add(new EuropeanOption()
                    {
                        CompanyName = textBox_CompName.Text,
                        Ticker = textBox_Ticker.Text,
                        Exchange = textBox_Exchange.Text,
                        InstrumentTypeId = Convert.ToInt32(instype_id),
                        Strike = Convert.ToDouble(textBox_Strike.Text),
                        Tenor = Convert.ToInt32(textBox_Tenor.Text),
                        IsPut = Convert.ToBoolean(Convert.ToInt32(label_IsPut.Text))
                        

                    });


                }
                else if (comboBox_InstrTypeNewInstrum.Text == "AsianOption")
                {
                    instype_id = 16;

                    context.Instruments.Add(new AsianOption()
                    {
                        CompanyName = textBox_CompName.Text,
                        Ticker = textBox_Ticker.Text,
                        Exchange = textBox_Exchange.Text,
                        InstrumentTypeId = Convert.ToInt32(instype_id),
                        Strike = Convert.ToDouble(textBox_Strike.Text),
                        Tenor = Convert.ToInt32(textBox_Tenor.Text),
                        IsPut = Convert.ToBoolean(Convert.ToInt32(label_IsPut.Text))


                    });


                }
                else if (comboBox_InstrTypeNewInstrum.Text == "LookbackOption")
                {
                    instype_id = 17;


                    context.Instruments.Add(new LookbackOption()
                    {
                        CompanyName = textBox_CompName.Text,
                        Ticker = textBox_Ticker.Text,
                        Exchange = textBox_Exchange.Text,
                        InstrumentTypeId = Convert.ToInt32(instype_id),
                        Strike = Convert.ToDouble(textBox_Strike.Text),
                        Tenor = Convert.ToInt32(textBox_Tenor.Text),
                        IsPut = Convert.ToBoolean(Convert.ToInt32(label_IsPut.Text))


                    });


                }
                else if (comboBox_InstrTypeNewInstrum.Text == "DigitalOption")
                {
                    instype_id = 18;


                    context.Instruments.Add(new DigitalOption()
                    {
                        CompanyName = textBox_CompName.Text,
                        Ticker = textBox_Ticker.Text,
                        Exchange = textBox_Exchange.Text,
                        InstrumentTypeId = Convert.ToInt32(instype_id),
                        Strike = Convert.ToDouble(textBox_Strike.Text),
                        Tenor = Convert.ToInt32(textBox_Tenor.Text),
                        IsPut = Convert.ToBoolean(Convert.ToInt32(label_IsPut.Text)),
                        Rebate = 5


                    });

                }
                else if (comboBox_InstrTypeNewInstrum.Text == "RangeOption")
                {
                    instype_id = 19;

                    context.Instruments.Add(new RangeOption()
                    {
                        CompanyName = textBox_CompName.Text,
                        Ticker = textBox_Ticker.Text,
                        Exchange = textBox_Exchange.Text,
                        InstrumentTypeId = Convert.ToInt32(instype_id),
                        Strike = Convert.ToDouble(textBox_Strike.Text),
                        Tenor = Convert.ToInt32(textBox_Tenor.Text),
                        IsPut = Convert.ToBoolean(Convert.ToInt32(label_IsPut.Text))


                    });

                }
                else if (comboBox_InstrTypeNewInstrum.Text == "BarrierOption")
                {
                    instype_id = 20;

                    context.Instruments.Add(new BarrierOption()
                    {
                        CompanyName = textBox_CompName.Text,
                        Ticker = textBox_Ticker.Text,
                        Exchange = textBox_Exchange.Text,
                        InstrumentTypeId = Convert.ToInt32(instype_id),
                        Strike = Convert.ToDouble(textBox_Strike.Text),
                        Tenor = Convert.ToInt32(textBox_Tenor.Text),
                        IsPut = Convert.ToBoolean(Convert.ToInt32(label_IsPut.Text)),
                        BarrierTypeId = Convert.ToInt32((comboBox_BarrierTypes.Text))


                    });


                }


               
                context.SaveChanges();

                MessageBox.Show("Instrument with ticker: " + textBox_Ticker.Text + ", of type: " +
                                    comboBox_InstrTypeNewInstrum.Text + "  has been saved to db");

                /*
                var inst = new Instrument()
                {
                    CompanyName = textBox_CompName.Text,
                    Ticker = textBox_Ticker.Text,
                    Exchange = textBox_Exchange.Text,
                    InstrumentTypeId = Convert.ToInt32(label_InstTypeId.Text)


                };

                var opt_inst = new EuropeanOption()
                {
                    Strike = Convert.ToDouble(textBox_Strike.Text),
                    Tenor = Convert.ToInt32(textBox_Tenor.Text),
                    IsPut = Convert.ToBoolean(Convert.ToInt32(label_IsPut.Text))

                    
                };
                */


                //context.Instruments.Add(inst);

                //context.Instruments.Add(new EuropeanOption(opt_inst)); // <--- This doesn't work.
                //context.SaveChanges();

            }


        }









        private int assignInstTypeId(string inst_type)
        {

            int instype_id = 0;


            if (comboBox_InstrTypeNewInstrum.Text == "Stock")
            {
                instype_id = 14;
            }
            else if (comboBox_InstrTypeNewInstrum.Text == "EuropeanOption")
            {
                instype_id = 15;
            }
            else if(comboBox_InstrTypeNewInstrum.Text == "AsianOption")
            {
                instype_id = 16;

            }
            else if (comboBox_InstrTypeNewInstrum.Text == "LookbackOption")
            {
                instype_id = 17;

            }
            else if (comboBox_InstrTypeNewInstrum.Text == "DigitalOption")
            {
                instype_id = 18;

            }
            else if (comboBox_InstrTypeNewInstrum.Text == "RangeOption")
            {
                instype_id = 19;

            }
            else if (comboBox_InstrTypeNewInstrum.Text == "BarrierOption")
            {
                instype_id = 20;

            }

            return instype_id;


        }

        
        private void radioButton_NewCall_CheckedChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("Call radio button changed!");
        }
        
    }
}
