using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Timer_Plugin.Timer_Window.Data
{
    [DataContract]
    public class Time
    {
        [DataMember]
        public int Mytime { get; set; }
        [DataMember]
        public DateTime Mydate { get; set;}
        
        public Time(DateTime date, int time)
        {
            Mydate = date;
            Mytime = time;
        }
        
    }

    class OpenData
    {

        static DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Time[]));
        public static int OpenMyData()
        {
            int TimeData=0;
            //WriteToFile();
            using (FileStream fs = new FileStream("TimeData.json", FileMode.OpenOrCreate))
            {
                try
                {
                    Time[] newpeople = (Time[])jsonFormatter.ReadObject(fs);
                    int sfgdsf = 0;
                    foreach (Time p in newpeople)
                    {
                        TimeData = p.Mytime;
                        sfgdsf++;
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            return (TimeData);
        }   

        public static void WriteToFile(DateTime date, int data)
        {
            /*DateTime date1 = DateTime.Now.Date;
            DateTime date2 = new DateTime(2008, 3, 1, 7, 0, 0).Date;*/
            
            Time time1 = new Time(date, data);
            //Time time2 = new Time(date2, 23842);
            Time[] times = new Time[] { time1 };
            using (FileStream fs = new FileStream("TimeData.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, times);
                
            }
        }
    }
}
