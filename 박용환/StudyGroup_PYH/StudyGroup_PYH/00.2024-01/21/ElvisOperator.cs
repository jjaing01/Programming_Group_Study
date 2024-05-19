using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._00._2024_01
{
    class Test
    {
        public int number = 10;
        public void Func() => Console.WriteLine($"{5}");
    }

    class ElvisOperator
    {
        public static Test CreateTest(int _number)
        {
            return new Test();
        }

        public static void main()
        {
            var test = CreateTest(5);
            // .? + .[] (널 조건부 연산자)
            test?.Func();

            // 널 조건부 연산자 사용 시 주의점
            int n = test.number; // test가 null이면 예외 발생
            var n2 = test?.number; // var는 int? 이다, int는 null 값을 가질 수 없음 -> int? = int + bool
            int? n3 = test?.number; // OK

            int[] arr = null;
            int n4 = arr[0]; // error
            int? n5 = arr?[0];

            // ?? 널 접합 연산자, null coalescing operator)
            // 좌변이 null 이면 ?? 우변 실행한다.
            Test test1 = CreateTest(5) ?? new Test();
        }
    }
}
