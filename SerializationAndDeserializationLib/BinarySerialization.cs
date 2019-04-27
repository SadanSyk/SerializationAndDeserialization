using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializationAndDeserializationLib
{
    [Serializable]
    public class BinarySerialization<T> : IOperation<T>
    {
        public T DeSerialize(string filePath)
        {
            BinaryFormatter bs = new BinaryFormatter();
            FileStream fs = new FileStream(filePath, FileMode.Open);
            T deserialized = (T)bs.Deserialize(fs);
            fs.Close();     
            fs.Dispose();      
            return deserialized;
        }

        public void Serialize(T dataToSerialize, string filePath)
        {
            FileStream FS = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(FS, dataToSerialize);
            FS.Close();  

        }
    }
}
