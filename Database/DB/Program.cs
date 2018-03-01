using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DBModel
{
    public struct Column
    {
        /// <summary>
        /// General constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="DataType"></param>
        /// <param name="allowsnull"></param>
        /// <param name="isFkey"></param>
        /// <param name="isPkey"></param>
        /// <param name="def"></param>
        public Column(string name, Type DataType, bool allowsnull, bool isFkey, bool isPkey, object def)
        {
            _name = name;
            dataType = DataType;
            allowsNull = allowsnull;
            _Default = Methods.GetDefaultValue(DataType);
            if (def != null)
            {
                Type buf = def.GetType();
             
                if (def.GetType() == dataType) _Default = def;
            }
            _dataList = new List<object>();
           
            _isForeignKey = isFkey;
            _isPrimaryKey = isPkey;
            
        }
        //fields

        string _name;
        //
        Type dataType;
        //
        bool allowsNull;
        //
        object _Default;
        //
        bool _isPrimaryKey;
        //
        bool _isForeignKey;
        //
        List<object> _dataList;

        //properties
        public string Name { get => _name; private set => _name = value;  }
        public Type DataType { get => dataType; private set => dataType = value; }
        public bool AllowsNull { get => allowsNull; private set => allowsNull = value; }
        public object Default { get => _Default; private set => _Default = value; }
        public bool IsPrimaryKey { get => _isPrimaryKey; private set => _isPrimaryKey = value; }
        public bool IsForeignKey { get => _isForeignKey; private set => _isForeignKey = value; }
        public List<object> DataList { get => _dataList; private set => _dataList = value; }
        //
    }
    class Table
    {
        //fields
        string _name;
        //
        List<Column> _columns;
        //
        //properties
        public string Name { get => _name; set => _name = value; }
        //
        public List<Column> Columns { get => _columns; set => _columns = value; }
        //
        /// <summary>
        /// Table constructor
        /// </summary>
        /// <param name="name"></param>
        public Table(string name)
        {

            Name = name;
            _columns = new List<Column>();
            List<string> tablesPropertiesNames = new List<string>();
        }
        //
        /// <summary>
        /// Adds new column to current table!
        /// </summary>
        /// <param name="newTable"></param>
        public void AddColumn(Column newTable)
        {
            if (Methods.isThereNoUndefinedSymbols(newTable.Name))
            {
                foreach (Column tblProp in Columns)
                {
                    if (tblProp.Name == newTable.Name) throw new FormatException("Invalid column name. Some column in this table have same name!");
                }
                Columns.Add(newTable);
            }
            else throw new FormatException("There is invalid symbols in column's name!");

        }
        //
        /// <summary>
        /// Add element to Table!
        /// </summary>
        /// <param name="arguments"></param>
        public void AddTableElement(object[] arguments)
        {
            int TablesCount = Columns.Count;
            if (arguments.Length == TablesCount)
            {
                for (int i = 0; i < arguments.Length; i++)
                {
                    if (Columns[i].AllowsNull && arguments[i] == null) Columns[i].DataList.Add(Columns[i].Default);
                    else
                    if (arguments[i].GetType() == Columns[i].DataType)
                    {
                            Columns[i].DataList.Add(arguments[i]);
                    }
                    else throw new FormatException();
                }
            }
            else throw new IndexOutOfRangeException("Arguments array isn't similar to count of columns in table");

        }
        //
    }
    class DB
    {
        //fields
         List<Table> _tablesDB = new List<Table>();
        string _name;
        //properties
        public string Name { get => _name; set => _name = value; }
        internal List<Table> TablesDB { get => _tablesDB; set => _tablesDB = value; }
        //
        /// <summary>
        /// DB constructor
        /// </summary>
        /// <param name="name"></param>
        public DB(string name)
        {
            _name = name;
        }
        //
        /// <summary>
        /// Add table to this Database
        /// </summary>
        /// <param name="bufTable"></param>
        public void AddTable(Table bufTable)
        {
            if (Methods.isThereNoUndefinedSymbols(bufTable.Name))
            {
                foreach (Table tbl in TablesDB)
                {
                    if (tbl.Name == bufTable.Name) throw new FormatException("Invalid table name. Some table in this database have same name!");
                }
                TablesDB.Add(bufTable);
            }
            else throw new FormatException("There is invalid symbols in table's name!");
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            DB db = new DB("newDB");
            Table table = new Table("table");
            Column pp = new Column("pp", typeof(string), true, false, true, "xer");
            table.AddColumn(pp);
            object[] obj = new object[1];
            obj[0] = null;
            table.AddTableElement(obj);
            Console.WriteLine(table.Columns[0].DataList[0]);
            



        }
    }
}
