using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataAccessLayer.Modules
{
    static class SharedDataAccessMethods
    {
        static internal void CreateDatabasesDirectory()
        {
            System.IO.Directory.CreateDirectory("./DataBases");
        }
        static internal bool isDirectoryExists()
        {
            if (Directory.Exists("./Databases")) return true;
            return false;
        }
        static internal bool isDatabaseExistsInList(this List<DataLayer.DataBaseInstance> list,string Name)
        {
            foreach (DataLayer.DataBaseInstance db in list)
                if (db.Name == Name) return true;
            return false;
        }
        static internal int IndexOfDatabase(this  List<DataLayer.DataBaseInstance> list, string Name)
        {
            if (list.isDatabaseExistsInList(Name))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Name == Name) return i;
                }
            }
            else throw new ArgumentException("There is no such Database in list!");
            return -1;
            
        }
        static internal int HowManyDBFilesInFolder()
        {
            return Directory.GetFiles("./DataBases", "*.soos").Length;

        }
    }
}
