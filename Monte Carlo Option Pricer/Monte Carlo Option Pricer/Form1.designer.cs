namespace Monte_Carlo_Option_Pricer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButton_Put = new System.Windows.Forms.RadioButton();
            this.button_Go = new System.Windows.Forms.Button();
            this.radioButton_Call = new System.Windows.Forms.RadioButton();
            this.textBox_OptionPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Delta = new System.Windows.Forms.TextBox();
            this.textBox_Gamma = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Gamma = new System.Windows.Forms.Label();
            this.textBox_Theta = new System.Windows.Forms.TextBox();
            this.label_Theta = new System.Windows.Forms.Label();
            this.label_Vega = new System.Windows.Forms.Label();
            this.textBox_Vega = new System.Windows.Forms.TextBox();
            this.label_StdErr = new System.Windows.Forms.Label();
            this.textBox_StdErr = new System.Windows.Forms.TextBox();
            this.label_Rho = new System.Windows.Forms.Label();
            this.textBox_Rho = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox_Timer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label_Progress = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Inputs = new System.Windows.Forms.Label();
            this.label_Drift = new System.Windows.Forms.Label();
            this.textBox_Drift = new System.Windows.Forms.TextBox();
            this.label_Steps = new System.Windows.Forms.Label();
            this.label_Spot = new System.Windows.Forms.Label();
            this.label_Trials = new System.Windows.Forms.Label();
            this.label_Vol = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_Tenor = new System.Windows.Forms.Label();
            this.label_Rate = new System.Windows.Forms.Label();
            this.textBox_Spot = new System.Windows.Forms.TextBox();
            this.checkBox_VarReduc = new System.Windows.Forms.CheckBox();
            this.textBox_Trials = new System.Windows.Forms.TextBox();
            this.textBox_Cores = new System.Windows.Forms.TextBox();
            this.textBox_Volatility = new System.Windows.Forms.TextBox();
            this.label_Strike = new System.Windows.Forms.Label();
            this.checkBox_CV_VarReduc = new System.Windows.Forms.CheckBox();
            this.textBox_Rate = new System.Windows.Forms.TextBox();
            this.checkBox_Multithread = new System.Windows.Forms.CheckBox();
            this.textBox_Tenor = new System.Windows.Forms.TextBox();
            this.textBox_Steps = new System.Windows.Forms.TextBox();
            this.textBox_Strike = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton_Put
            // 
            this.radioButton_Put.AutoSize = true;
            this.radioButton_Put.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Put.ForeColor = System.Drawing.Color.White;
            this.radioButton_Put.Location = new System.Drawing.Point(120, 273);
            this.radioButton_Put.Name = "radioButton_Put";
            this.radioButton_Put.Size = new System.Drawing.Size(45, 20);
            this.radioButton_Put.TabIndex = 9;
            this.radioButton_Put.TabStop = true;
            this.radioButton_Put.Text = "Put";
            this.radioButton_Put.UseVisualStyleBackColor = true;
            // 
            // button_Go
            // 
            this.button_Go.BackColor = System.Drawing.SystemColors.Control;
            this.button_Go.FlatAppearance.BorderSize = 0;
            this.button_Go.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Go.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Go.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Go.Location = new System.Drawing.Point(48, 463);
            this.button_Go.Name = "button_Go";
            this.button_Go.Size = new System.Drawing.Size(185, 44);
            this.button_Go.TabIndex = 11;
            this.button_Go.Text = "GO";
            this.button_Go.UseVisualStyleBackColor = false;
            this.button_Go.Click += new System.EventHandler(this.button_GO_Click);
            // 
            // radioButton_Call
            // 
            this.radioButton_Call.AutoSize = true;
            this.radioButton_Call.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Call.ForeColor = System.Drawing.Color.White;
            this.radioButton_Call.Location = new System.Drawing.Point(31, 273);
            this.radioButton_Call.Name = "radioButton_Call";
            this.radioButton_Call.Size = new System.Drawing.Size(49, 20);
            this.radioButton_Call.TabIndex = 12;
            this.radioButton_Call.TabStop = true;
            this.radioButton_Call.Text = "Call";
            this.radioButton_Call.UseVisualStyleBackColor = true;
            // 
            // textBox_OptionPrice
            // 
            this.textBox_OptionPrice.Location = new System.Drawing.Point(851, 64);
            this.textBox_OptionPrice.Name = "textBox_OptionPrice";
            this.textBox_OptionPrice.Size = new System.Drawing.Size(100, 20);
            this.textBox_OptionPrice.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(755, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "Pricing Ouput:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(755, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Option Price";
            // 
            // textBox_Delta
            // 
            this.textBox_Delta.Location = new System.Drawing.Point(851, 108);
            this.textBox_Delta.Name = "textBox_Delta";
            this.textBox_Delta.Size = new System.Drawing.Size(100, 20);
            this.textBox_Delta.TabIndex = 24;
            // 
            // textBox_Gamma
            // 
            this.textBox_Gamma.Location = new System.Drawing.Point(851, 147);
            this.textBox_Gamma.Name = "textBox_Gamma";
            this.textBox_Gamma.Size = new System.Drawing.Size(100, 20);
            this.textBox_Gamma.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(755, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Delta";
            // 
            // label_Gamma
            // 
            this.label_Gamma.AutoSize = true;
            this.label_Gamma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Gamma.Location = new System.Drawing.Point(755, 147);
            this.label_Gamma.Name = "label_Gamma";
            this.label_Gamma.Size = new System.Drawing.Size(56, 16);
            this.label_Gamma.TabIndex = 27;
            this.label_Gamma.Text = "Gamma";
            // 
            // textBox_Theta
            // 
            this.textBox_Theta.Location = new System.Drawing.Point(851, 188);
            this.textBox_Theta.Name = "textBox_Theta";
            this.textBox_Theta.Size = new System.Drawing.Size(100, 20);
            this.textBox_Theta.TabIndex = 30;
            // 
            // label_Theta
            // 
            this.label_Theta.AutoSize = true;
            this.label_Theta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Theta.Location = new System.Drawing.Point(755, 196);
            this.label_Theta.Name = "label_Theta";
            this.label_Theta.Size = new System.Drawing.Size(43, 16);
            this.label_Theta.TabIndex = 32;
            this.label_Theta.Text = "Theta";
            // 
            // label_Vega
            // 
            this.label_Vega.AutoSize = true;
            this.label_Vega.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Vega.Location = new System.Drawing.Point(757, 235);
            this.label_Vega.Name = "label_Vega";
            this.label_Vega.Size = new System.Drawing.Size(41, 16);
            this.label_Vega.TabIndex = 33;
            this.label_Vega.Text = "Vega";
            // 
            // textBox_Vega
            // 
            this.textBox_Vega.Location = new System.Drawing.Point(851, 231);
            this.textBox_Vega.Name = "textBox_Vega";
            this.textBox_Vega.Size = new System.Drawing.Size(100, 20);
            this.textBox_Vega.TabIndex = 34;
            // 
            // label_StdErr
            // 
            this.label_StdErr.AutoSize = true;
            this.label_StdErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_StdErr.Location = new System.Drawing.Point(755, 321);
            this.label_StdErr.Name = "label_StdErr";
            this.label_StdErr.Size = new System.Drawing.Size(60, 16);
            this.label_StdErr.TabIndex = 35;
            this.label_StdErr.Text = "Std Error";
            // 
            // textBox_StdErr
            // 
            this.textBox_StdErr.Location = new System.Drawing.Point(851, 321);
            this.textBox_StdErr.Name = "textBox_StdErr";
            this.textBox_StdErr.Size = new System.Drawing.Size(100, 20);
            this.textBox_StdErr.TabIndex = 36;
            // 
            // label_Rho
            // 
            this.label_Rho.AutoSize = true;
            this.label_Rho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Rho.Location = new System.Drawing.Point(755, 277);
            this.label_Rho.Name = "label_Rho";
            this.label_Rho.Size = new System.Drawing.Size(33, 16);
            this.label_Rho.TabIndex = 37;
            this.label_Rho.Text = "Rho";
            // 
            // textBox_Rho
            // 
            this.textBox_Rho.Location = new System.Drawing.Point(851, 276);
            this.textBox_Rho.Name = "textBox_Rho";
            this.textBox_Rho.Size = new System.Drawing.Size(100, 20);
            this.textBox_Rho.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 40;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(225, 73);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(193, 23);
            this.progressBar1.TabIndex = 42;
            // 
            // textBox_Timer
            // 
            this.textBox_Timer.Location = new System.Drawing.Point(225, 35);
            this.textBox_Timer.Name = "textBox_Timer";
            this.textBox_Timer.Size = new System.Drawing.Size(100, 20);
            this.textBox_Timer.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Run time";
            // 
            // label_Progress
            // 
            this.label_Progress.AutoSize = true;
            this.label_Progress.Location = new System.Drawing.Point(161, 83);
            this.label_Progress.Name = "label_Progress";
            this.label_Progress.Size = new System.Drawing.Size(13, 13);
            this.label_Progress.TabIndex = 49;
            this.label_Progress.Text = "0";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1086, 555);
            this.tabControl1.TabIndex = 50;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.textBox_Rho);
            this.tabPage1.Controls.Add(this.label_Rho);
            this.tabPage1.Controls.Add(this.textBox_StdErr);
            this.tabPage1.Controls.Add(this.label_StdErr);
            this.tabPage1.Controls.Add(this.textBox_Vega);
            this.tabPage1.Controls.Add(this.label_Vega);
            this.tabPage1.Controls.Add(this.label_Theta);
            this.tabPage1.Controls.Add(this.textBox_Theta);
            this.tabPage1.Controls.Add(this.label_Gamma);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox_Gamma);
            this.tabPage1.Controls.Add(this.textBox_Delta);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox_OptionPrice);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1078, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label_Inputs);
            this.panel1.Controls.Add(this.label_Drift);
            this.panel1.Controls.Add(this.textBox_Drift);
            this.panel1.Controls.Add(this.label_Spot);
            this.panel1.Controls.Add(this.label_Vol);
            this.panel1.Controls.Add(this.label_Tenor);
            this.panel1.Controls.Add(this.label_Rate);
            this.panel1.Controls.Add(this.textBox_Spot);
            this.panel1.Controls.Add(this.textBox_Volatility);
            this.panel1.Controls.Add(this.label_Strike);
            this.panel1.Controls.Add(this.textBox_Rate);
            this.panel1.Controls.Add(this.textBox_Tenor);
            this.panel1.Controls.Add(this.radioButton_Call);
            this.panel1.Controls.Add(this.textBox_Strike);
            this.panel1.Controls.Add(this.radioButton_Put);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 531);
            this.panel1.TabIndex = 51;
            // 
            // label_Inputs
            // 
            this.label_Inputs.AutoSize = true;
            this.label_Inputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Inputs.ForeColor = System.Drawing.Color.White;
            this.label_Inputs.Location = new System.Drawing.Point(27, 25);
            this.label_Inputs.Name = "label_Inputs";
            this.label_Inputs.Size = new System.Drawing.Size(211, 18);
            this.label_Inputs.TabIndex = 21;
            this.label_Inputs.Text = "Enter Pricing Inputs Below:";
            // 
            // label_Drift
            // 
            this.label_Drift.AutoSize = true;
            this.label_Drift.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Drift.ForeColor = System.Drawing.Color.White;
            this.label_Drift.Location = new System.Drawing.Point(30, 224);
            this.label_Drift.Name = "label_Drift";
            this.label_Drift.Size = new System.Drawing.Size(31, 16);
            this.label_Drift.TabIndex = 29;
            this.label_Drift.Text = "Drift";
            // 
            // textBox_Drift
            // 
            this.textBox_Drift.Location = new System.Drawing.Point(194, 223);
            this.textBox_Drift.Name = "textBox_Drift";
            this.textBox_Drift.Size = new System.Drawing.Size(100, 20);
            this.textBox_Drift.TabIndex = 28;
            // 
            // label_Steps
            // 
            this.label_Steps.AutoSize = true;
            this.label_Steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Steps.ForeColor = System.Drawing.Color.White;
            this.label_Steps.Location = new System.Drawing.Point(19, 102);
            this.label_Steps.Name = "label_Steps";
            this.label_Steps.Size = new System.Drawing.Size(117, 16);
            this.label_Steps.TabIndex = 20;
            this.label_Steps.Text = "# of Steps in Paths";
            // 
            // label_Spot
            // 
            this.label_Spot.AutoSize = true;
            this.label_Spot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Spot.ForeColor = System.Drawing.Color.White;
            this.label_Spot.Location = new System.Drawing.Point(27, 71);
            this.label_Spot.Name = "label_Spot";
            this.label_Spot.Size = new System.Drawing.Size(138, 16);
            this.label_Spot.TabIndex = 14;
            this.label_Spot.Text = "Underlying Spot Price";
            // 
            // label_Trials
            // 
            this.label_Trials.AutoSize = true;
            this.label_Trials.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Trials.ForeColor = System.Drawing.Color.White;
            this.label_Trials.Location = new System.Drawing.Point(19, 70);
            this.label_Trials.Name = "label_Trials";
            this.label_Trials.Size = new System.Drawing.Size(92, 16);
            this.label_Trials.TabIndex = 19;
            this.label_Trials.Text = "# of Sim Trials";
            // 
            // label_Vol
            // 
            this.label_Vol.AutoSize = true;
            this.label_Vol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Vol.ForeColor = System.Drawing.Color.White;
            this.label_Vol.Location = new System.Drawing.Point(30, 190);
            this.label_Vol.Name = "label_Vol";
            this.label_Vol.Size = new System.Drawing.Size(58, 16);
            this.label_Vol.TabIndex = 18;
            this.label_Vol.Text = "Volatility";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(135, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "# of Cores";
            // 
            // label_Tenor
            // 
            this.label_Tenor.AutoSize = true;
            this.label_Tenor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Tenor.ForeColor = System.Drawing.Color.White;
            this.label_Tenor.Location = new System.Drawing.Point(28, 130);
            this.label_Tenor.Name = "label_Tenor";
            this.label_Tenor.Size = new System.Drawing.Size(44, 16);
            this.label_Tenor.TabIndex = 17;
            this.label_Tenor.Text = "Tenor";
            // 
            // label_Rate
            // 
            this.label_Rate.AutoSize = true;
            this.label_Rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Rate.ForeColor = System.Drawing.Color.White;
            this.label_Rate.Location = new System.Drawing.Point(30, 159);
            this.label_Rate.Name = "label_Rate";
            this.label_Rate.Size = new System.Drawing.Size(90, 16);
            this.label_Rate.TabIndex = 16;
            this.label_Rate.Text = "Riskfree Rate";
            // 
            // textBox_Spot
            // 
            this.textBox_Spot.Location = new System.Drawing.Point(194, 69);
            this.textBox_Spot.Name = "textBox_Spot";
            this.textBox_Spot.Size = new System.Drawing.Size(100, 20);
            this.textBox_Spot.TabIndex = 0;
            this.textBox_Spot.TextChanged += new System.EventHandler(this.textBox_Spot_TextChanged);
            // 
            // checkBox_VarReduc
            // 
            this.checkBox_VarReduc.AutoSize = true;
            this.checkBox_VarReduc.ForeColor = System.Drawing.Color.White;
            this.checkBox_VarReduc.Location = new System.Drawing.Point(22, 150);
            this.checkBox_VarReduc.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_VarReduc.Name = "checkBox_VarReduc";
            this.checkBox_VarReduc.Size = new System.Drawing.Size(120, 17);
            this.checkBox_VarReduc.TabIndex = 39;
            this.checkBox_VarReduc.Text = "Variance Reduction";
            this.checkBox_VarReduc.UseVisualStyleBackColor = true;
            this.checkBox_VarReduc.CheckedChanged += new System.EventHandler(this.checkBox_VarReduc_CheckedChanged);
            // 
            // textBox_Trials
            // 
            this.textBox_Trials.Location = new System.Drawing.Point(165, 69);
            this.textBox_Trials.Name = "textBox_Trials";
            this.textBox_Trials.Size = new System.Drawing.Size(100, 20);
            this.textBox_Trials.TabIndex = 10;
            // 
            // textBox_Cores
            // 
            this.textBox_Cores.Location = new System.Drawing.Point(207, 223);
            this.textBox_Cores.Name = "textBox_Cores";
            this.textBox_Cores.Size = new System.Drawing.Size(53, 20);
            this.textBox_Cores.TabIndex = 47;
            // 
            // textBox_Volatility
            // 
            this.textBox_Volatility.Location = new System.Drawing.Point(194, 190);
            this.textBox_Volatility.Name = "textBox_Volatility";
            this.textBox_Volatility.Size = new System.Drawing.Size(100, 20);
            this.textBox_Volatility.TabIndex = 4;
            // 
            // label_Strike
            // 
            this.label_Strike.AutoSize = true;
            this.label_Strike.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Strike.ForeColor = System.Drawing.Color.White;
            this.label_Strike.Location = new System.Drawing.Point(28, 99);
            this.label_Strike.Name = "label_Strike";
            this.label_Strike.Size = new System.Drawing.Size(118, 16);
            this.label_Strike.TabIndex = 15;
            this.label_Strike.Text = "Option Strike Price";
            // 
            // checkBox_CV_VarReduc
            // 
            this.checkBox_CV_VarReduc.AutoSize = true;
            this.checkBox_CV_VarReduc.ForeColor = System.Drawing.Color.White;
            this.checkBox_CV_VarReduc.Location = new System.Drawing.Point(165, 149);
            this.checkBox_CV_VarReduc.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_CV_VarReduc.Name = "checkBox_CV_VarReduc";
            this.checkBox_CV_VarReduc.Size = new System.Drawing.Size(95, 17);
            this.checkBox_CV_VarReduc.TabIndex = 41;
            this.checkBox_CV_VarReduc.Text = "Control Variate";
            this.checkBox_CV_VarReduc.UseVisualStyleBackColor = true;
            this.checkBox_CV_VarReduc.CheckedChanged += new System.EventHandler(this.checkBox_CV_VarReduc_CheckedChanged);
            // 
            // textBox_Rate
            // 
            this.textBox_Rate.Location = new System.Drawing.Point(194, 160);
            this.textBox_Rate.Name = "textBox_Rate";
            this.textBox_Rate.Size = new System.Drawing.Size(100, 20);
            this.textBox_Rate.TabIndex = 3;
            // 
            // checkBox_Multithread
            // 
            this.checkBox_Multithread.AutoSize = true;
            this.checkBox_Multithread.ForeColor = System.Drawing.Color.White;
            this.checkBox_Multithread.Location = new System.Drawing.Point(22, 226);
            this.checkBox_Multithread.Name = "checkBox_Multithread";
            this.checkBox_Multithread.Size = new System.Drawing.Size(78, 17);
            this.checkBox_Multithread.TabIndex = 46;
            this.checkBox_Multithread.Text = "Multithread";
            this.checkBox_Multithread.UseVisualStyleBackColor = true;
            this.checkBox_Multithread.CheckedChanged += new System.EventHandler(this.checkBox_Multithread_CheckedChanged);
            // 
            // textBox_Tenor
            // 
            this.textBox_Tenor.Location = new System.Drawing.Point(194, 129);
            this.textBox_Tenor.Name = "textBox_Tenor";
            this.textBox_Tenor.Size = new System.Drawing.Size(100, 20);
            this.textBox_Tenor.TabIndex = 2;
            // 
            // textBox_Steps
            // 
            this.textBox_Steps.Location = new System.Drawing.Point(165, 104);
            this.textBox_Steps.Name = "textBox_Steps";
            this.textBox_Steps.Size = new System.Drawing.Size(100, 20);
            this.textBox_Steps.TabIndex = 5;
            // 
            // textBox_Strike
            // 
            this.textBox_Strike.Location = new System.Drawing.Point(194, 98);
            this.textBox_Strike.Name = "textBox_Strike";
            this.textBox_Strike.Size = new System.Drawing.Size(100, 20);
            this.textBox_Strike.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1078, 602);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBox_Trials);
            this.panel2.Controls.Add(this.textBox_Steps);
            this.panel2.Controls.Add(this.button_Go);
            this.panel2.Controls.Add(this.label_Steps);
            this.panel2.Controls.Add(this.checkBox_Multithread);
            this.panel2.Controls.Add(this.checkBox_CV_VarReduc);
            this.panel2.Controls.Add(this.label_Trials);
            this.panel2.Controls.Add(this.textBox_Cores);
            this.panel2.Controls.Add(this.checkBox_VarReduc);
            this.panel2.Controls.Add(this.label6);
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(323, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 531);
            this.panel2.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(275, 18);
            this.label7.TabIndex = 22;
            this.label7.Text = "Simulation and Variance Reduction:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(156, 333);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 49;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(30, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 50;
            this.label8.Text = "Option Style\r\n";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MistyRose;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.textBox_Timer);
            this.panel3.Controls.Add(this.label_Progress);
            this.panel3.Location = new System.Drawing.Point(626, 390);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(449, 136);
            this.panel3.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 17);
            this.label9.TabIndex = 50;
            this.label9.Text = "Processing Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1091, 568);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButton_Put;
        private System.Windows.Forms.Button button_Go;
        private System.Windows.Forms.RadioButton radioButton_Call;
        private System.Windows.Forms.TextBox textBox_OptionPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Delta;
        private System.Windows.Forms.TextBox textBox_Gamma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Gamma;
        private System.Windows.Forms.TextBox textBox_Theta;
        private System.Windows.Forms.Label label_Theta;
        private System.Windows.Forms.Label label_Vega;
        private System.Windows.Forms.TextBox textBox_Vega;
        private System.Windows.Forms.Label label_StdErr;
        private System.Windows.Forms.TextBox textBox_StdErr;
        private System.Windows.Forms.Label label_Rho;
        private System.Windows.Forms.TextBox textBox_Rho;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox_Timer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_Progress;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Inputs;
        private System.Windows.Forms.Label label_Drift;
        private System.Windows.Forms.TextBox textBox_Drift;
        private System.Windows.Forms.Label label_Steps;
        private System.Windows.Forms.Label label_Spot;
        private System.Windows.Forms.Label label_Trials;
        private System.Windows.Forms.Label label_Vol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_Tenor;
        private System.Windows.Forms.Label label_Rate;
        private System.Windows.Forms.TextBox textBox_Spot;
        private System.Windows.Forms.CheckBox checkBox_VarReduc;
        private System.Windows.Forms.TextBox textBox_Trials;
        private System.Windows.Forms.TextBox textBox_Cores;
        private System.Windows.Forms.TextBox textBox_Volatility;
        private System.Windows.Forms.Label label_Strike;
        private System.Windows.Forms.CheckBox checkBox_CV_VarReduc;
        private System.Windows.Forms.TextBox textBox_Rate;
        private System.Windows.Forms.CheckBox checkBox_Multithread;
        private System.Windows.Forms.TextBox textBox_Tenor;
        private System.Windows.Forms.TextBox textBox_Steps;
        private System.Windows.Forms.TextBox textBox_Strike;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

