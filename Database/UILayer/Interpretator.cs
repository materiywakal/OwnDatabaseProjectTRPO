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
            "INFO",
            "ALL_DATABASES",

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
<<<<<<< HEAD
                            CreateTable(query);
                        }
                        break;
                    case "INFO":
                        {

=======
                            Kernel.AddDBInstance("db1");
>>>>>>> e46bbe7cf81150132aeb5f3658f0b6352ec6090b
                        }break;
                    case "ALL_DATABASES":
                        {

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

        #endregion

        #region MainMetods

        private static void CreateDatabase(string query)
        {
            char[] separators = new char[] { ' ', ';' };
            string[] queryList = query.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (queryList.Length == 2)
            {
                if (IsKeyword(queryList[1]))
                {
                    Kernel.AddDBInstance(queryList[0]);
                    Console.WriteLine($"Database was created with name '{queryList[1]}'\n");
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

        private static void CreateTable(string query)
        {
            
        }



        #endregion

    }
}
