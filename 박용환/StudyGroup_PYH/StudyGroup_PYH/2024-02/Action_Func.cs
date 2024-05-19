using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._2024_02
{
    // 1. 반환값이 있는 메소드는 C#에서 제공하는 Func을 사용한다.
    // delegate TResult Func<T, TResult>(T arg);
    // delegate TResult Func<T1, T2, TResult>(T1 arg, T2 arg2);

    // 2. 반환값이 없는 메소드는 C#에서 제공하는 Action을 사용한다.
    // delegate void Func<T>(T arg);
    // delegate void Func<T1, T2>(T1 arg, T2 arg2);
    class Action_Func
    {
        public static void main()
        {
            // 1-1 Func
            // 맨 뒤는 반환값
            Func<int> g0 = Goo0;
            Func<int, int> g1 = Goo1;
            Func<int, int, int> g2 = Goo2;

            // 2-1 Action
            Action A0 = Aoo0;
            Action<int> A1 = Aoo1;
            Action<int, int> A2 = Aoo2;

            // 3 - 1. 람다 표현식
            // 가장 기본적인 형태
            Test(Add);
            Test((int a, int b) => { return a - b; }) ;
            Func<int, int, int> func2 = (int a, int b) => { return a - b; };
            // 매개 변수 타입 생략 가능
            Func<int, int, int> func3 = (a, b) => { return a - b; };
            // 매개 변수화 리턴, {} 생략 가능
            Func<int, int, int> func4 = (a, b) => a - b;
            // 매개 변수가 한개인 경우
            Func<int, int> funt5 = (a) => a * a;
            Func<int, int> funt6 = a => a * a;
        }

        public static int Goo0(){return 0;}
        public static int Goo1(int arg) { return 0; }
        public static int Goo2(int arg1, int arg2) { return 0; }


        public static void Aoo0() {}
        public static void Aoo1(int arg) {}
        public static void Aoo2(int arg1, int arg2) {}

        public static void Test(Func<int,int,int> f)
        {
            int s = f(1, 2);
            Console.WriteLine(s);
        }

        public static int Add(int a, int b) => a + b;

    }
}
