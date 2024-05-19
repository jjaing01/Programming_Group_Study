using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._2024_02
{
    class delegate_multicast
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
        }

        delegate int FUNC();
        public static void main()
        {
            FUNC f1 = Test.Method1;
            FUNC f2 = Test.Method2;

            // 1. combine delegate: Delegate::Combine()
            // - delegate를 결합한다.
            FUNC f3 = (FUNC)Delegate.Combine(f1, f2);
            f3.Invoke(); // 순서대로 발생

            // 2. Combine Delegate : +, -, +=, -=
            // compine = chaining
            FUNC f4 = f1 + f2;
            f4.Invoke();

            // 3. delegate은 reference type(class), immutable 하다. // vector 동작과 유사. 있던거에 추가할 수 없으니 새로 new한다.
            // readonly 개념 내부 필드 값을 바꿀 수 없다.

            FUNC f5 = Test.Method1;
            FUNC f6 = f5;
            Console.WriteLine(f5 == f6);

            f5 += Test.Method2;

            // 4. delegate 여러 개일 경우 반환 값
            // - 모든 요소는 delegate 객체이다.
            Delegate[] delegates = f4.GetInvocationList(); // 각 delegate를 배열에 저장한다.
            var t = delegates[0];

            foreach(Delegate d in delegates)
            {
                FUNC f = (FUNC)d;
                int ret = f();
                Console.WriteLine(ret);
            }
        }
    }
}
