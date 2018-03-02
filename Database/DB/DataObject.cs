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

        public int DataHashcode { get => _dataHashcode; set => _dataHashcode = value; }
        public object Data { get => _data; set => _data = value; }

        public DataObject(int hash, object data)
        {
            DataHashcode = hash;
            Data = data;
        }
    }
}
