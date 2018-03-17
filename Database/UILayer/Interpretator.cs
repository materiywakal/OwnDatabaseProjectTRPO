using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.InternalDataBaseInstanceComponents;
using System.Reflection;
namespace UILayer
{
    class Interpreter
    {
        static object _locObj = new object();
        static Interpreter _instance;
        private static List<string> MainKeywords = new List<string>()
        {
            "CREATE",
            "SELECT",
            "SAVE",
            "DROP",
            "CLEAR"
        };


        private static Interpreter GetInstance()
        {
            if (_instance == null)
            {
                lock (_locObj)
                {
                    if (_instance == null)
                    {
                        _instance = new Interpreter();
                        return _instance;
                    }
                }
            }
            return _instance;
        }

        public static void Run()
        {
            while (true)
            {
               
                string query = default(string);
                query = Console.ReadLine();

                if (query.Any(x => char.IsLetterOrDigit(x)))
                {
                    char[] separator = new char[] { ' ' };
                    string keyWord = query.Split(separator,StringSplitOptions.RemoveEmptyEntries)[0];
                    if (GetInstance().IsMainKeyword(keyWord))
                    {
                        var method = GetInstance().GetType().GetMethod(keyWord, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
                        object[] param = new object[] { query };
                        method?.Invoke(GetInstance(), param);
                    }
                    else
                    {
                        Console.WriteLine($"\nERROR: Word '{keyWord}' doesn't be keyword\n");
                    }
                }
            }
        }


        #region LocalMethods
        private bool IsMainKeyword(string query)
        {
            foreach (var _keyWord in MainKeywords)
                if (_keyWord.ToUpper() == query.ToUpper())
                    return true;
            return false;
        }

        private bool IsKeyword(string name)
        {
            name = name.ToUpper();
            foreach (var key in MainKeywords)
                if (key == name)
                    return true;
            return false;
        }

        private object GetDefaultValue(string type, string value)
        {
            switch (type.ToLower())
            {
                case "int":
                    return (object)Convert.ToInt32(value);
                case "string":
                    return (object)value;
                case "double":
                    return (object)Convert.ToDouble(value);
                default:
                    return null;
            }
        }



        private Column GetColumn(string[] tempParams)
        {
            string columnName = tempParams[0];
            Type columnType = typeof(int);
            bool b1 = Convert.ToBoolean(tempParams[2].ToLower());
            bool b2 = Convert.ToBoolean(tempParams[3].ToLower());
            bool b3 = Convert.ToBoolean(tempParams[4].ToLower());
            object defaultValue = GetDefaultValue(tempParams[1], tempParams[5]);
            Column buf = new Column(columnName, columnType, b1, b2, b3, defaultValue);
            return buf;
        }



        #endregion

        #region MainMetods

        private static void Create(string query)
        {
            char[] separators = new char[] { ' ', ';' };
            string[] queryList = query.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            
            if (queryList.Length == 2)
            {
                string databaseName = default(string);
                databaseName = queryList[1];

                if (!GetInstance().IsKeyword(databaseName))
                {
                    Kernel.AddDBInstance(databaseName);
                    Console.WriteLine($"Database was created with name '{queryList[1]}'\n");
                    Kernel.OutDatabaseInfo();

                }
                else
                {
                    Console.WriteLine($"\nERROR: Name of the database can't be a keyword\n");
                    
                }
            }
            else
            {
                Console.WriteLine($"\nERROR: Invalid numbers of variables\n");
            }
        }

        private static void Select(string query)
        {
            char[] separator = new char[] { ' ' };
            string[] temp = query.Split(separator, 2, StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length == 2&&query[query.Length-1]==')')
            {
                char[] s1 = new char[] { '(' };
                string[] t1 = query.Split(s1, 2, StringSplitOptions.RemoveEmptyEntries);
                
                char[] s2 = new char[] { ' ' };
                string[] tempName = t1[0].Split(s2, StringSplitOptions.RemoveEmptyEntries);

                char[] s3 = new char[] { ';' , ')' };
                string[] tempParams = t1[1].Split(s3, StringSplitOptions.RemoveEmptyEntries);
                


                if(tempName.Length==3)
                {
                    string dbName = tempName[1];
                    string tableName = tempName[2];

                    for (int i = 0; i < tempParams.Length; i++)
                    {
                        string[] param = tempParams[i].Split(',');
                        if(param.Length==6)
                        {
                            //if(SharedDataAccessMethods)
                            Kernel.AddDBInstance(dbName);
                            var inst = Kernel.GetInstance(dbName);
                            inst.AddTable(tableName);
                            int tableIndex = Kernel.GetInstance(dbName).indexOfTable(tableName);
                            Column buff = GetInstance().GetColumn(param);
                            inst.TablesDB[tableIndex].AddColumn(buff);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nERROR: Invalid numbers of variables in params\n");
                }

            }
            else
            {
                Console.WriteLine($"\nERROR: Missed part of the command\n");
            }
            Kernel.OutDatabaseInfo();
        }

        private static void Save(string query)
        {
            Console.WriteLine(query);
        }

        private static void Clear(string query)
        {
            Console.Clear();
        }
        #endregion

    }
}
//switch (keyWord)
//{
//    case "CREATE_DATABASE":
//        {
//            CreateDatabase(query);
//        }
//        break;
//    case "CREATE_TABLE":
//        {

//        }
//        break;
//    case "CREATE_TABLE_IN":
//        {
//            CreateTableIn(query);
//        }
//        break;
//    case "DATABASES_INFO":
//        {

//        }break;
//    case "SAVE_ALL":
//        {
//            SaveAll();
//        }break;
//    default:
//        Console.WriteLine($"\nERROR: Command '{keyWord}' doesn't found\n");
//        break;
//}