using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    internal class LinqProcess
    {
        public static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            IEnumerable<int> col = arr.Select(n => n * 10);
            IEnumerable<int> col1 = arr.MySelect(n => n * 10);

            // 1. 지연된 실행
            // - Query Method를 호출하는 시점이 foreach문에서 요소에 접근하는 시점에 연산이 적용된다
            // - 배열 arr을 참조하고 Select 명령을 보관하고 있다가 foreach를 통해 요소에 접근할 때 연산이 적용된다.
            arr[0] = 0;

            foreach (int n in col1)
                Console.WriteLine(n); // 0 20 30 40 50

            // 2-1
            IEnumerator<int> e = col1.GetEnumerator();

            while (e.MoveNext())
            {
                Console.WriteLine(e.Current);
            }

            // 3. Fluent Query (Linq)
            // "o" 가 포함되어 있는 단어를 길이 순으로 정렬하고 대문자로 바꾼다.
            string[] arr3 = { "kim", "lee", "park", "choi", "robert" };

            // 3-1. Fluent Syntax (확장 메서드 호출 표기법)
            var col3 = arr3
                .Where(s => s.Contains("o"))
                .OrderBy(x => x.Length)
                .Select(x => x.ToUpper());
            // 3-2. Query Syntax (SQL 쿼리 문법과 비슷하다)
            var col4 = from s in arr3
                       where s.Contains("o")
                       orderby s.Length
                       select s.ToUpper();
            foreach (var n in col4)
                Console.WriteLine(n);

        }
    }

    // 2. Select() 함수를 구현해보자
    // - 확장 메서드 (Extension Method)
    // - Delegate (Func)
    // - Lambda
    // - Coroutine
    // 위 개념이 필요하다.
    public static class MyLinq
    {
        // 2-1. 기본 구현
        //public static IEnumerable<int> MySelect(this Array arr, Func<int,int> predicate)
        //{
        //    foreach (int n in arr)
        //    {
        //        yield return predicate(n);
        //    }
        //}

        public static IEnumerable<T> MySelect<T>(this IEnumerable<T> arr, Func<T,T> predicate)
        {
            foreach (T n in arr)
            {
                yield return predicate(n);
            }
        }

    }
}
