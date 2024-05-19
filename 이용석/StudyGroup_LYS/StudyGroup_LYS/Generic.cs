using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LYS.Generic
{
   // 1. Template
   // - 클래스 이름 뒤에  <>를 붙여준다.
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
        // 함수 이름 뒤 <>를 붙여준다.
        public static T Fool<T>(T t) 
        {
            Type type = t.GetType();
            Console.WriteLine(type);


            // T의 타입을 확인해 볼 수도 있다,
            Type type2 = typeof(T);
            Console.WriteLine(type2);

            return t;
        }
        public static T Fool2<T>(T a, T b)
        {
            Type type = a.GetType();
            Console.WriteLine(type);


            // T의 타입을 확인해 볼 수도 있다,
            Type type2 = typeof(T);
            Console.WriteLine(type2);

            return a;
        }


        public static void Main(string[] args) 
        {
            Point<int> point = new Point<int>(1, 1);
            Point<double> point2 = new Point<double>(1.0, 1.0);

            LinkedList<int> list = new LinkedList<int>();


            // T는 하나 
            // 다른 타입 2개를 사용할 경우 => 매개 변수 중에서 모두를 포함할 수 있는 타입으로 T를 결정한다.
            Fool2(2, 3.14); // T:double

            // 불가능 - 매개 변수를 모두 포함할 수 있는 타입x 
            // Fool2(2, "a"); 

            // 위에꺼 가능하게 하려면 모든 타입의 상위인 object
            Fool2<object>(2, "a");
        }
    }
}
