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
        private DateTime current_datetime = new DateTime();
        public static bool IsFormOpen = false;
        private TimeSpan interval;       
        private TimeSpan time_add = new TimeSpan(0, 0, 0, 1);
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

                //Расчет времени и отображение в формате HH:mm:ss, конвертируя дни в часы
                int current_time = TimerWindowPackage.time + TimerWindowPackage.s.Elapsed.Seconds;
                current_datetime = Converter.TimeConverterToDate(current_time);
                DateTime help = new DateTime();
                interval = current_datetime - help;
                String curr = Math.Round(interval.TotalHours) + ":" + interval.Minutes + ":" + interval.Seconds;
                label1.Text = curr;  

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
            interval = interval.Add(time_add);
            String curr = Math.Round(interval.TotalHours) + ":" + interval.Minutes + ":" + interval.Seconds;
            label1.Text = curr;
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
