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
        public static int OpenMyData(DateTime current_date)
        {
            int TimeData=0;
            bool IsDateExists = false;            
            using (FileStream fs = new FileStream("TimeData.json", FileMode.OpenOrCreate))
            {
                try
                {
                    Time[] newpeople = (Time[])jsonFormatter.ReadObject(fs);                    
                    foreach (Time p in newpeople)
                    {
                        DataDictionary.time_dictionary.Add(p.Mydate.Date, p.Mytime);
                        if (p.Mydate.Date == current_date.Date)
                        {
                            IsDateExists = true;
                        }
                    }
                }
                catch(Exception e)
                {
                    DataDictionary.time_dictionary.Add(DateTime.Now.Date, 0);
                    IsDateExists = true;
                }
            }

            if (!IsDateExists)
            {
                DataDictionary.time_dictionary.Add(DateTime.Now.Date, 0);
                return (0);
            }

            return (TimeData);
        }   

        public static void WriteToFile(int time)
        {
            
            Time[] times = new Time[DataDictionary.time_dictionary.Count];
            DataDictionary.time_dictionary.Remove(DateTime.Now.Date);
            Time newtime = new Time(DateTime.Now.Date, time);
            times[0] = newtime;
            for (int i = 0; i < DataDictionary.time_dictionary.Count; i++)
            {
                var last_value = DataDictionary.time_dictionary.Values.Last();
                var last_key = DataDictionary.time_dictionary.Keys.Last();
                newtime = new Time(last_key, last_value);
                times[i+1] = newtime;
                DataDictionary.time_dictionary.Remove(last_key);
            }

            using (FileStream fs = new FileStream("TimeData.json", FileMode.OpenOrCreate))
            {
                
                jsonFormatter.WriteObject(fs, times);
                
                
            }
        }
    }
}
