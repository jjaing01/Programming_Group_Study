using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    class CallBy
    {
        // 1. 값 전달 (call by value)
        public static void inc1(int n) { ++n; }         // int n = n1;
        
        // 2. 참조 전달 (call by reference)
        public static void inc2(ref int n) { ++n; }     // ref int n = ref n2;

        public static void Main()
        {
            int n1 = 10;
            int n2 = n1;
            n2 = 20;

            Console.WriteLine($"{n1},{n2}");

            int n3 = 10;
            // 1. 정수형 변수를 만들 것인데, n3를 가리킬 것이다.

            /*
             * ref 키워드를 사용하면 변수 간의 참조를 전달하므로 실제 값이 복사되지 않고 메모리 위치가 전달
             */
            ref int n4 = ref n3;
            n4 = 20;

            Console.WriteLine($"{n3},{n4}");

            inc1(n1);
            inc2(ref n4);
        }
    }
}
