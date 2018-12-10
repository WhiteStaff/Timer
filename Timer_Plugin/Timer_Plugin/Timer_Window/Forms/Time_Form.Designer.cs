namespace Timer_Plugin
{
    partial class Time_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Exit_button = new System.Windows.Forms.Button();
            this.Data_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Проведено времени в Visual Studio сегодня:";
            // 
            // Exit_button
            // 
            this.Exit_button.Location = new System.Drawing.Point(233, 65);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(75, 23);
            this.Exit_button.TabIndex = 2;
            this.Exit_button.Text = "Закрыть";
            this.Exit_button.UseVisualStyleBackColor = true;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // Data_button
            // 
            this.Data_button.Location = new System.Drawing.Point(12, 65);
            this.Data_button.Name = "Data_button";
            this.Data_button.Size = new System.Drawing.Size(75, 23);
            this.Data_button.TabIndex = 3;
            this.Data_button.Text = "Сводка";
            this.Data_button.UseVisualStyleBackColor = true;
            this.Data_button.Click += new System.EventHandler(this.Data_button_Click);
            // 
            // Time_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 100);
            this.Controls.Add(this.Data_button);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.Name = "Time_Form";
            this.Text = "Справка о времени";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Time_Form_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Exit_button;
        private System.Windows.Forms.Button Data_button;
    }
}