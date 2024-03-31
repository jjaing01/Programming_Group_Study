using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// linq : language integorated query (컬렉션에 대한 다양한 연산을 위한 쿼리)

class LinqExtension
{
    static void ForEach(IEnumerable<int> enu)
    {
        foreach(var item in enu)
        {
            Console.WriteLine(item);
        }
    }
}



namespace StudyGroup_PYH._2024_03
{
    internal class linq
    {
        public static void Main()
        {
            // 1. 모든 콜렉션은 IEnumerable 인터페이스를 구현한다.
            // foreach 원리 : arr.GetEnumerator() 통해서 열거자를 만든다.
            // 
            int[] arr = { 1, 2, 3, 4, 5 };
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }

            IEnumerable<int> ints = arr;
            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }


            // 2. linq를 사용
            // select은 가공의 목적
            // where는 조건의 목적
            int[] arr2 = { 1, 2, 3, 4, 5 ,6,7,8,9,10};
            var threes = ints.Where(x => x % 3 == 0);

            var temp = ints.Where(IsAdd);
             bool IsAdd(int n) => n % 2 == 1;
            // { return n == 1; }

            // (2) 쿼리 조합
            // 앞에 3개 원소 제외하고 홀수 * 10
            IEnumerable<int> ints3 = arr2.Skip(3).Where(x => (x % 2 == 1)).Select(x => x * 10);

        }
    }
}
