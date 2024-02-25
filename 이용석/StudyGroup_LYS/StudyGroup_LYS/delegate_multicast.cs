using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LYS.delegate_multicast
{
    class Test
    {
        public static int Method1()
        {
            Console.WriteLine("Method1");
            return 1;
        }
        public static int Method2()
        {
            Console.WriteLine("Method2");
            return 1;
        }
        public static int Method3()
        {
            Console.WriteLine("Method3");
            return 1;
        }
        public static int Method4()
        {
            Console.WriteLine("Method4");
            return 1;
        }
    }
    delegate int FUNC();

    class Program
    {
        public static void Main(string[] args) 
        {
            FUNC f1 = Test.Method1;
            FUNC f2 = Test.Method2;
            FUNC f3 = Test.Method3;
            FUNC f4 = Test.Method4;

            // 1. Continue delegate : Delegate:Combine()
            // - delegate를 결합한다.
            // - casting을 해야 한다.
            // - 모든 인자는 delegate 여야 한다.
            FUNC f5 = (FUNC)System.Delegate.Combine(f1, f2);
            f5.Invoke();
            Console.WriteLine("------------------------------------");

            // 2. Combine delegate : + - += -= 으로 쓴다.
            FUNC f6 = f1 + f2 + f3;
            f6.Invoke();
            Console.WriteLine("------------------------------------");

            f6 -= f1;
            f6.Invoke();
            Console.WriteLine("------------------------------------");

            // 3. delegate은 reference type이며, immutable(read only) 하다.
            FUNC f7 = Test.Method1;
            FUNC f8 = f7;

            Console.WriteLine(f7 == f8); // true
            Console.WriteLine("------------------------------------");

            // f7 = new FUNC(...)
            // delegate는 immutable하기 때문에 값을 변경하는게 아니라 새로 생성해버린다.
            f7 += Test.Method2; 
            Console.WriteLine(f7 == f8); // false
            Console.WriteLine("------------------------------------");

            System.Delegate[] delegates = f6.GetInvocationList();
            var t = delegates[0];

            foreach(var d in delegates)
            {
                Console.WriteLine(d);
            }
        }
    }
}
