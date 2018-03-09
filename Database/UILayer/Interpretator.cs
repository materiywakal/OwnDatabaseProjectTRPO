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
            "CREATE_TABLE"
        };

        public static void Run()
        {
            while(true)
            {
                string query = default(string);
                query = Console.ReadLine();
                char[] seprator = new char[] { ' ' };
                string[] queryList = query.Split(seprator, 2);
                string keyWord = queryList[0].ToUpper();

                switch (keyWord)
                {
                    case "CREATE_DATABASE":
                        {
                            CreateDatabase(query);
                        }break;

                    case "CREATE_TABLE":
                        {
                            Kernel.AddDBInstance("db1");
                        }break;

                    default:
                        Console.WriteLine($"\nERROR: Command '{keyWord}' doesn't found\n");
                        break;
                }






            }




        }

        private static void CreateDatabase(string query)
        {
            char[] separators = new char[] { ' ', ';' };
            string[] queryList = query.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if(queryList.Length==2)
            {
                if(queryList[1].ToUpper() != queryList[0].ToUpper())
                {
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
    }
}
