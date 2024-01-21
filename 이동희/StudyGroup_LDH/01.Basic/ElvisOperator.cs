using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    class Test
    {
        public int number = 10;
        public void Func() => Console.WriteLine($"{number}");
    }

    class ElvisOperator
    {
        public static Test CreateTest(int _number)
        {
            if (_number > 20)
            {
                return null;
            }
            return new Test();
        }

        public static void Main()
        {
            Test test = CreateTest(10);
            if(test is not null) /*test != null*/
            {
                test.Func();
                return;
            }

            // 1. ?. + ?[ (널 조건부 연산자)
            // 좌변이 null이면 좌변은 수행하지 않고 null은 반환한다.
            test?.Func(); // 객체 test가 null이면 Func를 호출하지 않는다.

            // 2. 널 조건부 연산자 사용 시 주의점
            int n = test.number; // test가 null이면 예외 발생
            //int n2 = test?.number; // error!! (int는 null 값을 가질 수 없음) int? = int + bool
            int? n3 = test?.number; // OK

            int[] arr = null;
            int n4 = arr[0];  // arr == null이면 예외 발생
            int? n5 = arr?[0]; ;

            // 3. ?? (널 접합 연산자, null coalescing operator)
            // 좌변이 null이면 ?? 우변 실행한다.
            Test test1 = CreateTest(50) ?? new Test();

            int? n6 = null;
            int n7 = n6 ?? 0;

            // A?.List?.Info?. => 주관적인 견해이지만 단점 아닌 단점일 수도 있을 것 같다.

            foreach (var data in datas) { }
            // list.Foreach()

            //List<> list;
            // list.Where(data =>
            // {
            //     if( data is null)
            //      {
            //          return false;
            //      }
            //      data?.Info
            // });
        } 
    }
}
