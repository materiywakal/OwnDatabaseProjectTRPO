using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Methods
    {
        static string undefSymbols = "#^&()-=+[]~'//\\.,;|? ";
       static public bool isThereNoUndefinedSymbols(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (undefSymbols.Contains(str[i])) return false;
            }
            return true;    
        }
        public static object GetDefaultValue(Type t)
        {
            if (t.IsValueType)
            {
                return Activator.CreateInstance(t);
            }
            else
            {
                return null;
            }
        }
    }
}
