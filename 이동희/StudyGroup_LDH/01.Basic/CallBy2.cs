using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    class Point
    {
        public int x;
        public int y;
        public Point(int a, int b) { x = a; y = b; }
    }

    class CallBy2
    {
        // 1개의 메소드에서 2개의 결과 값을 반환 받고 싶다!!
        // 1. ref int ret 같은 매개변수를 out parameter라고 부른다.

        public static int prev_next_number1(int n, ref int ret)
        {
            //int a = ret; // ok
            ret = n + 1;
            return n - 1;
        }

        // 2. Out Parameter 의 또다른 표현: out 키워드
        public static int prev_next_number2(int n, out int ret)
        {
            //int a = ret; // error
            ret = n + 1;
            return n - 1;
        }

        // 매개 변수의 ref vs out
        /*
         * [ref]
         * 원본 변수를 Read/Write 모두 가능하다. 초기화 된 변수만 전달할 수 있다.
         * [out]
         * 원본 변수를 Write만 가능하다. 초기화 되지 않는 변수 또한 전달할 수 있다.
         * 메소드에서 2개 이상의 결과를 반환 받고 싶을 때 주로 사용한다.
         */

        public static void f1(Point p)
        {
            p.x = 2;
        }

        public static void f2(ref Point p)
        {
            p.x = 3;
            p = new Point(10, 10);

            Console.WriteLine(p.x);
        }

        public static void Main()
        {
            int n1 = 10;
            int result2 = 0;

            int result1 = prev_next_number1(n1, ref result2);
            int result3 = prev_next_number2(n1, out var result4);

            Point p1 = new Point(1, 1);
            f1(p1);
            Console.WriteLine(p1.x); // 2 -> referece Type 이니깐 같은 객체에 접근한다.

            // 3. ref Reference Type parameter
            f2(ref p1);
            Console.WriteLine(p1.x); // 10 -> 실제 객체를 가리키는 것이 아니라 p1을 가리키게 된다.
        }
    }
}
