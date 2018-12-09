using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

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
            
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Time[]));

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                Time[] newpeople = (Time[])jsonFormatter.ReadObject(fs);

                foreach (Time p in newpeople)
                {
                    TimeData = p.Mytime;
                }
            }

            return (TimeData);
        }   

        public void WriteToFile(string data)
        {
            using (FileStream fstream = new FileStream(@"H:\проекты\Timer_Plugin\Timer_Plugin\Timer_Plugin\input.bin", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(data);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                
            }
        }
    }
}
