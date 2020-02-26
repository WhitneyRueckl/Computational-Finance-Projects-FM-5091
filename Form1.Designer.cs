namespace Monte_Carlo_Pricer
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
            this.textBox_Spot = new System.Windows.Forms.TextBox();
            this.textBox_Strike = new System.Windows.Forms.TextBox();
            this.textBox_Tenor = new System.Windows.Forms.TextBox();
            this.textBox_Rate = new System.Windows.Forms.TextBox();
            this.textBox_Volatility = new System.Windows.Forms.TextBox();
            this.textBox_Steps = new System.Windows.Forms.TextBox();
            this.radioButton_European = new System.Windows.Forms.RadioButton();
            this.radioButton_American = new System.Windows.Forms.RadioButton();
            this.radioButton_Bermudan = new System.Windows.Forms.RadioButton();
            this.radioButton_Put = new System.Windows.Forms.RadioButton();
            this.textBox_Trials = new System.Windows.Forms.TextBox();
            this.button_Go = new System.Windows.Forms.Button();
            this.radioButton_Call = new System.Windows.Forms.RadioButton();
            this.textBox_OptionPrice = new System.Windows.Forms.TextBox();
            this.label_Spot = new System.Windows.Forms.Label();
            this.label_Strike = new System.Windows.Forms.Label();
            this.label_Rate = new System.Windows.Forms.Label();
            this.label_Tenor = new System.Windows.Forms.Label();
            this.label_Vol = new System.Windows.Forms.Label();
            this.label_Trials = new System.Windows.Forms.Label();
            this.label_Steps = new System.Windows.Forms.Label();
            this.label_Inputs = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Delta = new System.Windows.Forms.TextBox();
            this.textBox_Gamma = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Gamma = new System.Windows.Forms.Label();
            this.textBox_Drift = new System.Windows.Forms.TextBox();
            this.label_Drift = new System.Windows.Forms.Label();
            this.textBox_Theta = new System.Windows.Forms.TextBox();
            this.label_Theta = new System.Windows.Forms.Label();
            this.label_Vega = new System.Windows.Forms.Label();
            this.textBox_Vega = new System.Windows.Forms.TextBox();
            this.label_StdErr = new System.Windows.Forms.Label();
            this.textBox_StdErr = new System.Windows.Forms.TextBox();
            this.label_Rho = new System.Windows.Forms.Label();
            this.textBox_Rho = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_Spot
            // 
            this.textBox_Spot.Location = new System.Drawing.Point(204, 121);
            this.textBox_Spot.Name = "textBox_Spot";
            this.textBox_Spot.Size = new System.Drawing.Size(100, 26);
            this.textBox_Spot.TabIndex = 0;
            this.textBox_Spot.TextChanged += new System.EventHandler(this.textBox_Spot_TextChanged);
            // 
            // textBox_Strike
            // 
            this.textBox_Strike.Location = new System.Drawing.Point(204, 162);
            this.textBox_Strike.Name = "textBox_Strike";
            this.textBox_Strike.Size = new System.Drawing.Size(100, 26);
            this.textBox_Strike.TabIndex = 1;
            // 
            // textBox_Tenor
            // 
            this.textBox_Tenor.Location = new System.Drawing.Point(204, 201);
            this.textBox_Tenor.Name = "textBox_Tenor";
            this.textBox_Tenor.Size = new System.Drawing.Size(100, 26);
            this.textBox_Tenor.TabIndex = 2;
            // 
            // textBox_Rate
            // 
            this.textBox_Rate.Location = new System.Drawing.Point(204, 243);
            this.textBox_Rate.Name = "textBox_Rate";
            this.textBox_Rate.Size = new System.Drawing.Size(100, 26);
            this.textBox_Rate.TabIndex = 3;
            // 
            // textBox_Volatility
            // 
            this.textBox_Volatility.Location = new System.Drawing.Point(204, 287);
            this.textBox_Volatility.Name = "textBox_Volatility";
            this.textBox_Volatility.Size = new System.Drawing.Size(100, 26);
            this.textBox_Volatility.TabIndex = 4;
            // 
            // textBox_Steps
            // 
            this.textBox_Steps.Location = new System.Drawing.Point(207, 411);
            this.textBox_Steps.Name = "textBox_Steps";
            this.textBox_Steps.Size = new System.Drawing.Size(100, 26);
            this.textBox_Steps.TabIndex = 5;
            // 
            // radioButton_European
            // 
            this.radioButton_European.AutoSize = true;
            this.radioButton_European.Location = new System.Drawing.Point(353, 121);
            this.radioButton_European.Name = "radioButton_European";
            this.radioButton_European.Size = new System.Drawing.Size(97, 24);
            this.radioButton_European.TabIndex = 6;
            this.radioButton_European.TabStop = true;
            this.radioButton_European.Text = "European";
            this.radioButton_European.UseVisualStyleBackColor = true;
            this.radioButton_European.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton_American
            // 
            this.radioButton_American.AutoSize = true;
            this.radioButton_American.Location = new System.Drawing.Point(353, 160);
            this.radioButton_American.Name = "radioButton_American";
            this.radioButton_American.Size = new System.Drawing.Size(94, 24);
            this.radioButton_American.TabIndex = 7;
            this.radioButton_American.TabStop = true;
            this.radioButton_American.Text = "American";
            this.radioButton_American.UseVisualStyleBackColor = true;
            // 
            // radioButton_Bermudan
            // 
            this.radioButton_Bermudan.AutoSize = true;
            this.radioButton_Bermudan.Location = new System.Drawing.Point(353, 202);
            this.radioButton_Bermudan.Name = "radioButton_Bermudan";
            this.radioButton_Bermudan.Size = new System.Drawing.Size(101, 24);
            this.radioButton_Bermudan.TabIndex = 8;
            this.radioButton_Bermudan.TabStop = true;
            this.radioButton_Bermudan.Text = "Bermudan";
            this.radioButton_Bermudan.UseVisualStyleBackColor = true;
            // 
            // radioButton_Put
            // 
            this.radioButton_Put.AutoSize = true;
            this.radioButton_Put.Location = new System.Drawing.Point(438, 289);
            this.radioButton_Put.Name = "radioButton_Put";
            this.radioButton_Put.Size = new System.Drawing.Size(51, 24);
            this.radioButton_Put.TabIndex = 9;
            this.radioButton_Put.TabStop = true;
            this.radioButton_Put.Text = "Put";
            this.radioButton_Put.UseVisualStyleBackColor = true;
            // 
            // textBox_Trials
            // 
            this.textBox_Trials.Location = new System.Drawing.Point(207, 373);
            this.textBox_Trials.Name = "textBox_Trials";
            this.textBox_Trials.Size = new System.Drawing.Size(100, 26);
            this.textBox_Trials.TabIndex = 10;
            // 
            // button_Go
            // 
            this.button_Go.BackColor = System.Drawing.SystemColors.Control;
            this.button_Go.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Go.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Go.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Go.Location = new System.Drawing.Point(328, 376);
            this.button_Go.Name = "button_Go";
            this.button_Go.Size = new System.Drawing.Size(161, 58);
            this.button_Go.TabIndex = 11;
            this.button_Go.Text = "GO";
            this.button_Go.UseVisualStyleBackColor = false;
            this.button_Go.Click += new System.EventHandler(this.button_GO_Click);
            // 
            // radioButton_Call
            // 
            this.radioButton_Call.AutoSize = true;
            this.radioButton_Call.Location = new System.Drawing.Point(362, 289);
            this.radioButton_Call.Name = "radioButton_Call";
            this.radioButton_Call.Size = new System.Drawing.Size(53, 24);
            this.radioButton_Call.TabIndex = 12;
            this.radioButton_Call.TabStop = true;
            this.radioButton_Call.Text = "Call";
            this.radioButton_Call.UseVisualStyleBackColor = true;
            // 
            // textBox_OptionPrice
            // 
            this.textBox_OptionPrice.Location = new System.Drawing.Point(680, 119);
            this.textBox_OptionPrice.Name = "textBox_OptionPrice";
            this.textBox_OptionPrice.Size = new System.Drawing.Size(100, 26);
            this.textBox_OptionPrice.TabIndex = 13;
            // 
            // label_Spot
            // 
            this.label_Spot.AutoSize = true;
            this.label_Spot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Spot.Location = new System.Drawing.Point(22, 127);
            this.label_Spot.Name = "label_Spot";
            this.label_Spot.Size = new System.Drawing.Size(161, 20);
            this.label_Spot.TabIndex = 14;
            this.label_Spot.Text = "Underlying Spot Price";
            // 
            // label_Strike
            // 
            this.label_Strike.AutoSize = true;
            this.label_Strike.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Strike.Location = new System.Drawing.Point(22, 168);
            this.label_Strike.Name = "label_Strike";
            this.label_Strike.Size = new System.Drawing.Size(140, 20);
            this.label_Strike.TabIndex = 15;
            this.label_Strike.Text = "Option Strike Price";
            // 
            // label_Rate
            // 
            this.label_Rate.AutoSize = true;
            this.label_Rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Rate.Location = new System.Drawing.Point(22, 243);
            this.label_Rate.Name = "label_Rate";
            this.label_Rate.Size = new System.Drawing.Size(107, 20);
            this.label_Rate.TabIndex = 16;
            this.label_Rate.Text = "Riskfree Rate";
            // 
            // label_Tenor
            // 
            this.label_Tenor.AutoSize = true;
            this.label_Tenor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Tenor.Location = new System.Drawing.Point(22, 207);
            this.label_Tenor.Name = "label_Tenor";
            this.label_Tenor.Size = new System.Drawing.Size(50, 20);
            this.label_Tenor.TabIndex = 17;
            this.label_Tenor.Text = "Tenor";
            // 
            // label_Vol
            // 
            this.label_Vol.AutoSize = true;
            this.label_Vol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Vol.Location = new System.Drawing.Point(22, 287);
            this.label_Vol.Name = "label_Vol";
            this.label_Vol.Size = new System.Drawing.Size(67, 20);
            this.label_Vol.TabIndex = 18;
            this.label_Vol.Text = "Volatility";
            // 
            // label_Trials
            // 
            this.label_Trials.AutoSize = true;
            this.label_Trials.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Trials.Location = new System.Drawing.Point(22, 379);
            this.label_Trials.Name = "label_Trials";
            this.label_Trials.Size = new System.Drawing.Size(108, 20);
            this.label_Trials.TabIndex = 19;
            this.label_Trials.Text = "# of Sim Trials";
            // 
            // label_Steps
            // 
            this.label_Steps.AutoSize = true;
            this.label_Steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Steps.Location = new System.Drawing.Point(22, 411);
            this.label_Steps.Name = "label_Steps";
            this.label_Steps.Size = new System.Drawing.Size(143, 20);
            this.label_Steps.TabIndex = 20;
            this.label_Steps.Text = "# of Steps in Paths";
            // 
            // label_Inputs
            // 
            this.label_Inputs.AutoSize = true;
            this.label_Inputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Inputs.Location = new System.Drawing.Point(22, 69);
            this.label_Inputs.Name = "label_Inputs";
            this.label_Inputs.Size = new System.Drawing.Size(226, 20);
            this.label_Inputs.TabIndex = 21;
            this.label_Inputs.Text = "Enter Pricing Inputs Below:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(501, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Pricing Ouput:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(543, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Option Price";
            // 
            // textBox_Delta
            // 
            this.textBox_Delta.Location = new System.Drawing.Point(680, 162);
            this.textBox_Delta.Name = "textBox_Delta";
            this.textBox_Delta.Size = new System.Drawing.Size(100, 26);
            this.textBox_Delta.TabIndex = 24;
            // 
            // textBox_Gamma
            // 
            this.textBox_Gamma.Location = new System.Drawing.Point(680, 204);
            this.textBox_Gamma.Name = "textBox_Gamma";
            this.textBox_Gamma.Size = new System.Drawing.Size(100, 26);
            this.textBox_Gamma.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(543, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Delta";
            // 
            // label_Gamma
            // 
            this.label_Gamma.AutoSize = true;
            this.label_Gamma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Gamma.Location = new System.Drawing.Point(543, 207);
            this.label_Gamma.Name = "label_Gamma";
            this.label_Gamma.Size = new System.Drawing.Size(66, 20);
            this.label_Gamma.TabIndex = 27;
            this.label_Gamma.Text = "Gamma";
            // 
            // textBox_Drift
            // 
            this.textBox_Drift.Location = new System.Drawing.Point(204, 330);
            this.textBox_Drift.Name = "textBox_Drift";
            this.textBox_Drift.Size = new System.Drawing.Size(100, 26);
            this.textBox_Drift.TabIndex = 28;
            // 
            // label_Drift
            // 
            this.label_Drift.AutoSize = true;
            this.label_Drift.Location = new System.Drawing.Point(22, 330);
            this.label_Drift.Name = "label_Drift";
            this.label_Drift.Size = new System.Drawing.Size(39, 20);
            this.label_Drift.TabIndex = 29;
            this.label_Drift.Text = "Drift";
            // 
            // textBox_Theta
            // 
            this.textBox_Theta.Location = new System.Drawing.Point(680, 246);
            this.textBox_Theta.Name = "textBox_Theta";
            this.textBox_Theta.Size = new System.Drawing.Size(100, 26);
            this.textBox_Theta.TabIndex = 30;
            // 
            // label_Theta
            // 
            this.label_Theta.AutoSize = true;
            this.label_Theta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Theta.Location = new System.Drawing.Point(543, 246);
            this.label_Theta.Name = "label_Theta";
            this.label_Theta.Size = new System.Drawing.Size(50, 20);
            this.label_Theta.TabIndex = 32;
            this.label_Theta.Text = "Theta";
            // 
            // label_Vega
            // 
            this.label_Vega.AutoSize = true;
            this.label_Vega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Vega.Location = new System.Drawing.Point(546, 287);
            this.label_Vega.Name = "label_Vega";
            this.label_Vega.Size = new System.Drawing.Size(47, 20);
            this.label_Vega.TabIndex = 33;
            this.label_Vega.Text = "Vega";
            // 
            // textBox_Vega
            // 
            this.textBox_Vega.Location = new System.Drawing.Point(680, 287);
            this.textBox_Vega.Name = "textBox_Vega";
            this.textBox_Vega.Size = new System.Drawing.Size(100, 26);
            this.textBox_Vega.TabIndex = 34;
            // 
            // label_StdErr
            // 
            this.label_StdErr.AutoSize = true;
            this.label_StdErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_StdErr.Location = new System.Drawing.Point(524, 396);
            this.label_StdErr.Name = "label_StdErr";
            this.label_StdErr.Size = new System.Drawing.Size(114, 20);
            this.label_StdErr.TabIndex = 35;
            this.label_StdErr.Text = "Standard Error";
            // 
            // textBox_StdErr
            // 
            this.textBox_StdErr.Location = new System.Drawing.Point(680, 396);
            this.textBox_StdErr.Name = "textBox_StdErr";
            this.textBox_StdErr.Size = new System.Drawing.Size(100, 26);
            this.textBox_StdErr.TabIndex = 36;
            // 
            // label_Rho
            // 
            this.label_Rho.AutoSize = true;
            this.label_Rho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Rho.Location = new System.Drawing.Point(551, 339);
            this.label_Rho.Name = "label_Rho";
            this.label_Rho.Size = new System.Drawing.Size(39, 20);
            this.label_Rho.TabIndex = 37;
            this.label_Rho.Text = "Rho";
            // 
            // textBox_Rho
            // 
            this.textBox_Rho.Location = new System.Drawing.Point(680, 336);
            this.textBox_Rho.Name = "textBox_Rho";
            this.textBox_Rho.Size = new System.Drawing.Size(100, 26);
            this.textBox_Rho.TabIndex = 38;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(857, 501);
            this.Controls.Add(this.textBox_Rho);
            this.Controls.Add(this.label_Rho);
            this.Controls.Add(this.textBox_StdErr);
            this.Controls.Add(this.label_StdErr);
            this.Controls.Add(this.textBox_Vega);
            this.Controls.Add(this.label_Vega);
            this.Controls.Add(this.label_Theta);
            this.Controls.Add(this.textBox_Theta);
            this.Controls.Add(this.label_Drift);
            this.Controls.Add(this.textBox_Drift);
            this.Controls.Add(this.label_Gamma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Gamma);
            this.Controls.Add(this.textBox_Delta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Inputs);
            this.Controls.Add(this.label_Steps);
            this.Controls.Add(this.label_Trials);
            this.Controls.Add(this.label_Vol);
            this.Controls.Add(this.label_Tenor);
            this.Controls.Add(this.label_Rate);
            this.Controls.Add(this.label_Strike);
            this.Controls.Add(this.label_Spot);
            this.Controls.Add(this.textBox_OptionPrice);
            this.Controls.Add(this.radioButton_Call);
            this.Controls.Add(this.button_Go);
            this.Controls.Add(this.textBox_Trials);
            this.Controls.Add(this.radioButton_Put);
            this.Controls.Add(this.radioButton_Bermudan);
            this.Controls.Add(this.radioButton_American);
            this.Controls.Add(this.radioButton_European);
            this.Controls.Add(this.textBox_Steps);
            this.Controls.Add(this.textBox_Volatility);
            this.Controls.Add(this.textBox_Rate);
            this.Controls.Add(this.textBox_Tenor);
            this.Controls.Add(this.textBox_Strike);
            this.Controls.Add(this.textBox_Spot);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Spot;
        private System.Windows.Forms.TextBox textBox_Strike;
        private System.Windows.Forms.TextBox textBox_Tenor;
        private System.Windows.Forms.TextBox textBox_Rate;
        private System.Windows.Forms.TextBox textBox_Volatility;
        private System.Windows.Forms.TextBox textBox_Steps;
        private System.Windows.Forms.RadioButton radioButton_European;
        private System.Windows.Forms.RadioButton radioButton_American;
        private System.Windows.Forms.RadioButton radioButton_Bermudan;
        private System.Windows.Forms.RadioButton radioButton_Put;
        private System.Windows.Forms.TextBox textBox_Trials;
        private System.Windows.Forms.Button button_Go;
        private System.Windows.Forms.RadioButton radioButton_Call;
        private System.Windows.Forms.TextBox textBox_OptionPrice;
        private System.Windows.Forms.Label label_Spot;
        private System.Windows.Forms.Label label_Strike;
        private System.Windows.Forms.Label label_Rate;
        private System.Windows.Forms.Label label_Tenor;
        private System.Windows.Forms.Label label_Vol;
        private System.Windows.Forms.Label label_Trials;
        private System.Windows.Forms.Label label_Steps;
        private System.Windows.Forms.Label label_Inputs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Delta;
        private System.Windows.Forms.TextBox textBox_Gamma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Gamma;
        private System.Windows.Forms.TextBox textBox_Drift;
        private System.Windows.Forms.Label label_Drift;
        private System.Windows.Forms.TextBox textBox_Theta;
        private System.Windows.Forms.Label label_Theta;
        private System.Windows.Forms.Label label_Vega;
        private System.Windows.Forms.TextBox textBox_Vega;
        private System.Windows.Forms.Label label_StdErr;
        private System.Windows.Forms.TextBox textBox_StdErr;
        private System.Windows.Forms.Label label_Rho;
        private System.Windows.Forms.TextBox textBox_Rho;
    }
}

