using DataLayer;
using SecurityLayer.Modules;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataAccessLayer.Modules
{
    static class CacheModule
    {
       /// <summary>
       /// DataBase file saving
       /// </summary>
       /// <param name="_dataToSave"></param>
       /// <param name="_dataBaseName"></param>
        static internal void SaveDataBaseToFolder(this DataBaseInstance db)
        {
            if (!SharedDataAccessMethods.isDirectoryExists())
                SharedDataAccessMethods.CreateDatabasesDirectory();

          // this is save to file module
          // and also here should be implemented startup method
          // for kernel instance initialize
            using(StreamWriter _writer = new StreamWriter("./DataBases/" + db.Name + ".soos"))
            {
                //
                //buf key
                byte[] key = new byte[1] { 1 };
                //
                byte[] _dbArrayToSave = EncryptionModule.EncryptDataBase(db, key);
                for (int i = 0; i < _dbArrayToSave.Length; i++)
                    _writer.Write(_dbArrayToSave[i]);
                _writer.Close();
            }
        }
        //
        /// <summary>
        /// Saves or updates all databases from _instance list to folder
        /// </summary>
        internal static void SaveAllDatabases(List<DataBaseInstance> listDB)
        {
            if (listDB.Count != 0)
            {
                if(!SharedDataAccessMethods.isDirectoryExists())
                SharedDataAccessMethods.CreateDatabasesDirectory();
                foreach (DataBaseInstance bufInst in listDB)
                    bufInst.SaveDataBaseToFolder();
            }
            else throw new ArgumentNullException("There is no Databases to save!");
        }

    }
}
