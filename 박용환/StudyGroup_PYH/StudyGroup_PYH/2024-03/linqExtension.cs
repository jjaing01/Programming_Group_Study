using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._2024_03
{
    internal class linqExtension
    {
        public static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            IEnumerable<int> col = arr.Select(n => n * 10);
            IEnumerable<int> col2 = arr.MySelect(n => n * 10);

            // 1. 지연된 실행
            // - Qyery Method를 호출하는 시점이 foreach문에서 요소에 접근하는 시점에 연산이 적용된다.
            // - 배열 arr를 참조하고 select 명령을 보관하고 있다가 foreach를 통해 요소에 접근할 때 연산이 적용된다.
            arr[0] = 0;

            foreach (int n in col)
            {
                Console.WriteLine(n);
            }

            // 2-1
            IEnumerator<int> e = col.GetEnumerator();

            while(e.MoveNext())
            {
                Console.WriteLine(e.Current);
            }

            // 3. Fluent query (linq)
            // "o" 가 포함되어 있는 단어를 길이 순으로 정렬하고 대문자로 바꾼다.
            string[] arr3 = { "kim", "lee", "park", "choi", "robert" };

            // 3-2 query syntax (sql 쿼리 문법과 비슷하다)
            var a = arr3.OrderBy(x => x.Length).Where(x => x.Contains("o")).Select(x => x.ToUpper());

            // 3-1. fluent syntax
            var col4 = from s in arr3
                       where s.Contains("o")
                       orderby s.Length
                       select s.ToUpper();


        }
    }

    // 2. Select() 함수 구현
    // - 확장 메서드 (Extension Method)
    // - Delegate(func)
    // - Lamda
    // - Coroutine
    // 위 개념이 필요
    public static class MyLinq
    {
        // 1-1. 기본 구현
        //public static IEnumerable<int> MySelect(this Array arr, Func<int, int> predicate)
        //{
        //    foreach(var n in arr)
        //    {
        //        yield return predicate((int)n);
        //    }
        //}

        public static IEnumerable<T> MySelect<T>(this IEnumerable<T> arr, Func<T,T> predicate)
        {
            foreach (var n in arr)
            {
                yield return predicate(n);
            }
        }
    }
}
