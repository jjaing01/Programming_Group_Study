using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_HSY._240317
{
    internal class Program
    {
        // LINQ (Language Integrated Query) 개념
        // - 컬렉션에 대한 다양한 연산을 위한 쿼리.
        // - using System.Linq;
        public static void Main(string[] args)
        {
            // 1. 모든 컬렉션은 IEnumerable 인터페이스를 구현한다.
            // foreach 원리 : arr.GetEnumerator() 통해서 열거자를 꺼낸다.
            int[] arr = { 1, 2, 3, 4, 5, };
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("----------------------------------");

            IEnumerable<int> col = arr;
            foreach (int n in col)
                Console.WriteLine(n);

            // 2. Linq를 사용하자.
            int[] arr2 = { 1,2,3,4,5,6,7,8,9,10 };
            foreach (int n in arr2)
            {
                // 3의 배수만 출력.
                if (n % 3 == 0)
                    Console.WriteLine(n);
            }

            // 3. Fluent Query (Linq)
            // "o" 가 포함되어 있는 단어를 길이 순으로 정렬하고 대문자로 바꾼다.
            string[] arr3 = { "kim", "lee", "park", "choi", "robert" };

            // 3-1 Fluent Syntax (확장 메서드 호출 표기법)
            IEnumerable<string> col4 = arr3
                .Where(s => s.Contains("o"))
                .Select(s => s.ToUpper())
                .OrderBy(s => s.Length);

            foreach (var n in col4)
                Console.WriteLine(n);

            // 3-2 Query Syntax (SQL 쿼리 문법과 비슷)
            var col5 = from s in arr3
                       where s.Contains("o")
                       orderby s.Length
                       select s.ToUpper();

            foreach (var n in col5)
                Console.WriteLine(n);


            Console.WriteLine("----------------------------------");

            IEnumerable<int> col2 = arr2.Where(n => n % 3 == 0);
            foreach (int n in col2)
                Console.WriteLine(n);

            Console.WriteLine("----------------------------------");

            // (2) 다양하게 쿼리를 조합해보자.
            // - 홀수만.
            // - 10을 곱한 값 출력.
            // - 앞에 3개의 원소는 제외하고 출력.
            IEnumerable<int> col3 = arr2
                .Where(n => n % 2 == 1)
                .Select(n => n * 10)
                .Skip(3);
            // .ToList()
            // .ToDictionary() 기능도 굉장히 유용함.
            // IEnumerable 은 add, erase 기능이 없음. read only 용도로 많이 쓰임.

            foreach (int n in col3)
            { 
                Console.WriteLine(n); 
            }

            Console.WriteLine("----------------------------------");


        }
    }
}
