using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    struct MyPoint : IEquatable<MyPoint>
    {
        public int x;
        public int y;

        public MyPoint(int xPos, int yPos) { x = xPos; y = yPos; }

        // 1-1. object 타입의 Equals 오버라이드 하여 비교 연산 하는 방법
        public override bool Equals(object obj) // parameter boxing
        {
            MyPoint pt = (MyPoint)obj; // unboxing
            return x == pt.x && y == pt.y;
        }

        // 1-2. IEquatable 인터페이스 사용
        public bool Equals(MyPoint other) // parameter를 MyPoint 받는다.
        {
            return x == other.x && y == other.y;
        }
    }

    class boxing_unboxing
    {
        public static void Main()
        {
            MyPoint p1 = new MyPoint(1, 1);
            MyPoint p2 = new MyPoint(2, 2);

            Console.WriteLine(p1.Equals(p2)); // 1.1 방법으로 구현할 경우 -> 성능 저하 초래
                                              // 1.2 인터페이스를 활용해서 박싱/언박싱으로 인한 성능 저하를 해결 가능하다.
        }
    }
}
