using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._00._2024_01_21
{
    struct Point : IEquatable<Point>
    {
        public int x;
        public int y;

        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        // 1-1 방법
        public override bool Equals(object obj) // boxing value -> ref
        {
            Point pt = (Point)obj; // unboxing ref -> value
            return x == pt.x && y == pt.y;
        }

        // 1-2 interface
        public bool Equals(Point other)
        {
            return x == other.x && y == other.y;
        }

    }
    class boxing_unboxing
    {
        public static void Main()
        {
            Point p1 = new Point(1, 2);
            Point p2 = new Point(2, 3);

            Console.Write(p1.Equals(p2)); // 1.1방법으로 구현할 경우 -> 성능 저하 초래
                                          // 1.2인터페이스를 활용해서 박싱/언박싱으로 인한 성능 저하를 해결 가능하다.
        }
    }
}
