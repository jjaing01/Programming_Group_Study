using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace console
{
    public enum SockState
    {
        Invalid = 1,
        Live,
        Die,
    }


    class ConsoleClass
    {
        public static void Main()
        {
            SockState st = new SockState();
            System.Console.WriteLine(st);
        }
    }
}
