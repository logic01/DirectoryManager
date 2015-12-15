namespace DirectoryManager.Desktop
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button_dirPath1 = new System.Windows.Forms.Button();
            this.button_dirPath2 = new System.Windows.Forms.Button();
            this.button_dirPath3 = new System.Windows.Forms.Button();
            this.textBox_dirPath1 = new System.Windows.Forms.TextBox();
            this.textBox_dirPath2 = new System.Windows.Forms.TextBox();
            this.textBox_dirPath3 = new System.Windows.Forms.TextBox();
            this.button_calc = new System.Windows.Forms.Button();
            this.label_dirPath3 = new System.Windows.Forms.Label();
            this.label_dirPath2 = new System.Windows.Forms.Label();
            this.label_dirPath1 = new System.Windows.Forms.Label();
            this.label_tot = new System.Windows.Forms.Label();
            this.label_log = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_dirPath1
            // 
            this.button_dirPath1.Location = new System.Drawing.Point(315, 43);
            this.button_dirPath1.Name = "button_dirPath1";
            this.button_dirPath1.Size = new System.Drawing.Size(30, 23);
            this.button_dirPath1.TabIndex = 0;
            this.button_dirPath1.Text = "...";
            this.button_dirPath1.UseVisualStyleBackColor = true;
            this.button_dirPath1.Click += new System.EventHandler(this.button_dirPath1_Click);
            // 
            // button_dirPath2
            // 
            this.button_dirPath2.Location = new System.Drawing.Point(315, 90);
            this.button_dirPath2.Name = "button_dirPath2";
            this.button_dirPath2.Size = new System.Drawing.Size(30, 23);
            this.button_dirPath2.TabIndex = 1;
            this.button_dirPath2.Text = "...";
            this.button_dirPath2.UseVisualStyleBackColor = true;
            this.button_dirPath2.Click += new System.EventHandler(this.button_dirPath2_Click);
            // 
            // button_dirPath3
            // 
            this.button_dirPath3.Location = new System.Drawing.Point(315, 131);
            this.button_dirPath3.Name = "button_dirPath3";
            this.button_dirPath3.Size = new System.Drawing.Size(30, 23);
            this.button_dirPath3.TabIndex = 2;
            this.button_dirPath3.Text = "...";
            this.button_dirPath3.UseVisualStyleBackColor = true;
            this.button_dirPath3.Click += new System.EventHandler(this.button_dirPath3_Click);
            // 
            // textBox_dirPath1
            // 
            this.textBox_dirPath1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox_dirPath1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox_dirPath1.Location = new System.Drawing.Point(12, 43);
            this.textBox_dirPath1.Name = "textBox_dirPath1";
            this.textBox_dirPath1.ReadOnly = true;
            this.textBox_dirPath1.Size = new System.Drawing.Size(297, 20);
            this.textBox_dirPath1.TabIndex = 3;
            this.textBox_dirPath1.Text = "C:\\";
            // 
            // textBox_dirPath2
            // 
            this.textBox_dirPath2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox_dirPath2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox_dirPath2.Location = new System.Drawing.Point(12, 90);
            this.textBox_dirPath2.Name = "textBox_dirPath2";
            this.textBox_dirPath2.ReadOnly = true;
            this.textBox_dirPath2.Size = new System.Drawing.Size(297, 20);
            this.textBox_dirPath2.TabIndex = 4;
            this.textBox_dirPath2.Text = "C:\\";
            // 
            // textBox_dirPath3
            // 
            this.textBox_dirPath3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox_dirPath3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox_dirPath3.Location = new System.Drawing.Point(12, 131);
            this.textBox_dirPath3.Name = "textBox_dirPath3";
            this.textBox_dirPath3.ReadOnly = true;
            this.textBox_dirPath3.Size = new System.Drawing.Size(297, 20);
            this.textBox_dirPath3.TabIndex = 5;
            this.textBox_dirPath3.Text = "C:\\";
            // 
            // button_calc
            // 
            this.button_calc.Location = new System.Drawing.Point(270, 169);
            this.button_calc.Name = "button_calc";
            this.button_calc.Size = new System.Drawing.Size(75, 23);
            this.button_calc.TabIndex = 6;
            this.button_calc.Text = "Calculate";
            this.button_calc.UseVisualStyleBackColor = true;
            this.button_calc.Click += new System.EventHandler(this.button_calc_Click);
            // 
            // label_dirPath3
            // 
            this.label_dirPath3.AutoSize = true;
            this.label_dirPath3.Location = new System.Drawing.Point(351, 134);
            this.label_dirPath3.Name = "label_dirPath3";
            this.label_dirPath3.Size = new System.Drawing.Size(22, 13);
            this.label_dirPath3.TabIndex = 7;
            this.label_dirPath3.Text = "0.0";
            // 
            // label_dirPath2
            // 
            this.label_dirPath2.AutoSize = true;
            this.label_dirPath2.Location = new System.Drawing.Point(351, 93);
            this.label_dirPath2.Name = "label_dirPath2";
            this.label_dirPath2.Size = new System.Drawing.Size(22, 13);
            this.label_dirPath2.TabIndex = 8;
            this.label_dirPath2.Text = "0.0";
            // 
            // label_dirPath1
            // 
            this.label_dirPath1.AutoSize = true;
            this.label_dirPath1.Location = new System.Drawing.Point(351, 46);
            this.label_dirPath1.Name = "label_dirPath1";
            this.label_dirPath1.Size = new System.Drawing.Size(22, 13);
            this.label_dirPath1.TabIndex = 9;
            this.label_dirPath1.Text = "0.0";
            // 
            // label_tot
            // 
            this.label_tot.AutoSize = true;
            this.label_tot.Location = new System.Drawing.Point(351, 174);
            this.label_tot.Name = "label_tot";
            this.label_tot.Size = new System.Drawing.Size(22, 13);
            this.label_tot.TabIndex = 10;
            this.label_tot.Text = "0.0";
            // 
            // label_log
            // 
            this.label_log.BackColor = System.Drawing.SystemColors.Control;
            this.label_log.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_log.Location = new System.Drawing.Point(12, 202);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(361, 151);
            this.label_log.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 387);
            this.Controls.Add(this.label_log);
            this.Controls.Add(this.label_tot);
            this.Controls.Add(this.label_dirPath1);
            this.Controls.Add(this.label_dirPath2);
            this.Controls.Add(this.label_dirPath3);
            this.Controls.Add(this.button_calc);
            this.Controls.Add(this.textBox_dirPath3);
            this.Controls.Add(this.textBox_dirPath2);
            this.Controls.Add(this.textBox_dirPath1);
            this.Controls.Add(this.button_dirPath3);
            this.Controls.Add(this.button_dirPath2);
            this.Controls.Add(this.button_dirPath1);
            this.Name = "Form1";
            this.Text = "DirectoryManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button_dirPath1;
        private System.Windows.Forms.Button button_dirPath2;
        private System.Windows.Forms.Button button_dirPath3;
        private System.Windows.Forms.TextBox textBox_dirPath1;
        private System.Windows.Forms.TextBox textBox_dirPath2;
        private System.Windows.Forms.TextBox textBox_dirPath3;
        private System.Windows.Forms.Button button_calc;
        private System.Windows.Forms.Label label_dirPath3;
        private System.Windows.Forms.Label label_dirPath2;
        private System.Windows.Forms.Label label_dirPath1;
        private System.Windows.Forms.Label label_tot;
        private System.Windows.Forms.Label label_log;
    }
}

