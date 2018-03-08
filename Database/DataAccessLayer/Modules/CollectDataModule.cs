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
        /// <summary>
        /// Search for such db file in folder and load it
        /// </summary>
        /// <param name="DBName"></param>
        /// <returns></returns>
        static internal DataLayer.DataBaseInstance LoadDataBase(string DBName)
        {
            if (SharedDataAccessMethods.HowManyDBFilesInFolder() == 0) throw new NullReferenceException("There is no DB files in folder");

            string[] _filePaths = System.IO.Directory.GetFiles("./DataBases", "*.soos");
            if (_filePaths.Contains<string>("./DataBases\\"+DBName+".soos"))
            {
                // pa ongleske, pidar
                string _filePath = ("./DataBases\\" + DBName+".soos");

                // pa ongleske, pidar
                byte[] _array = File.ReadAllBytes(_filePath);

                //buf key
                byte[] key = new byte[1] { 1 };

                return SecurityLayer.Modules.DecryptionModule.DecryptDataBase(_array, key);
            }
            return new DataLayer.DataBaseInstance("nullDB"); ;
        }
        /// <summary>
        /// Delete all db instances from list and adds all db files that contains folder
        /// </summary>
        /// <returns></returns>
        static internal List<DataLayer.DataBaseInstance> LoadAllDataBases()
        {
            if (SharedDataAccessMethods.HowManyDBFilesInFolder() == 0) throw new NullReferenceException("There is no DB files in folder");

            List<DataLayer.DataBaseInstance> bufList = new List<DataLayer.DataBaseInstance>();
            if (SharedDataAccessMethods.isDirectoryExists())
            {
                string[] _filePaths = System.IO.Directory.GetFiles("./DataBases", "*.soos");
                for (int i = 0; i < _filePaths.Length; i++)
                {
                    StreamReader _reader = new StreamReader(_filePaths[i]);

                    byte[] _array = File.ReadAllBytes(_filePaths[i]);

                    //buf key
                    byte[] key = new byte[1] { 1 };
                    //
                    bufList.Add(SecurityLayer.Modules.DecryptionModule.DecryptDataBase(_array, key));
                    _reader.Close();
                }
            }
            else SharedDataAccessMethods.CreateDatabasesDirectory();
            return bufList;
        }
        /// <summary>
        /// Taking all db's from folder and adds them to the list, if list doesn't contains db with such name - adds it. Otherwise saves old db object in list (P.S. NO INFO DELETE, ONLY ADDING)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        static internal List<DataLayer.DataBaseInstance> UpdatativeDatabasesLoad(List<DataLayer.DataBaseInstance> list)
        {
            if (SharedDataAccessMethods.HowManyDBFilesInFolder() == 0) return list;
            List<DataLayer.DataBaseInstance> bufList = list;
            DataLayer.DataBaseInstance bufInst;
            if (SharedDataAccessMethods.isDirectoryExists())
            {
                string[] _filePaths = System.IO.Directory.GetFiles("./DataBases", "*.soos");
                for (int i = 0; i < _filePaths.Length; i++)
                {
                    StreamReader _reader = new StreamReader(_filePaths[i]);
                    byte[] _array = File.ReadAllBytes(_filePaths[i]);
                    //buf key
                    byte[] key = new byte[1] { 1 };
                    //
                    bufInst = SecurityLayer.Modules.DecryptionModule.DecryptDataBase(_array, key);
                    if (!bufList.isDatabaseExistsInList((bufInst.Name))) bufList.Add(bufInst);
                    _reader.Close();
                }
            }
            else SharedDataAccessMethods.CreateDatabasesDirectory();
            return bufList;
        }
    }
}
