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
using Timer_Plugin.Timer_Window.Forms;

namespace Timer_Plugin
{
    public partial class Time_Form : Form
    {
        
        public static bool IsFormOpen = false;
        int current_time, prev_time;


        public Time_Form()
        {

            InitializeComponent();
            
            IsFormOpen = true;
            if (TimerWindowPackage.IsSolutionOpened)
            {
                //Изменение данных метки
                label1.Visible = true;
                Data_button.Enabled = true;
                label2.Text = "Проведено времени в Visual Studio сегодня:";
                prev_time = current_time;
                //Расчет времени
                current_time = TimerWindowPackage.s.Elapsed.Seconds + TimerWindowPackage.s.Elapsed.Minutes*60 + TimerWindowPackage.s.Elapsed.Hours * 3600;
                if (TimerWindowPackage.s.Elapsed.Seconds > 60)
                {
                    MessageBox.Show(TimerWindowPackage.s.Elapsed.Seconds.ToString());
                }
                //current_datetime = Converter.TimeConverterToDate(current_time);
                label1.Text = Converter.TimeConverterToDate(current_time + TimerWindowPackage.time).ToString("HH:mm:ss");
                  

                //Таймер для обновления времени
                Timer timer = new Timer();
                timer.Interval = 1000;
                timer.Enabled = true;
                timer.Tick += new EventHandler(write_tick);

                
            }
            else
            {
                label1.Visible = false;
                Data_button.Enabled = false;
                label2.Text = "Для отслеживания времени необходимо войти в проект";
                
            } 
        }

        private void write_tick(object sender, EventArgs e)
        {
            if (prev_time < current_time)
            {
                prev_time = current_time;
            }

            current_time++;

            if (prev_time >= current_time)
            {
                MessageBox.Show(prev_time.ToString() + "\n" + current_time.ToString());
            }

            label1.Text = Converter.TimeConverterToDate(current_time + TimerWindowPackage.time).ToString("HH:mm:ss"); ;
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            IsFormOpen = false;
            Close();
        }

        private void Data_button_Click(object sender, EventArgs e)
        {
            DataForm dataform = new DataForm();
            dataform.Show();
            Close();
        }

        
        private void Time_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsFormOpen = false;
        }
    }
}
