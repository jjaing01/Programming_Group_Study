using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    // [객체의 동등성을 조사하는 방법]
    // 1. == 연산자 사용
    // 2. Equals() 가상 메서드 사용
    
    struct Point
    {
        private int x;
        private int y;

        public Point(int xPos, int yPos)
        {
            x = xPos;
            y = yPos;
        }

        public override bool Equals(object obj)
        {
            var pt = (Point)obj;
            return x == pt.x && y == pt.y;
        }

        // 연산자 재정의 (C#에서 연산자 재정의는 static Method로 정의한다)
        public static bool operator ==(Point a, Point b) =>
            a.x == b.x && a.y == b.y;

        public static bool operator !=(Point a, Point b) =>
            a.x != b.x || a.y != b.y;
    }

    enum STATE { NONE, READY }

    class Equality
    {
        static void Main()
        {
            Point p1 = new Point(1, 1);
            Point p2 = p1;
            Point p3 = new Point(1, 1);

            // 방법 1. == 연산자
            // 기본 동작: 참조 주소가 동일한가?
            Console.WriteLine(p1 == p2); // true
            Console.WriteLine(p1 == p3); // false

            // 방법 2. Equals() 가상함수
            // 기본 동작: 참조 주소가 동일한가?
            Console.WriteLine(p1.Equals(p2));  // true
            Console.WriteLine(p1.Equals(p3));  // false

        
        }
    }
}
