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
        
        public Time(int time)
        {
            Mytime = time;
        }
    }

    class OpenData
    {

        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Time[]));
        public int OpenMyData()
        {
            int TimeData=0;
            /*using (FileStream fstream = File.OpenRead(@"H:\проекты\Timer_Plugin\Timer_Plugin\Timer_Plugin\input.bin"))
            {
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                TimeData = Int32.Parse(textFromFile);
                fstream.Close();
            }*/
            
            

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

        public void WriteToFile(int data)
        {

            Time time1 = new Time(data);
            Time[] times = new Time[] { time1 };
            using (FileStream fs = new FileStream("TimeData.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, times);
            }
        }
    }
}
