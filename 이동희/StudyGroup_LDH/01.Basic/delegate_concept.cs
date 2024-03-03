using System;

////class FUNC : System.MulticastDelegate
////{
////    // ....
////}
namespace StudyGroup_LDH._01.Basic
{
    delegate void FUNC(int arg);
    delegate int FUNC2(int arg1, int arg2);
    class Test
    {
        public static void static_method(int arg) { }
        public void instance_method(int arg) { }
    }

    class Program
    {
        public static void static_method(int arg) { }
        public void instance_method(int arg) { }

        public static void Main()
        {
            int n = 10;
            double d = 3.4;
            string s = "hello";

            // 1. 함수를 담는 데이터 타입
            // - 메소드(메소드의 호출 정보, 메소드 모양/주소)를 저장하는 타입: delegate
            // - c/c++ 함수 포인터 개념과 유사하다. 하지만 함수 포인터는 주소만 보관하지만,
            // - delegate는 파라미터 개수, 각각의 타입 등의 정보를 보관하고 있어서 유연성이 높다.

            FUNC f = foo;
            f(10);

            // 1-1.실제 표기법
            // delegate가 결국 class 이므로, 정확한 표기법은?
            // 결국 delegate는 메소드의 호출 정보를 저장하는 타입이다.
            FUNC f1 = new FUNC(foo);

            // 2.delegate에 메소드를 등록하는 방법 - static인지 아닌지에 따라서 다르다.
            // (1) static method : Class Name.Method Name
            FUNC f2 = Program.static_method;
            FUNC f3 = Test.static_method;

            // 3.instance method
            // 객체가 존재해야 한다.
            Test t = new();
            FUNC f4 = t.instance_method;
            Program p = new Program();
            FUNC f5 = p.instance_method;

            // 4. 익명 메소드
            // delegate 등록해보자
            // 함수 이름 대신 delegate 기입한다. -> 메소드 이름이 없다.
            FUNC2 f6 = delegate (int a, int b) { return a * b; };
        }

        public static void foo(int arg)
        {
            Console.WriteLine($"foo: {arg}");
        }

        public static void foo2(FUNC2 _func2)
        {
            Console.WriteLine(_func2(2, 2));
        }
    }
}
