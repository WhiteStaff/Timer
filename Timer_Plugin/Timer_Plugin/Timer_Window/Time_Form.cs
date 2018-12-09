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


namespace Timer_Plugin
{
    public partial class Time_Form : Form
    {
        DateTime dt = new DateTime();
        
        public Time_Form()
        {
            
            int time = 0;
            OpenData data1 = new OpenData();
            time = data1.OpenMyData();
            dt = dt.AddHours(time / 3600);
            dt = dt.AddMinutes(time % 3600 / 60);
            time = time % 3600 / 60;
            dt = dt.AddSeconds(time % 60);
            
            InitializeComponent();
            label1.Text = dt.ToString("HH:mm:ss");
            Timer timer = new Timer();
            //Timer writetimer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);
           // timer.Tick += new EventHandler(write_tick);


            //label1.Text = DateTime.Now.ToString("HH:mm:ss");


        }

        /*private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            (DateTime.Now.ToString("HH:mm:ss"));
           
        }*/

        private void timer_Tick(object sender, EventArgs e)
        {
            //InitializeComponent();
            dt  = dt.AddSeconds(1);
            label1.Text = dt.ToString("HH:mm:ss");
            label1.Update();
        }

        

        
    }
}
