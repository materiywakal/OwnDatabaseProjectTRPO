using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using DataLayer.Shared.ExtentionMethods;
using DataLayer.Shared.DataModels;

namespace DataLayer.InternalDataBaseInstanceComponents
{
    [Serializable]
    public class Table
    {
        //fields
        string _name;
        //
        List<Column> _columns;
        //
        //properties
        public string Name { get => _name; private set => _name = value; }
        //
        public List<Column> Columns { get => _columns; private set => _columns = value; }
        //
        /// <summary>
        /// Table constructor
        /// </summary>
        /// <param name="name"></param>
        public Table(string name)
        {

            Name = name;
            _columns = new List<Column>();
        }
        //
        /// <summary>
        /// Adds new column to current table!
        /// </summary>
        /// <param name="newTable"></param>
        public void AddColumn(Column newTable)
        {
            if (newTable.Name.isThereNoUndefinedSymbols())
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
                    if (Columns[i].AllowsNull && arguments[i] == null) Columns[i].DataList.Add(new DataObject(Columns[i].GetHashCode(), Columns[i].Default));
                    else
                    if (arguments[i].GetType() == Columns[i].DataType)
                    {
                        Columns[i].DataList.Add(new DataObject(Columns[i].GetHashCode(),arguments[i]));
                    }
                    else throw new FormatException("You can't add null element to this column because it doesn't allows null");
                }
            }
            else throw new IndexOutOfRangeException("Arguments array isn't similar to count of columns in table");

        }
        
    }

}
