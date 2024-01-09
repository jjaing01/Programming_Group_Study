using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study
{
    // 기본적으로 Object 상속
    class Base /*: System.Object*/
    {
        public void foo()
        {
            Console.WriteLine("base foo");
        }
    }

    class Derived : Base
    {
        // 
        public new void foo()
        {
            Console.WriteLine("derived foo");
        }
    }

    class Program
    {
        static void main()
        {
            Base bBase = new Base();
            //bBase.Equals

            Base bBase2 = new();

            Base bBase3 = new Derived();

        }
    }
}