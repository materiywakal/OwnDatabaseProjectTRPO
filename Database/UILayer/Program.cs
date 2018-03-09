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
            //Kernel.GetInstance().Add(new DataBaseInstance("testDB"));
            //Kernel.GetInstance()[0].AddTable("tableTest");
            //Column buf = new Column("testColumn", typeof(string), true, false, false, "kk");
            //Kernel.GetInstance()[0].TablesDB[0].AddColumn(buf);
            //Kernel.GetInstance()[0].TablesDB[0].AddTableElement(new object[1] { null });
            //Kernel.GetInstance().Add(new DataBaseInstance("testDB2"));
            //Kernel.GetInstance()[1].AddTable("tableTest1");
            //Column buf1 = new Column("testColumn2", typeof(int), true, false, false, 99);
            //Kernel.GetInstance()[1].TablesDB[0].AddColumn(buf1);
            //Kernel.GetInstance()[1].TablesDB[0].AddTableElement(new object[1] { null });
            //Kernel.SaveAllDatabases();
            //Kernel.OutNamesOfExistingDBs();
            Kernel.OutDatabaseInfo();
            // Interpretator.Run();
        }
    }
}
