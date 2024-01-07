using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    struct SPoint
    {
        public int x;
        public int y;
        public SPoint(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
    class CPoint
    {
        public int x;
        public int y;
        public CPoint(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }

    class valueAndReference
    {
        public static void Main()
        {
            // 1.C/C++은 "객체의 메모리 위치를 타입을 만드는 사람이 아닌 타입을 사용하는 사람이 결정한다. (Stack, Heap, ......)
            // C# struct - value type(객체가 스택에 생성), class - reference type (객체가 힙에 생성) 

            SPoint sp1 = new(1, 2);
            CPoint cp1 = new(1, 2); // heap 객체 생성, stack cp1은 참조 변수

            // 문제 1
            SPoint sp2 = sp1;  // stack에 sp2가 만들어진다.

            sp2.x = 10;
            Console.WriteLine(sp1.x); // 1

            CPoint cp2 = cp1;  // stack에 cp2가 만들어지는데 주소가 복사되어 cp1가 똑같은 객체를 가르킨다.
            cp2.x = 10;
            Console.WriteLine(cp1.x); // 10
        }
    }
}
