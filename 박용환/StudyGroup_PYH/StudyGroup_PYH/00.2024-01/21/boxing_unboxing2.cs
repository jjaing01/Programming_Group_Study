using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._00._2024_01._21
{
    class Point : IComparable, IComparable<Point> // 쌍으로 사용한다.
    {
        public int x;
        public int y;
        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public int CompareTo(Point other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }

    class boxing_unboxing2
    {
        public static void Main()
        {
            // 객체의 크기 비교
            // 1. 관계 연산자: <, > : 수치 관련 타입만 제공한다.
            // - 관계 연산자를 제공하지 않는 object는 연산자 재정의를 통해 사용 가능하다.

            // 1-1 ComparableTo() 메서드를 사용한다.
            // 같은 경우 : 0
            // 작으면 : -1
            // 크면 : 1

            Console.WriteLine(10.CompareTo(20));

            string str1 = "str1";
            string str2 = "str2";
            Console.WriteLine(str1 < str2);
            Console.WriteLine(str1.CompareTo(str2)); // 아스키코드로 크기 비교를 한다.

            Point pt1 = new Point(1, 2);
            Point pt2 = new Point(2, 3);
        }
    }
}
