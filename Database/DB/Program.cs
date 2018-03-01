using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DBModel
{
    public struct TableProperty
    {
        public TableProperty(string name, Type dataType, bool allowsnull, bool isFkey, bool isPkey, object def)
        {
            Name = name;
            DataType = dataType;
            AllowsNull = allowsnull;
            Default = default(object);
            if (def != null)
            {
                Type buf = def.GetType();
                if (buf.GetType() == dataType) Default = def;
            }
            dataList = new List<object>();
           
            isForeignKey = isFkey;
            isPrimaryKey = isPkey;
            if (isPrimaryKey)
            {
                Type[] itf = DataType.GetInterfaces();
                foreach (Type i in itf)
                {
                    Console.WriteLine("Class {0} implements {1}", DataType.Name, i.Name);
                }
            }
        }
        string Name;
        public Type DataType;
        bool AllowsNull;
        object Default;
        bool isPrimaryKey;
        bool isForeignKey;

        List<object> dataList;
    }
    class Table
    {
        List<TableProperty> Tables;
        string Name;
        public Table(string name)
        {
            Tables = new List<TableProperty>();
            Name = name;
        }
        public void AddTable(TableProperty newTable)
        {
            Tables.Add(newTable);
        }
    }
    class DB
    {
        List<TableProperty> TablesDB;
        
        public void AddElement(object[] arguments)
        {
            int TablesCount = TablesDB.Count;

        }
        public string kek;
    }
    class Program
    {
        static void Main(string[] args)
        {
            TableProperty pp = new TableProperty("pp", typeof(string), false, false, true, null);
            List<DB> k = new List<DB>();
            for (int i = 0; i < 10; i++)
            {
                k.Add(new DB { kek = i.ToString() });

            }
            foreach (DB db in k)
            {
                db.kek = "lul";
            }

        }
    }
}
