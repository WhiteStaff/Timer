using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer_Plugin.Timer_Window.Data
{
    class Converter
    {
        public static DateTime TimeConverterToDate(int time_in_sec)
        {
            DateTime correct_time = new DateTime();
            correct_time = correct_time.AddHours(time_in_sec / 3600);
            correct_time = correct_time.AddMinutes(time_in_sec % 3600 / 60);
            correct_time = correct_time.AddSeconds(time_in_sec % 60);
            return correct_time;
        }

        public static int TimeConverterToSec()
        {
            int seconds = 0;
            seconds = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
            return seconds;
        }
    }
}
