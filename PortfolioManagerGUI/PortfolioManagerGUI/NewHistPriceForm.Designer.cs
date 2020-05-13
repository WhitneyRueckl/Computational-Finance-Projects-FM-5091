namespace PortfolioManagerGUI
{
    partial class NewHistPriceForm
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
            this.dataGridView_HistPrices = new System.Windows.Forms.DataGridView();
            this.comboBox_TickersForHistPrice = new System.Windows.Forms.ComboBox();
            this.label_TickerForPrice = new System.Windows.Forms.Label();
            this.label_HistPricesTitle = new System.Windows.Forms.Label();
            this.dateTimePicker_HistPrices = new System.Windows.Forms.DateTimePicker();
            this.label_HistPrice = new System.Windows.Forms.Label();
            this.textBox_NewPrice = new System.Windows.Forms.TextBox();
            this.button_AddNewPricesToDb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HistPrices)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_HistPrices
            // 
            this.dataGridView_HistPrices.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView_HistPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_HistPrices.Location = new System.Drawing.Point(292, 76);
            this.dataGridView_HistPrices.Name = "dataGridView_HistPrices";
            this.dataGridView_HistPrices.Size = new System.Drawing.Size(263, 307);
            this.dataGridView_HistPrices.TabIndex = 0;
            // 
            // comboBox_TickersForHistPrice
            // 
            this.comboBox_TickersForHistPrice.FormattingEnabled = true;
            this.comboBox_TickersForHistPrice.Items.AddRange(new object[] {
            "AAPL",
            "AMZN",
            "NVDA",
            "FB",
            "TTD"});
            this.comboBox_TickersForHistPrice.Location = new System.Drawing.Point(116, 76);
            this.comboBox_TickersForHistPrice.Name = "comboBox_TickersForHistPrice";
            this.comboBox_TickersForHistPrice.Size = new System.Drawing.Size(124, 21);
            this.comboBox_TickersForHistPrice.TabIndex = 1;
            // 
            // label_TickerForPrice
            // 
            this.label_TickerForPrice.AutoSize = true;
            this.label_TickerForPrice.Location = new System.Drawing.Point(37, 76);
            this.label_TickerForPrice.Name = "label_TickerForPrice";
            this.label_TickerForPrice.Size = new System.Drawing.Size(40, 13);
            this.label_TickerForPrice.TabIndex = 2;
            this.label_TickerForPrice.Text = "Ticker:";
            // 
            // label_HistPricesTitle
            // 
            this.label_HistPricesTitle.AutoSize = true;
            this.label_HistPricesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HistPricesTitle.Location = new System.Drawing.Point(28, 23);
            this.label_HistPricesTitle.Name = "label_HistPricesTitle";
            this.label_HistPricesTitle.Size = new System.Drawing.Size(131, 17);
            this.label_HistPricesTitle.TabIndex = 3;
            this.label_HistPricesTitle.Text = "Historical Prices:";
            // 
            // dateTimePicker_HistPrices
            // 
            this.dateTimePicker_HistPrices.Location = new System.Drawing.Point(40, 211);
            this.dateTimePicker_HistPrices.Name = "dateTimePicker_HistPrices";
            this.dateTimePicker_HistPrices.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_HistPrices.TabIndex = 5;
            // 
            // label_HistPrice
            // 
            this.label_HistPrice.AutoSize = true;
            this.label_HistPrice.Location = new System.Drawing.Point(37, 143);
            this.label_HistPrice.Name = "label_HistPrice";
            this.label_HistPrice.Size = new System.Drawing.Size(34, 13);
            this.label_HistPrice.TabIndex = 6;
            this.label_HistPrice.Text = "Price:";
            // 
            // textBox_NewPrice
            // 
            this.textBox_NewPrice.Location = new System.Drawing.Point(116, 143);
            this.textBox_NewPrice.Name = "textBox_NewPrice";
            this.textBox_NewPrice.Size = new System.Drawing.Size(124, 20);
            this.textBox_NewPrice.TabIndex = 7;
            // 
            // button_AddNewPricesToDb
            // 
            this.button_AddNewPricesToDb.Location = new System.Drawing.Point(47, 352);
            this.button_AddNewPricesToDb.Name = "button_AddNewPricesToDb";
            this.button_AddNewPricesToDb.Size = new System.Drawing.Size(193, 31);
            this.button_AddNewPricesToDb.TabIndex = 8;
            this.button_AddNewPricesToDb.Text = "Save and Refresh";
            this.button_AddNewPricesToDb.UseVisualStyleBackColor = true;
            this.button_AddNewPricesToDb.Click += new System.EventHandler(this.button_AddNewPricesToDb_Click);
            // 
            // NewHistPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 422);
            this.Controls.Add(this.button_AddNewPricesToDb);
            this.Controls.Add(this.textBox_NewPrice);
            this.Controls.Add(this.label_HistPrice);
            this.Controls.Add(this.dateTimePicker_HistPrices);
            this.Controls.Add(this.label_HistPricesTitle);
            this.Controls.Add(this.label_TickerForPrice);
            this.Controls.Add(this.comboBox_TickersForHistPrice);
            this.Controls.Add(this.dataGridView_HistPrices);
            this.Name = "NewHistPriceForm";
            this.Text = "NewHistPriceForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HistPrices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_HistPrices;
        private System.Windows.Forms.ComboBox comboBox_TickersForHistPrice;
        private System.Windows.Forms.Label label_TickerForPrice;
        private System.Windows.Forms.Label label_HistPricesTitle;
        private System.Windows.Forms.DateTimePicker dateTimePicker_HistPrices;
        private System.Windows.Forms.Label label_HistPrice;
        private System.Windows.Forms.TextBox textBox_NewPrice;
        private System.Windows.Forms.Button button_AddNewPricesToDb;
    }
}