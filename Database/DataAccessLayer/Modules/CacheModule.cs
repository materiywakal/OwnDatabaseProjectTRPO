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
            using (FileStream _fileStream = new FileStream("./DataBases/" + db.Name + ".soos", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                //
                //buf key
                byte[] key = new byte[1] { 1 };
                //
                MemoryStream streamOfEncryptedDataBase = EncryptionModule.EncryptDataBase(db, key);

                streamOfEncryptedDataBase.Position = 0;
                streamOfEncryptedDataBase.WriteTo(_fileStream);
                streamOfEncryptedDataBase.Close();
                _fileStream.Close();
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
