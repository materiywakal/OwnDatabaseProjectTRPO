using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.InternalDataBaseInstanceComponents;

namespace UILayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Kernel.AddDBInstance("dbTest");
            var inst = Kernel.GetInstance("dbTest");
            inst.AddTable("table1");
            inst.SaveDataBaseInstanceToFolder();
            Kernel.OutDatabaseInfo();
            ////Interpreter.Run();
        }
    }
}
