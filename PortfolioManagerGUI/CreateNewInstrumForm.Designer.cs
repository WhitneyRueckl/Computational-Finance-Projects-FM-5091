namespace PortfolioManagerGUI
{
    partial class CreateNewInstrumForm
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox_CompName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Ticker = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Strike = new System.Windows.Forms.TextBox();
            this.textBox_Tenor = new System.Windows.Forms.TextBox();
            this.comboBox_InstrTypeNewInstrum = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label_NewInstr = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.radioButton_NewCall = new System.Windows.Forms.RadioButton();
            this.radioButton_NewPut = new System.Windows.Forms.RadioButton();
            this.radioButton_NewNeither = new System.Windows.Forms.RadioButton();
            this.button_AddNewInstr = new System.Windows.Forms.Button();
            this.button_CancelNewInstr = new System.Windows.Forms.Button();
            this.textBox_Exchange = new System.Windows.Forms.TextBox();
            this.label_Exchange = new System.Windows.Forms.Label();
            this.label_IsPut = new System.Windows.Forms.Label();
            this.label_InstTypeId = new System.Windows.Forms.Label();
            this.comboBox_BarrierTypes = new System.Windows.Forms.ComboBox();
            this.label_BarrierType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox_CompName
            // 
            this.textBox_CompName.Location = new System.Drawing.Point(152, 52);
            this.textBox_CompName.Name = "textBox_CompName";
            this.textBox_CompName.Size = new System.Drawing.Size(211, 20);
            this.textBox_CompName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Company Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ticker";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Underlying";
            // 
            // textBox_Ticker
            // 
            this.textBox_Ticker.Location = new System.Drawing.Point(152, 81);
            this.textBox_Ticker.Name = "textBox_Ticker";
            this.textBox_Ticker.Size = new System.Drawing.Size(211, 20);
            this.textBox_Ticker.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Strike";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tenor";
            // 
            // textBox_Strike
            // 
            this.textBox_Strike.Location = new System.Drawing.Point(153, 181);
            this.textBox_Strike.Name = "textBox_Strike";
            this.textBox_Strike.Size = new System.Drawing.Size(211, 20);
            this.textBox_Strike.TabIndex = 10;
            // 
            // textBox_Tenor
            // 
            this.textBox_Tenor.Location = new System.Drawing.Point(152, 214);
            this.textBox_Tenor.Name = "textBox_Tenor";
            this.textBox_Tenor.Size = new System.Drawing.Size(211, 20);
            this.textBox_Tenor.TabIndex = 11;
            // 
            // comboBox_InstrTypeNewInstrum
            // 
            this.comboBox_InstrTypeNewInstrum.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_InstrTypeNewInstrum.FormattingEnabled = true;
            this.comboBox_InstrTypeNewInstrum.Items.AddRange(new object[] {
            "Stock",
            "EuropeanOption",
            "AsianOption",
            "LookbackOption",
            "DigitalOption",
            "BarrierOption",
            "RangeOption"});
            this.comboBox_InstrTypeNewInstrum.Location = new System.Drawing.Point(152, 361);
            this.comboBox_InstrTypeNewInstrum.Name = "comboBox_InstrTypeNewInstrum";
            this.comboBox_InstrTypeNewInstrum.Size = new System.Drawing.Size(211, 21);
            this.comboBox_InstrTypeNewInstrum.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Instrument Type";
            // 
            // label_NewInstr
            // 
            this.label_NewInstr.AutoSize = true;
            this.label_NewInstr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NewInstr.Location = new System.Drawing.Point(20, 20);
            this.label_NewInstr.Name = "label_NewInstr";
            this.label_NewInstr.Size = new System.Drawing.Size(119, 17);
            this.label_NewInstr.TabIndex = 14;
            this.label_NewInstr.Text = "New Instrument";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "AAPL",
            "NVDA",
            "AMZN",
            "TTD",
            "FB"});
            this.comboBox2.Location = new System.Drawing.Point(153, 143);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(211, 21);
            this.comboBox2.TabIndex = 16;
            // 
            // radioButton_NewCall
            // 
            this.radioButton_NewCall.AutoSize = true;
            this.radioButton_NewCall.Location = new System.Drawing.Point(153, 259);
            this.radioButton_NewCall.Name = "radioButton_NewCall";
            this.radioButton_NewCall.Size = new System.Drawing.Size(42, 17);
            this.radioButton_NewCall.TabIndex = 20;
            this.radioButton_NewCall.TabStop = true;
            this.radioButton_NewCall.Text = "Call";
            this.radioButton_NewCall.UseVisualStyleBackColor = true;
            this.radioButton_NewCall.CheckedChanged += new System.EventHandler(this.radioButton_NewCall_CheckedChanged);
            // 
            // radioButton_NewPut
            // 
            this.radioButton_NewPut.AutoSize = true;
            this.radioButton_NewPut.Location = new System.Drawing.Point(153, 282);
            this.radioButton_NewPut.Name = "radioButton_NewPut";
            this.radioButton_NewPut.Size = new System.Drawing.Size(41, 17);
            this.radioButton_NewPut.TabIndex = 21;
            this.radioButton_NewPut.TabStop = true;
            this.radioButton_NewPut.Text = "Put";
            this.radioButton_NewPut.UseVisualStyleBackColor = true;
            // 
            // radioButton_NewNeither
            // 
            this.radioButton_NewNeither.AutoSize = true;
            this.radioButton_NewNeither.Location = new System.Drawing.Point(152, 305);
            this.radioButton_NewNeither.Name = "radioButton_NewNeither";
            this.radioButton_NewNeither.Size = new System.Drawing.Size(108, 17);
            this.radioButton_NewNeither.TabIndex = 22;
            this.radioButton_NewNeither.TabStop = true;
            this.radioButton_NewNeither.Text = "Neither call or put";
            this.radioButton_NewNeither.UseVisualStyleBackColor = true;
            // 
            // button_AddNewInstr
            // 
            this.button_AddNewInstr.Location = new System.Drawing.Point(120, 479);
            this.button_AddNewInstr.Name = "button_AddNewInstr";
            this.button_AddNewInstr.Size = new System.Drawing.Size(109, 34);
            this.button_AddNewInstr.TabIndex = 23;
            this.button_AddNewInstr.Text = "Add";
            this.button_AddNewInstr.UseVisualStyleBackColor = true;
            this.button_AddNewInstr.Click += new System.EventHandler(this.button_AddNewInstr_Click);
            // 
            // button_CancelNewInstr
            // 
            this.button_CancelNewInstr.Location = new System.Drawing.Point(248, 479);
            this.button_CancelNewInstr.Name = "button_CancelNewInstr";
            this.button_CancelNewInstr.Size = new System.Drawing.Size(115, 34);
            this.button_CancelNewInstr.TabIndex = 24;
            this.button_CancelNewInstr.Text = "Cancel";
            this.button_CancelNewInstr.UseVisualStyleBackColor = true;
            // 
            // textBox_Exchange
            // 
            this.textBox_Exchange.Location = new System.Drawing.Point(152, 111);
            this.textBox_Exchange.Name = "textBox_Exchange";
            this.textBox_Exchange.Size = new System.Drawing.Size(211, 20);
            this.textBox_Exchange.TabIndex = 25;
            // 
            // label_Exchange
            // 
            this.label_Exchange.AutoSize = true;
            this.label_Exchange.Location = new System.Drawing.Point(20, 118);
            this.label_Exchange.Name = "label_Exchange";
            this.label_Exchange.Size = new System.Drawing.Size(55, 13);
            this.label_Exchange.TabIndex = 26;
            this.label_Exchange.Text = "Exchange";
            // 
            // label_IsPut
            // 
            this.label_IsPut.AutoSize = true;
            this.label_IsPut.Location = new System.Drawing.Point(20, 396);
            this.label_IsPut.Name = "label_IsPut";
            this.label_IsPut.Size = new System.Drawing.Size(31, 13);
            this.label_IsPut.TabIndex = 29;
            this.label_IsPut.Text = "IsPut";
            // 
            // label_InstTypeId
            // 
            this.label_InstTypeId.AutoSize = true;
            this.label_InstTypeId.Location = new System.Drawing.Point(117, 364);
            this.label_InstTypeId.Name = "label_InstTypeId";
            this.label_InstTypeId.Size = new System.Drawing.Size(15, 13);
            this.label_InstTypeId.TabIndex = 30;
            this.label_InstTypeId.Text = "id";
            // 
            // comboBox_BarrierTypes
            // 
            this.comboBox_BarrierTypes.FormattingEnabled = true;
            this.comboBox_BarrierTypes.Items.AddRange(new object[] {
            "Down-In",
            "Down-Out",
            "Up-In",
            "Up-Out"});
            this.comboBox_BarrierTypes.Location = new System.Drawing.Point(242, 408);
            this.comboBox_BarrierTypes.Name = "comboBox_BarrierTypes";
            this.comboBox_BarrierTypes.Size = new System.Drawing.Size(121, 21);
            this.comboBox_BarrierTypes.TabIndex = 31;
            // 
            // label_BarrierType
            // 
            this.label_BarrierType.AutoSize = true;
            this.label_BarrierType.Location = new System.Drawing.Point(150, 411);
            this.label_BarrierType.Name = "label_BarrierType";
            this.label_BarrierType.Size = new System.Drawing.Size(64, 13);
            this.label_BarrierType.TabIndex = 32;
            this.label_BarrierType.Text = "Barrier Type";
            // 
            // CreateNewInstrumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 525);
            this.Controls.Add(this.label_BarrierType);
            this.Controls.Add(this.comboBox_BarrierTypes);
            this.Controls.Add(this.label_InstTypeId);
            this.Controls.Add(this.label_IsPut);
            this.Controls.Add(this.label_Exchange);
            this.Controls.Add(this.textBox_Exchange);
            this.Controls.Add(this.button_CancelNewInstr);
            this.Controls.Add(this.button_AddNewInstr);
            this.Controls.Add(this.radioButton_NewNeither);
            this.Controls.Add(this.radioButton_NewPut);
            this.Controls.Add(this.radioButton_NewCall);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label_NewInstr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox_InstrTypeNewInstrum);
            this.Controls.Add(this.textBox_Tenor);
            this.Controls.Add(this.textBox_Strike);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Ticker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_CompName);
            this.Name = "CreateNewInstrumForm";
            this.Text = "CreateNewInstrumForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBox_CompName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Ticker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Strike;
        private System.Windows.Forms.TextBox textBox_Tenor;
        private System.Windows.Forms.ComboBox comboBox_InstrTypeNewInstrum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_NewInstr;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.RadioButton radioButton_NewCall;
        private System.Windows.Forms.RadioButton radioButton_NewPut;
        private System.Windows.Forms.RadioButton radioButton_NewNeither;
        private System.Windows.Forms.Button button_AddNewInstr;
        private System.Windows.Forms.Button button_CancelNewInstr;
        private System.Windows.Forms.TextBox textBox_Exchange;
        private System.Windows.Forms.Label label_Exchange;
        private System.Windows.Forms.Label label_IsPut;
        private System.Windows.Forms.Label label_InstTypeId;
        private System.Windows.Forms.ComboBox comboBox_BarrierTypes;
        private System.Windows.Forms.Label label_BarrierType;
    }
}