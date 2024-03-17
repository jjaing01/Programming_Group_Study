using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    class Program
    {
        // [LINQ (Langauge Integrated Query 개념]
        // - 컬렉션에 대한 다양한 연산을 위한 쿼리
        // - using System.Linq;
        public static void Main(string[] args)
        {
            // 1. 모든 컬렉션은 IEnumerable 인터페이스를 구현한다.
            // foreach 원리: arr.GetEnumerator() 통해서 열거자를 꺼낸다.

            int[] arr = { 1, 2, 3, 4, 5 };
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }


            IEnumerable<int> col = arr;
            foreach (int n in col)
                Console.WriteLine(n);


            // 2. Linq를 사용하자
            int[] arr2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach(int n in arr2) 
            {
                // 3의 배수만 출력해보자
                if (n % 3 == 0)
                    Console.WriteLine(n);
            }
            Console.WriteLine("_____________________________________");

            IEnumerable<int> col2 = arr2.Where(IsOdd);
            foreach (int n in col2)
                Console.WriteLine(n);
            Console.WriteLine("_____________________________________");
            // (2) 다양하게 쿼리를 조합해보자
            // - 홀수만 출력
            // - 10을 곱한 값을 출력
            // - 앞에 3개의 원소는 제외하고 출력
            var col3 = arr2
                .Where(n => n % 2 == 1)
                .Select(n => n * 10)
                .Skip(3)
                .ToList();

            foreach (int n in col3.ToList())
                Console.WriteLine(n);
            Console.WriteLine("_____________________________________");


            bool IsOdd(int n)
            {
                return n % 2 == 1;
            }
        }
    }
}
