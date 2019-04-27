using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationAndDeserializationLib
{
    interface IOperation<T>
    {
        void Serialize(T dataToSerialize, string filePath);
          T  DeSerialize(string filePath);
    }
}
