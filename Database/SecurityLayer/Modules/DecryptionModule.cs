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
    internal class DecryptionModule
    {
        static public DataLayer.DataBaseInstance DecryptDataBase(byte[] _dataToDeCrypt, byte[] _key)
        {
            //Decryption will be here
            DataLayer.DataBaseInstance dbObject = SharedCryptingMethods.ByteArrayToDatabaseObject(_dataToDeCrypt);
            return dbObject;
        }

    }
}
