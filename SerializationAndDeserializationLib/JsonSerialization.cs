using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SerializationAndDeserializationLib
{
    [DataContract]
    public class JsonSerialization<T> : IOperation<T>
    {
        public T DeSerialize(string filePath)
        {   
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);
            T obj = (T)serializer.ReadObject(stream);
            stream.Close();
            stream.Dispose();
            return obj;
        }

        public void Serialize(T dataToSerialize, string filePath)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            FileStream stream = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
            serializer.WriteObject(stream, dataToSerialize);
            stream.Close();

        }
    }
}
