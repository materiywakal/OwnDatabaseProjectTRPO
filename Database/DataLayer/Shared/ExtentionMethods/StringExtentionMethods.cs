using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataLayer.Shared.ExtentionMethods
{

    internal static class StringExtentionMethods
    {
        static string undefSymbols = "#^&()-=+[]~'//\\.,;|? ";
        

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
