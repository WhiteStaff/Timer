using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Timer_Plugin
{
    public partial class Time_Form : Form
    {
        public Time_Form()
        {


            

            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = 50;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);

            //label1.Text = DateTime.Now.ToString("HH:mm:ss");


        }

        /*private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            (DateTime.Now.ToString("HH:mm:ss"));
           
        }*/

        private void timer_Tick(object sender, EventArgs e)
        {
            //InitializeComponent();
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
            label1.Update();
        }
    }
}
