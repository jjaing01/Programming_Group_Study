using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    class Point : IComparable, IComparable<Point>
    {
        public int x;
        public int y;

        public Point(int xPos, int yPos)
        {
            x = xPos;
            y = yPos;
        }

        public int CompareTo(object obj)
        {
            Point pt = obj as Point;
            if (x > pt?.x) return 1;
            else if (x == pt?.x) return 0;
            return -1;
        }

        public int CompareTo(Point other)
        {
            throw new NotImplementedException();
        }
    }
    class boxing_unboxing2
    {
        public static void Main()
        {
            // [객체의 크기 비교]
            // 1. 관계 연산자: <, > : 수치 관련 타입만 제공한다.
            // - 관계 연산자를 제공하지 않는 object는 연산자 재정의를 통해 사용 가능하다.

            // 1-1. CompareTo() 메소드를 사용한다.
            // 같을 경우: 0
            // 작으면: -1
            // 크면: 1

            Console.WriteLine(10 < 20); // true
            Console.WriteLine(10.CompareTo(20)); // -1
            Console.WriteLine(10.CompareTo(10)); // 0
            Console.WriteLine(10.CompareTo(5)); // 1

            string s1 = "AAA";
            string s2 = "BBB";
            //Console.WriteLine(s1 < s2); // string 타입은 관계 연산자를 제공하지 않는다.
            Console.WriteLine(s1.CompareTo(s2)); // 아스키코드로 크기 비교를 한다.

            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            Console.WriteLine(p1.CompareTo(p2)); // 박싱,언박싱으로 인한 성능 문제가 해결되지 않는다.
        }
    }
}
