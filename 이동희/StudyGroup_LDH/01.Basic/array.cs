using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    class array
    {
        public static void Main()
        {
            // 1.array는 Reference Type이다.
            // 2.배열의 생성과 초기화 방법
            int[] arr; // 참조 변수로서 활용
            int[] arr2 = new int[5]; // 자동으로 0 초기화
            int[] arr3 = new int[5] { 1, 2, 3, 4, 5 }; // [5] 처럼 초기 크기가 정해져있다면, 개수만큼 초기화를 해야 한다.
            int[] arr4 = new int[] { 1, 2, 3, 4, 5 };
            int[] arr5 = { 1, 2, 3, 4, 5 };

            // 3. 배열 타입
            // - 모든 배열은 System.Array로 부터 파생된다. 다양한 멤버함수를 지닌다.
            Type t = arr5.GetType();
            Console.WriteLine(t.FullName);                      // arr5의 타입: System.Int32[]
            Console.WriteLine(t.BaseType.FullName);             // System.Int32[]의 기반 타입: System.Array
            Console.WriteLine(t.BaseType.BaseType.FullName);    // System.Array의 기반 타입: System.Object
            System.Array a;

            // 4. 배열 메소드
            Console.WriteLine(arr5.Length);             // 5개짜리 배열
            Console.WriteLine(arr5.GetLength(0));       // 5 -> 1차원 배열: 0번
            Console.WriteLine(arr5.GetValue(3));        // 3번째 요소의 값 arr5[3] = 4
            Console.WriteLine(arr5.GetLowerBound(0));   // 인덱스의 최소값: 0
            Console.WriteLine(arr5.GetUpperBound(0));   // 인덱스의 최대값: 4

            // 5. 배열 Clone
            int[] arr6 = { 1, 2, 3, 4, 5 };
            int[] arr7 = arr6;

            // 5-1. Clone의 Return 값은 object Type이므로 Casting
            int[] arr8 = (int[])arr6.Clone(); // Heap에 arr6 복사본을 만들어라 의미

            Console.WriteLine(arr6 == arr7);    // true
            Console.WriteLine(arr6 == arr8);    // false

            // 6. 다차원 배열
            // 6-1. 2차원 배열
            int[,] aarr1 = new int[3, 2]; // 2개 원소를 지닌 배열 3개를 만든 것과 같다.
            int[,] aarr2 = new int[3, 2] { { 1, 1 }, { 2, 2 }, { 3, 3 } };
            int[,] aarr3 = new int[,] { { 1, 1 }, { 2, 2 }, { 3, 3 } };
            int[,] aarr4 = { { 1, 1 }, { 2, 2 }, { 3, 3 } };                 // 위와 동일한 생성

            aarr1[0, 0] = 10;
            aarr1[0, 1] = 20;

            // 3차원 배열
            int[,,] aaarr5 = new int[2, 2, 2];

            int[][] e = new int[3][] { new int[3], new int[2], new int[1] };

            foreach (int[] n in e)
            {
                foreach (int i in n) Console.WriteLine(i);
                Console.WriteLine("__________________________");
            }
        }
    }
}
