using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_HSY._240317
{
    internal class _1_LinqProcess
    {
        public static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5, };
            IEnumerable<int> col = arr.Select(n => n * 10);
            IEnumerable<int> col1 = arr.MySelect<int>(n => n * 10);

            // 1. 지연된 실행
            // - Query Method를 호출하는 시점이 foreach 문에서 요소에 접근하는 시점에 연산이 적용된다.
            // 배열 arr을 참조하고 Select 명령을 보관하고 있다가 foreach를 통해 요소에 접근할 떄 연산이 적용된다.
            foreach (int n in col1)
                Console.WriteLine(n);

            Console.WriteLine("-----------------------");

            // 2-1
            IEnumerator<int> e = col1.GetEnumerator();
            while (e.MoveNext())
            {
                Console.WriteLine(e.Current);
            }
        }
    }

    // 2. Select() 함수를 구현해보자.
    // - 확장 메서드 (Extension Method)
    // - Delegate (Func)
    // - Lamda
    // - Coroutine
    // 위 개념이 필요하다.
    public static class MyLinq
    {
        // 2-1. 기본 구현.
        //public static IEnumerable<int> MySelect(this Array arr, Func<int, int> predicate)
        //{
        //    foreach (int n in arr)
        //    {
        //        yield return predicate(n);
        //    }
        //}

        public static IEnumerable<T> MySelect<T>(this Array arr, Func<T,T> predicate)
        {
            foreach (T n in arr)
            {
                yield return predicate(n);
            }
        }
    }
}
