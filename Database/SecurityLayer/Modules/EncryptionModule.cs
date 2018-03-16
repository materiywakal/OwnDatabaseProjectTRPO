using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityLayer.Modules;

namespace SecurityLayer.Modules
{
    internal class EncryptionModule
    {
        static public MemoryStream EncryptDataBase(DataLayer.DataBaseInstance _dataToCrypt, byte[] _key)
        {
            byte[] _outputData = SharedCryptingMethods.DatabaseObjectToByteArray(_dataToCrypt);
            //Encrypt will be here


            //end of encrypt

            return new MemoryStream(_outputData);
        }
    }
}
