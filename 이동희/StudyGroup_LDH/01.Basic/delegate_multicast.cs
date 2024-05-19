using System;

namespace StudyGroup_LDH._01.Basic
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
            return 2;
        }

        public static int Method3()
        {
            Console.WriteLine("Method3");
            return 3;
        }

        public static int Method4()
        {
            Console.WriteLine("Method4");
            return 4;
        }

    }

    delegate int FUNC();
    class Program
    {
        public static void Main()
        {
            FUNC f1 = Test.Method1;
            FUNC f2 = Test.Method2;
            FUNC f3 = Test.Method3;
            FUNC f4 = Test.Method4;

            // 1. Combine delegate: Delegate::Combine()
            // - delegate를 결합한다.
            // - 캐스팅을 해야 한다.
            // - 모든 인자는 delegate 여야 한다.
            FUNC f5 = (FUNC)Delegate.Combine(f1, f2);
            f5.Invoke();
            Console.WriteLine("---------------------------------------");
            // 2. Combine delegate: +, -, +=, -=
            FUNC f6 = f2 + f3;
            f6.Invoke();

            f6 -= f1;
            f6.Invoke();
            Console.WriteLine("---------------------------------------");
            // 3. delegate은 reference type이며, immutable 하다.
            FUNC f7 = Test.Method1;
            FUNC f8 = f7; // true
            Console.WriteLine(f7 == f8);
            f7.Invoke();
            f8.Invoke();
            Console.WriteLine("---------------------------------------");
            
            f7 += Test.Method2; // f7은 새로운 객체를 가리킨다. f7 = new FUNC()
            Console.WriteLine(f7 == f8); // false
            f7.Invoke();
            f8.Invoke();

            // 4. delegate 여러 개일 경우 반환 값
            // - 모든 요소는 delegate 객체이다.
            Delegate[] delegates = f6.GetInvocationList(); // 각 delegate를 배열에 저장한다.
            foreach (Delegate d in delegates)
            {
                FUNC f = (FUNC)d;
                int ret = f();
                Console.WriteLine(ret);
            }
        }
    }
}
