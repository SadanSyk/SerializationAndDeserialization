using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationAndDeserializationLib
{
   public class XmlSerialization<T> : IOperation<T>
    {
        public T DeSerialize(string filePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            FileStream stream = new FileStream(filePath, FileMode.Open);
            T serializedData = (T)xs.Deserialize(stream);
            return serializedData;
        }

        public void Serialize(T dataToSerialize, string filePath)
        {

            XmlSerializer xs = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(filePath, FileMode.Create);
            xs.Serialize(fs, dataToSerialize);
            fs.Close();
        }
    }
}
