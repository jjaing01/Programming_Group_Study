using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    class Nullable
    {
        public static void Main()
        {
            int x = 100;
            object obj = new();

            obj = x;

            obj = 101;

            Console.WriteLine(obj);
            Console.WriteLine(x);

        }
    }
}
