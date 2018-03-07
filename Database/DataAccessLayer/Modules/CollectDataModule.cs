using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityLayer;
using System.IO;

namespace DataAccessLayer.Modules
{
    static class CollectDataModule
    {
        static internal DataLayer.DataBaseInstance LoadDataBase(string DBName)
        {
            DataLayer.DataBaseInstance dbObject = new DataLayer.DataBaseInstance("nullDB");
            string[] _filePaths = System.IO.Directory.GetFiles("./DataBases", "*.soos");
            if (_filePaths.Contains<string>(DBName))
            {
                StreamReader _reader = new StreamReader("./DataBases/" + DBName+".soos");
                byte[] _array = new byte[0];
                for (int j = 0; j < 0; j++)
                {
                    _array[j] = Convert.ToByte(_reader.Read());
                }
                //buf key
                byte[] key = new byte[1] { 1 };
                //
                dbObject = SecurityLayer.Modules.DecryptionModule.DecryptDataBase(_array, key);
            }
            return dbObject;
        }
        static internal List<DataLayer.DataBaseInstance> LoadAllDataBases()
        {
            List<DataLayer.DataBaseInstance> bufList = new List<DataLayer.DataBaseInstance>();
            if (SharedDataAccessMethods.isDirectoryExists())
            {
                string[] _filePaths = System.IO.Directory.GetFiles("./DataBases", "*.soos");
                for (int i = 0; i < _filePaths.Length; i++)
                {
                    StreamReader _reader = new StreamReader(_filePaths[i]);
                    byte[] _array = new byte[0];
                    for (int j = 0; j < 0; j++)
                    {
                        _array[j] = Convert.ToByte(_reader.Read());
                    }
                    //buf key
                    byte[] key = new byte[1] { 1 };
                    //
                    bufList.Add(SecurityLayer.Modules.DecryptionModule.DecryptDataBase(_array, key));
                }
            }
            else SharedDataAccessMethods.CreateDatabasesDirectory();
            return bufList;
        }
    }
}
