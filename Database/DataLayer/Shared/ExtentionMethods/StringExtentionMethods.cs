using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataLayer.Shared.ExtentionMethods
{
    //Methods name is meanless
    public static class ExtensionMethods
    {
        static string undefSymbols = "#^&()-=+[]~'//\\.,;|? ";

        // It's should be rewrited as an extention method, to avoid
        // directly call
       static public bool isThereNoUndefinedSymbols(this string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (undefSymbols.Contains(str[i])) return false;
            }
            return true;    
        }
    }
}
