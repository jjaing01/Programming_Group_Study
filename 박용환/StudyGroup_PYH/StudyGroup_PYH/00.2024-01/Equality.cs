using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._00._2024_01
{
    // 객체 동등성 조사
    // 1. == 연산자 사용
    // 2. EqualTo() 가상 메서드 사용

    class Point
    {
        private int x = 0;
        private int y = 0;

        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        // 문제 : 박싱 언박싱 성능
        public override bool Equals(object obj)
        {
            if(obj is Point point)
            {
                return x == point.x && y == point.y;
            }

            //Point pt = (Point)obj; null 체크 : obj as Point ?? new Point(1,2) 터트리기는 싫을때
            // var pt = obj as Point 
            // return x == pt.x && y == pt.y

            return false;
        }

        // 연산자 재정의 (C#에서 연산자 재정의는 static Method로 정의한다)
        public static bool operator ==(Point a, Point b) // 람다식 => a.x == b.x && a.y == b.y;
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(Point a, Point b)
        {
            // return !(a==b);
            return a.x != b.x || a.y != b.y;
        }
    }


    class Equality
    {
        static void Main()
        {
            Point p1 = new Point(1, 2);
            Point p2 = p1; // 같은 메모리
            Point p3 = new Point(1, 4);

            // 방법 1. == 연산자
            // 기본 동작 : 참조 주소
            Console.WriteLine(p1 == p2); // true
            Console.WriteLine(p1 == p3); // false

            // 방법 2. Equls() 가상함수
            // 기본 동작 : 참조 주소
            Console.WriteLine(p1.Equals(p2)); // true -> true (equals 재정의 후)
            Console.WriteLine(p1.Equals(p3)); // false -> true (equals 재정의 후) 
        }
    }
}
