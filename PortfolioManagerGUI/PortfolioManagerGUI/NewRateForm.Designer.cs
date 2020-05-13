namespace PortfolioManagerGUI
{
    partial class NewRateForm
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
            this.dataGridView_Rates = new System.Windows.Forms.DataGridView();
            this.textBox_NewRate = new System.Windows.Forms.TextBox();
            this.numericUpDown_Tenor = new System.Windows.Forms.NumericUpDown();
            this.label_NewRate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_SaveNewRate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Rates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Tenor)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Rates
            // 
            this.dataGridView_Rates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Rates.Location = new System.Drawing.Point(236, 56);
            this.dataGridView_Rates.Name = "dataGridView_Rates";
            this.dataGridView_Rates.RowTemplate.Height = 28;
            this.dataGridView_Rates.Size = new System.Drawing.Size(414, 309);
            this.dataGridView_Rates.TabIndex = 0;
            // 
            // textBox_NewRate
            // 
            this.textBox_NewRate.Location = new System.Drawing.Point(79, 164);
            this.textBox_NewRate.Name = "textBox_NewRate";
            this.textBox_NewRate.Size = new System.Drawing.Size(100, 26);
            this.textBox_NewRate.TabIndex = 1;
            // 
            // numericUpDown_Tenor
            // 
            this.numericUpDown_Tenor.Location = new System.Drawing.Point(79, 77);
            this.numericUpDown_Tenor.Name = "numericUpDown_Tenor";
            this.numericUpDown_Tenor.Size = new System.Drawing.Size(100, 26);
            this.numericUpDown_Tenor.TabIndex = 2;
            // 
            // label_NewRate
            // 
            this.label_NewRate.AutoSize = true;
            this.label_NewRate.Location = new System.Drawing.Point(22, 167);
            this.label_NewRate.Name = "label_NewRate";
            this.label_NewRate.Size = new System.Drawing.Size(44, 20);
            this.label_NewRate.TabIndex = 3;
            this.label_NewRate.Text = "Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tenor";
            // 
            // button_SaveNewRate
            // 
            this.button_SaveNewRate.Location = new System.Drawing.Point(26, 317);
            this.button_SaveNewRate.Name = "button_SaveNewRate";
            this.button_SaveNewRate.Size = new System.Drawing.Size(162, 32);
            this.button_SaveNewRate.TabIndex = 5;
            this.button_SaveNewRate.Text = "Save and Refresh";
            this.button_SaveNewRate.UseVisualStyleBackColor = true;
            this.button_SaveNewRate.Click += new System.EventHandler(this.button_SaveNewRate_Click);
            // 
            // NewRateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 406);
            this.Controls.Add(this.button_SaveNewRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_NewRate);
            this.Controls.Add(this.numericUpDown_Tenor);
            this.Controls.Add(this.textBox_NewRate);
            this.Controls.Add(this.dataGridView_Rates);
            this.Name = "NewRateForm";
            this.Text = "NewRateForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Rates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Tenor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Rates;
        private System.Windows.Forms.TextBox textBox_NewRate;
        private System.Windows.Forms.NumericUpDown numericUpDown_Tenor;
        private System.Windows.Forms.Label label_NewRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_SaveNewRate;
    }
}