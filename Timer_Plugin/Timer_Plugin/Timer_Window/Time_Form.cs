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
        
        
        public Time_Form()
        {          
            InitializeComponent();
            label1.Text = TimerWindowPackage.timer_time.ToString();
            
        }

        

        
    }
}
