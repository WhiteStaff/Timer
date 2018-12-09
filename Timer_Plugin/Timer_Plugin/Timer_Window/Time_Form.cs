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
using Timer_Plugin.Timer_Window.Data;
using Timer_Plugin.Timer_Window;


namespace Timer_Plugin
{
    public partial class Time_Form : Form
    {
        int current_time;
        
        public Time_Form()
        {          
            InitializeComponent();
            current_time  = TimerWindowPackage.GetCurrentTime();
            label1.Text = current_time.ToString();
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(write_tick);
            


        }

        private void write_tick(object sender, EventArgs e)
        {
            current_time++;
            
            label1.Text = current_time.ToString();


        }




    }
}
