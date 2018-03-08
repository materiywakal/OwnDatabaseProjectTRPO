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
            // test
            Kernel.AddDBInstance(new DataBaseInstance("my name"));
            Kernel.SaveAllDatabases();

            //Kernel.LoadAllDatabases(false);
            //var list = Kernel.GetInstance();
            //Console.WriteLine(list.Count);
            //Console.ReadKey();
            // Interpretator.Run();
        }
    }
}
