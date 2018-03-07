using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityLayer.Modules;

namespace SecurityLayer.Modules
{
    internal class EncryptionModule
    {
        static public byte[] EncryptDataBase(DataLayer.DataBaseInstance _dataToCrypt, byte[] _key)
        {
            byte[] _outputData = SharedCryptingMethods.DatabaseObjectToByteArray(_dataToCrypt);
            //Encrypt will be here
            return _outputData;
        }
    }
}
