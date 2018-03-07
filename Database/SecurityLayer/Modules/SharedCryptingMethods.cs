using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SecurityLayer.Modules
{
    internal class SharedCryptingMethods
    {
        static internal byte[] DatabaseObjectToByteArray(DataLayer.DataBaseInstance _obj)
        {
            if (_obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, _obj);
                return ms.ToArray();
            }
        }
        static internal DataLayer.DataBaseInstance ByteArrayToDatabaseObject(byte[] dbObjectArray)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();

            memStream.Write(dbObjectArray, 0, dbObjectArray.Length);
            memStream.Seek(0, SeekOrigin.Begin);

            DataLayer.DataBaseInstance dbObject = (DataLayer.DataBaseInstance)binForm.Deserialize(memStream);
            return dbObject;
        }
    }
}
