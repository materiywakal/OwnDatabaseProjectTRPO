using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DB
{
    [Serializable()]
    public class DataObject:ISerializable
    {
        int _dataHashcode;
        object _data;

        public int DataHashcode { get => _dataHashcode; private set => _dataHashcode = value; }
        public object Data { get => _data; private set => _data = value; }

        public DataObject(int hash, object data)
        {
            DataHashcode = hash;
            Data = data;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
