using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Laba7_8wpf
{
    public class Serialization
    {
        public static void Serialaze<T>(T obj)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));


            using (FileStream fs = new FileStream("List.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);

            }
        }
        public static T Des<T>()
        {
            XmlSerializer formatter2 = new XmlSerializer(typeof(T));
            T obj;
            using (FileStream fs = new FileStream("List.xml", FileMode.OpenOrCreate))
            {
                obj = (T)formatter2.Deserialize(fs);
            }
            return obj;
        }
    }
}
