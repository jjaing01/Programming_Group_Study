using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._2024_02
{
    class Poinit<T1> 
    {
        public T1 x { get; set; }
        public T1 y { get; set; }

        public Point(T1 _x, T1 _y = default(T1))
        {
            x = _x;
            y = _y;
        }
    }

    // Template
    // - 클래스 이름 뒤에 <> 를 붙여준다.
    // 초기화를 할 떄 defautl<T> 키워드를 사용한다.
    class Generic
    {
        public static T Foo1<T>(T a)
        {
            Type t = a.GetType();
            Console.WriteLine(t);
            return a;
        }

        public static T Foo2<T>(T a, T b)
        {
            // a가 가지고 있는 실체 객체의 타입이 나온다.
            Type t = a.GetType();
            Console.WriteLine(t);

            // T의 타이을 확인
            Type t2 = a.GetType();
            Console.WriteLine(t2);
            return a;
        }


        public static void Main()
        {

            // T는 하나
            // 모든 타입을 포함할 수 있는 타입으로 T를 결정
            Foo2(2, 3.14); // T : double
            Foo2(2, "A"); // 포함할 수 없는 타입이 없으면 error
            Foo2<object>(2, "A"); // object타입으로 가능 ok
        }
    }
}
