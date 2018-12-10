namespace Timer_Plugin.Timer_Window.Forms
{
    partial class DataForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Exit_info = new System.Windows.Forms.Button();
            this.Go_to_timer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(344, 238);
            this.listBox1.TabIndex = 1;
            // 
            // Exit_info
            // 
            this.Exit_info.Location = new System.Drawing.Point(362, 12);
            this.Exit_info.Name = "Exit_info";
            this.Exit_info.Size = new System.Drawing.Size(75, 23);
            this.Exit_info.TabIndex = 2;
            this.Exit_info.Text = "Закрыть";
            this.Exit_info.UseVisualStyleBackColor = true;
            this.Exit_info.Click += new System.EventHandler(this.Exit_info_Click);
            // 
            // Go_to_timer
            // 
            this.Go_to_timer.Location = new System.Drawing.Point(362, 41);
            this.Go_to_timer.Name = "Go_to_timer";
            this.Go_to_timer.Size = new System.Drawing.Size(75, 37);
            this.Go_to_timer.TabIndex = 3;
            this.Go_to_timer.Text = " Открыть таймер";
            this.Go_to_timer.UseVisualStyleBackColor = true;
            this.Go_to_timer.Click += new System.EventHandler(this.Go_to_timer_Click);
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 264);
            this.Controls.Add(this.Go_to_timer);
            this.Controls.Add(this.Exit_info);
            this.Controls.Add(this.listBox1);
            this.Name = "DataForm";
            this.Text = "Сводка";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Exit_info;
        private System.Windows.Forms.Button Go_to_timer;
    }
}