using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.InternalDataBaseInstanceComponents;

namespace UILayer
{
    class Interpretator
    {
        static List<string> MainKeywords = new List<string>()
        {
            "CREATE_DATABASE",
            "CREATE_TABLE",
            "CREATE_TABLE_IN",
            "DATABASES_INFO",
            "SAVE_ALL",

        };

        public static void Run()
        {
            while (true)
            {
                string query = default(string);
                query = Console.ReadLine();
                string keyWord = GetMainKeyword(query);

                switch (keyWord)
                {
                    case "CREATE_DATABASE":
                        {
                            CreateDatabase(query);
                        }
                        break;
                    case "CREATE_TABLE":
                        {
                            CreateTableIn(query);
                        }
                        break;
                    case "CREATE_TABLE_IN":
                        {
                            
                        }
                        break;
                    case "DATABASES_INFO":
                        {

                        }break;
                    case "SAVE_ALL":
                        {
                            SaveAll();
                        }break;
                    default:
                        Console.WriteLine($"\nERROR: Command '{keyWord}' doesn't found\n");
                        break;
                }
            }
        }

       
        #region LocalMethods
        private static string GetMainKeyword(string query)
        {
            char[] seprator = new char[] { ' ' };
            string[] queryList = query.Split(seprator, 2, StringSplitOptions.RemoveEmptyEntries);
            return queryList[0].ToUpper();
        }

        private static bool IsKeyword(string name)
        {
            name = name.ToUpper();
            foreach (var key in MainKeywords)
                if (key == name)
                    return true;
            return false;
        }


        private static Column GetColumn(string[] tempParams)
        {
            string columnName = tempParams[0];
            Type columnType = Type.GetType(tempParams[1]);
            bool b1 = Convert.ToBoolean(tempParams[2]);
            //bool b2=co

            Column buf = new Column();
            return buf;
        }

        #endregion

        #region MainMetods

        private static void CreateDatabase(string query)
        {
            char[] separators = new char[] { ' ', ';' };
            string[] queryList = query.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            
            if (queryList.Length == 2)
            {
                string databaseName = default(string);
                databaseName = queryList[1];

                if (!IsKeyword(databaseName))
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

        private static void CreateTableIn(string query)
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
                            int tableIndex = Kernel.GetInstance(dbName).indexOfTable(tableName);
                            Column buff = GetColumn(tempParams);


                            Kernel.GetInstance(dbName).AddTable(tableName);
                            //Kernel.GetInstance(dbName).TablesDB[tableIndex].AddColumn();
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
        }

        

        private static void SaveAll()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
