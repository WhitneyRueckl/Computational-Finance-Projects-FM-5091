namespace PortfolioManagerGUI
{
    partial class NewTradeForm
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
            this.comboBox_BuySell = new System.Windows.Forms.ComboBox();
            this.comboBox_Tickers = new System.Windows.Forms.ComboBox();
            this.label_NewTradeTitle = new System.Windows.Forms.Label();
            this.label_NewTradeTicker = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_TradePrice = new System.Windows.Forms.TextBox();
            this.label_TradePrice = new System.Windows.Forms.Label();
            this.textBox_Quantity = new System.Windows.Forms.TextBox();
            this.label_Quantity = new System.Windows.Forms.Label();
            this.label_TradeDate = new System.Windows.Forms.Label();
            this.label_TodaysDate = new System.Windows.Forms.Label();
            this.dataGridView_NewTradesEntry = new System.Windows.Forms.DataGridView();
            this.IsBuy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ticker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_AddTrades = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NewTradesEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_BuySell
            // 
            this.comboBox_BuySell.FormattingEnabled = true;
            this.comboBox_BuySell.Items.AddRange(new object[] {
            "BUY",
            "SELL"});
            this.comboBox_BuySell.Location = new System.Drawing.Point(120, 120);
            this.comboBox_BuySell.Name = "comboBox_BuySell";
            this.comboBox_BuySell.Size = new System.Drawing.Size(107, 21);
            this.comboBox_BuySell.TabIndex = 0;
            // 
            // comboBox_Tickers
            // 
            this.comboBox_Tickers.FormattingEnabled = true;
            this.comboBox_Tickers.Items.AddRange(new object[] {
            "AAPL",
            "NVDA",
            "TTD",
            "FB",
            "AMZN",
            "FB240C",
            "AAPL250P",
            "AAPL250C",
            "MSFT",
            "MSFT175C"});
            this.comboBox_Tickers.Location = new System.Drawing.Point(120, 83);
            this.comboBox_Tickers.Name = "comboBox_Tickers";
            this.comboBox_Tickers.Size = new System.Drawing.Size(107, 21);
            this.comboBox_Tickers.TabIndex = 1;
            // 
            // label_NewTradeTitle
            // 
            this.label_NewTradeTitle.AutoSize = true;
            this.label_NewTradeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NewTradeTitle.Location = new System.Drawing.Point(31, 28);
            this.label_NewTradeTitle.Name = "label_NewTradeTitle";
            this.label_NewTradeTitle.Size = new System.Drawing.Size(86, 17);
            this.label_NewTradeTitle.TabIndex = 2;
            this.label_NewTradeTitle.Text = "New Trade";
            // 
            // label_NewTradeTicker
            // 
            this.label_NewTradeTicker.AutoSize = true;
            this.label_NewTradeTicker.Location = new System.Drawing.Point(31, 83);
            this.label_NewTradeTicker.Name = "label_NewTradeTicker";
            this.label_NewTradeTicker.Size = new System.Drawing.Size(37, 13);
            this.label_NewTradeTicker.TabIndex = 3;
            this.label_NewTradeTicker.Text = "Ticker";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buy/Sell";
            // 
            // textBox_TradePrice
            // 
            this.textBox_TradePrice.Location = new System.Drawing.Point(373, 120);
            this.textBox_TradePrice.Name = "textBox_TradePrice";
            this.textBox_TradePrice.Size = new System.Drawing.Size(100, 20);
            this.textBox_TradePrice.TabIndex = 5;
            // 
            // label_TradePrice
            // 
            this.label_TradePrice.AutoSize = true;
            this.label_TradePrice.Location = new System.Drawing.Point(283, 128);
            this.label_TradePrice.Name = "label_TradePrice";
            this.label_TradePrice.Size = new System.Drawing.Size(62, 13);
            this.label_TradePrice.TabIndex = 6;
            this.label_TradePrice.Text = "Trade Price";
            this.label_TradePrice.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox_Quantity
            // 
            this.textBox_Quantity.Location = new System.Drawing.Point(373, 84);
            this.textBox_Quantity.Name = "textBox_Quantity";
            this.textBox_Quantity.Size = new System.Drawing.Size(100, 20);
            this.textBox_Quantity.TabIndex = 7;
            // 
            // label_Quantity
            // 
            this.label_Quantity.AutoSize = true;
            this.label_Quantity.Location = new System.Drawing.Point(283, 83);
            this.label_Quantity.Name = "label_Quantity";
            this.label_Quantity.Size = new System.Drawing.Size(46, 13);
            this.label_Quantity.TabIndex = 8;
            this.label_Quantity.Text = "Quantity";
            // 
            // label_TradeDate
            // 
            this.label_TradeDate.AutoSize = true;
            this.label_TradeDate.Location = new System.Drawing.Point(283, 30);
            this.label_TradeDate.Name = "label_TradeDate";
            this.label_TradeDate.Size = new System.Drawing.Size(61, 13);
            this.label_TradeDate.TabIndex = 9;
            this.label_TradeDate.Text = "Trade Date";
            // 
            // label_TodaysDate
            // 
            this.label_TodaysDate.AutoSize = true;
            this.label_TodaysDate.Location = new System.Drawing.Point(412, 30);
            this.label_TodaysDate.Name = "label_TodaysDate";
            this.label_TodaysDate.Size = new System.Drawing.Size(70, 13);
            this.label_TodaysDate.TabIndex = 10;
            this.label_TodaysDate.Text = "Today\'s Date";
            // 
            // dataGridView_NewTradesEntry
            // 
            this.dataGridView_NewTradesEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_NewTradesEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsBuy,
            this.Ticker,
            this.Quantity,
            this.TradePrice,
            this.TradeDate});
            this.dataGridView_NewTradesEntry.Location = new System.Drawing.Point(34, 187);
            this.dataGridView_NewTradesEntry.Name = "dataGridView_NewTradesEntry";
            this.dataGridView_NewTradesEntry.Size = new System.Drawing.Size(536, 150);
            this.dataGridView_NewTradesEntry.TabIndex = 11;
            // 
            // IsBuy
            // 
            this.IsBuy.HeaderText = "Buy/Sell";
            this.IsBuy.Name = "IsBuy";
            // 
            // Ticker
            // 
            this.Ticker.HeaderText = "Ticker";
            this.Ticker.Name = "Ticker";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // TradePrice
            // 
            this.TradePrice.HeaderText = "Trade Price";
            this.TradePrice.Name = "TradePrice";
            // 
            // TradeDate
            // 
            this.TradeDate.HeaderText = "Trade Date";
            this.TradeDate.Name = "TradeDate";
            // 
            // button_AddTrades
            // 
            this.button_AddTrades.Location = new System.Drawing.Point(34, 360);
            this.button_AddTrades.Name = "button_AddTrades";
            this.button_AddTrades.Size = new System.Drawing.Size(147, 34);
            this.button_AddTrades.TabIndex = 12;
            this.button_AddTrades.Text = "Add Trades To Book";
            this.button_AddTrades.UseVisualStyleBackColor = true;
            this.button_AddTrades.Click += new System.EventHandler(this.button_AddTrades_Click);
            // 
            // NewTradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 419);
            this.Controls.Add(this.button_AddTrades);
            this.Controls.Add(this.dataGridView_NewTradesEntry);
            this.Controls.Add(this.label_TodaysDate);
            this.Controls.Add(this.label_TradeDate);
            this.Controls.Add(this.label_Quantity);
            this.Controls.Add(this.textBox_Quantity);
            this.Controls.Add(this.label_TradePrice);
            this.Controls.Add(this.textBox_TradePrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_NewTradeTicker);
            this.Controls.Add(this.label_NewTradeTitle);
            this.Controls.Add(this.comboBox_Tickers);
            this.Controls.Add(this.comboBox_BuySell);
            this.Name = "NewTradeForm";
            this.Text = "NewTradeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NewTradesEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_BuySell;
        private System.Windows.Forms.ComboBox comboBox_Tickers;
        private System.Windows.Forms.Label label_NewTradeTitle;
        private System.Windows.Forms.Label label_NewTradeTicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_TradePrice;
        private System.Windows.Forms.Label label_TradePrice;
        private System.Windows.Forms.TextBox textBox_Quantity;
        private System.Windows.Forms.Label label_Quantity;
        private System.Windows.Forms.Label label_TradeDate;
        private System.Windows.Forms.Label label_TodaysDate;
        private System.Windows.Forms.DataGridView dataGridView_NewTradesEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsBuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ticker;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradeDate;
        private System.Windows.Forms.Button button_AddTrades;
    }
}