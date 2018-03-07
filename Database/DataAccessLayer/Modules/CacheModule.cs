using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataAccessLayer.Modules
{
    class CacheModule
    {
        //Сохраняем БД
        static public void SaveDataBase(byte[] _dataToSave, string _dataBaseName)
        {
            //Создаем папочку 
            System.IO.Directory.CreateDirectory("./DataBases");

            //Создаем / пересоздаем файл
            StreamWriter _writer = new StreamWriter("./DataBases/" + _dataBaseName + ".soos");

            //Сохраняем!
            for (int i = 0; i < _dataToSave.Length; i++)
                _writer.Write(_dataToSave[i]);
            _writer.Close();
        }
    }
}
