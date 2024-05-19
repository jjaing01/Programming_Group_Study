using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    // 1. Template
    // - 클래스 이름 뒤에 <> 를 붙여준다.
    // 초기화를 할 때 default<T> 키워드를 사용한다.
    class Point<T>
    {
        private T x;
        private T y;

        public Point(T posx = default(T), T posy = default(T))
        {
            x = posx;
            y = posy;
        }
    }
    
    class Program
    {
        // 2. generic method
        // 함수 이름 뒤 <> 를 붙여준다.
        public static T Fool<T>(T a)
        {
            Type t = a.GetType();
            Console.WriteLine(t);

            // T의 타입을 확인 해볼 수도 있다.
            Type t2 = typeof(T);
            Console.WriteLine(t2);
            return a;
        }

        public static T Fool2<T>(T a, T b)
        {
            // a가 가지고 있는 실체 객체의 타입이 나온다.
            Type t = a.GetType();
            Console.WriteLine(t);

            // T의 타입을 확인
            Type t2 = typeof(T);
            Console.WriteLine(t2);
            return a;
        }

        public static void Main()
        {
            Point<int> pt = new Point<int>(1, 1);
            Point<double> pt1 = new Point<double>(1.1, 1.1);

            // collection 클래스도 generic으로 제공된다.
            LinkedList<int> link = new LinkedList<int>();

            // T는 하나
            // 다른 타입 2개를 사용할 경우 => 매개 변수 중에서 모두를 포함할 수 있는 타입으로 T를 결정한다.
            Fool2(2, 3.14); // T: double
            Fool2(2, "A"); // 매개 변수 모두를 포함할 수 있는 타입이 없을 경우 컴파일러가 error를 발생시킨다.
            Fool2<object>(2, "A"); // object 타입으로는 담을 수 있으니 OK
        }
    }
}
