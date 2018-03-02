using DataLayer.InternalDataBaseInstanceComponents;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DataLayer
{
    
     [Serializable()]
     class DataBaseInstance : ISerializable
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
         public DataBaseInstance(string name)
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

         public void GetObjectData(SerializationInfo info, StreamingContext context)
         {
             throw new NotImplementedException();
         }
     }
    
}
