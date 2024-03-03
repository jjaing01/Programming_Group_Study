using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FUNC2 = System.Func<int, int>;

// class FUNC: System.MulticastDelegate

namespace StudyGroup_LYS.Delegate
{
    delegate void FUNC(int arg);
    delegate int FUNC3(int arg1, int arg2);

    class Test
    {
        public static void static_method(int arg)
        {

        }

        public void instance_method(int arg)
        {

        }
    }
    class Program
    {
        public static void static_method(int arg)
        {
            
        }

        public void instance_method(int arg)
        {
            
        }
        public static void Main()
        {
            int n = 10;
            double d = 3.14;
            string s = "hello";

            // 1. 함수를 담는 데이터 타입
            // - 메소드)메소드의 호출 정보, 메소드 모양/주소)를 저장하는 타입: delegate
            // - c/c++ 함수 포인터 개념과 유사하다. 하지만 함수 포인터는 주소만 보관하지만,
            // - delegate는 파라미터 개수, 각각의 타입 등의 정보를 보관하고 있어서 유연성이 높다.
             
            FUNC f = foo;
            FUNC2 f2 = foo2;

            // 역할은 동일
            f(10);
            f.Invoke(10);

            // 실제 표기법
            // delegate가 결국 class 이므로, 아래처럼 쓸 수 있다.
            // 결국 delegate는 메소드의 호출 정보를 저장하는 타입이다.
            FUNC f1 = new FUNC(foo);


            // 2. Delegate에 메소드를 등록하는 방법 - static인지 아닌지에 따라서 다르다.
            FUNC f3 = Program.static_method;
            FUNC f4 = Test.static_method;

            // 3. instance method
            // 객체가 존재해야 한다.
            Test t = new();
            FUNC f5 = t.instance_method;

            Program p = new();
            FUNC f6 = p.instance_method;

            // 4. 익명 메서드
            // delegate에 등록
            FUNC3 f7 = delegate (int a, int b) { return a * b; };

        }
        public static void foo(int arg)
        {
            Console.WriteLine(arg);
        }
        public static int foo2(int arg)
        {
            return arg;
        }

        public static void foo2(FUNC3 _func3)
        {
            Console.WriteLine(_func3(2, 2));
        }

    }

}
