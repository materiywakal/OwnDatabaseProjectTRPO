using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataAccessLayer.Modules
{
    class SharedDataAccessMethods
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
    }
}
