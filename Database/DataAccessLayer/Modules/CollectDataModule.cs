using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityLayer;
using System.IO;

namespace DataAccessLayer.Modules
{
    class CollectDataModule
    {
        static public void LoadDataBase()
        {
            //Ищем нужные файлы
            string[] _filePaths = System.IO.Directory.GetFiles("./DataBases", "*.soos");
            
            //Забираем байты
            for (int i = 0; i < _filePaths.Length; i++)
            {
                

                StreamReader _reader = new StreamReader(_filePaths[i]);
                byte[] _array = new byte[0];
                for (int j = 0; j < 0; j++)
                {
                    _array[j] = Convert.ToByte(_reader.Read());
                }


                
                //Дешифруем и возвращаем в другой модуль


            }
        }
    }
}
