using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    class named_Optional_Parameter
    {
        public static void SetRect(int x, int y, int width, int height)
        {
            Console.WriteLine($"{x}, {y},{width},{height}");
        }

        public static void foo(int a, int b, int c)
        {
            Console.WriteLine($"{a},{b},{c}");
        }

        // - 마지막 인자부터 차례대로 지정해야 한다. -> - 중간 인자에 optional parameter 사용 불가능
        // - 컴파일 시간에 알 수 있는 상수만 초기값으로 사용할 수 있다.
        public static void foo1(int a, int b, int c = 10)
        {
            Console.WriteLine($"{a},{b},{c}");
        }


        public static void Main()
        {
            SetRect(10, 20, 30, 40); // 문제점 -> 가독성이 떨어진다.

            // 1.named Param
            SetRect(x: 10, y: 20, width: 30, height: 40);
            SetRect( y: 20, x: 10, height: 40, width: 30);
            SetRect(20, 10, height: 40, width: 30);

            // 2. optional param
            foo(1, 2, 3);
            foo1(1, 2);
        }
    }
}
