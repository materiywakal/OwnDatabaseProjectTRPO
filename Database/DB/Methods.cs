using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    class Methods
    {
        string undefSymbols = "#^&()-=+[]~'//\\.,;|?";
        public bool isThereNoUndefinedSymbols(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (undefSymbols.Contains(str[i])) return false;
            }
            return true;    
        }
    }
}
