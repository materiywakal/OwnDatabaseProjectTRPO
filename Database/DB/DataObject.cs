using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DataObject
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
    }
}
