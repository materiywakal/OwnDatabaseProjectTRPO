using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public static class Kernel
    {
        private static DataBaseInstance instance;
        private static object lockObject = new Object();
        

        public static DataBaseInstance getInstance(string name)
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                        instance = new DataBaseInstance(name);
                }
            }
            return instance;
        }
    }
}
