using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FilesLayer")]

namespace DataLayer
{
    public static class Kernel
    {
        private static List<DataBaseInstance> instance;
        private static object lockObject = new Object();

        internal static List<DataBaseInstance> GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        //!!! here check enviroment for something
                        instance = new List<DataBaseInstance>();
                    }
                }
            }
            return instance;
        }

        public static DataBaseInstance GetInstance(string name)
        {
            var _instance = Kernel.GetInstance();
            var element =  _instance.FindLast(x => x.Name == name);
            if (element != null)
                return element;
            throw new IndexOutOfRangeException("Коля, лови!");
        }

        // Methods for Sanya (best dev)
        internal static void AddDBInstance(DataBaseInstance inst)
        {
            var _instance = Kernel.GetInstance();
            if (_instance.FindAll(x => x.Name == inst.Name).Count != 0)
                return;
            _instance.Add(inst);
        }

        internal static void AddDBInstance(string name)
        {
            DataBaseInstance bufInst = new DataBaseInstance(name);
            AddDBInstance(bufInst);
        }

    }
}
