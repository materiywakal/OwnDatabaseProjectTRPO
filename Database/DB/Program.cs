using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DB
{
    class Program
    {
        static void Main(string[] args)
        {
            DB db = new DB("newDB");
            Table table = new Table("table");
            Column pp = new Column("pp", typeof(string), true, false, true, "xer");
            Column pp1 = new Column("pp", typeof(string), true, false, true, "xer");

            table.AddColumn(pp);
            object[] obj = new object[1];
            obj[0] = null;
            table.AddTableElement(obj);
            Console.WriteLine(table.Columns[0].DataList[0].Data);



        }
    }
}
