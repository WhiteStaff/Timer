using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer_Plugin.Timer_Window.Data;

namespace Timer_Plugin.Timer_Window.Forms
{
    public partial class DataForm : Form
    {
        public static bool IsDataFormOpen = false;
        public DataForm()
        {
            
            InitializeComponent();
            IsDataFormOpen = true;
            foreach(var p in DataDictionary.time_dictionary)
            {
                var last_value = p.Value;
                var last_key = p.Key;
                //copy.Remove(last_key);
                if (last_key == DateTime.Now.Date)
                {
                    last_value += TimerWindowPackage.s.Elapsed.Seconds + TimerWindowPackage.s.Elapsed.Minutes * 60 + TimerWindowPackage.s.Elapsed.Hours * 3600;
                }
                string line = "Дата: " + last_key.Date.ToString("dd/MM/yyyy") + "    Потрачено времени: " + Converter.TimeConverterToDate(last_value).ToString("HH:mm:ss");
                listBox1.Items.Add(line);
            }
            
        }

        private void Exit_info_Click(object sender, EventArgs e)
        {
            
            Close();
            IsDataFormOpen = false;
        }

        private void Go_to_timer_Click(object sender, EventArgs e)
        {
            
            Timer_Plugin.Time_Form newForm1 = new Timer_Plugin.Time_Form();
            newForm1.Show();
            Close();
            IsDataFormOpen = false;
        }

        private void DataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsDataFormOpen = false;
        }
    }
}
