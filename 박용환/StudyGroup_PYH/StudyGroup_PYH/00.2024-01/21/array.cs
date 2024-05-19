using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._00._2024_01._21
{
    class array
    {
        public static void main()
        {
            // 1. array는 reference type
            // 2. 배열의 생성과 초기화 방법
            int[] arr; // 참조 변수로서 활용
            int[] arr2 = new int[5]; //자동으로 0 초기화
            int[] arr3 = new int[5] { 1, 2, 3, 4, 5 }; // 생성 시 초기화. 초기 크기가 정해져있다면, 개수만큼 초기화를 해야한다.
            int[] arr4 = new int[] { 1, 2, 3, 4, 5 };
            int[] arr5 = { 1, 2, 3, 4, 5 };

            // 배열 clone
            int[] arr6 = { 1, 2, 3, 4, 5 };
            int[] arr7 = arr6;

            int[] arr8 = (int[])arr6.Clone(); // heap에 arr6의 복사본을 만들어라

            Console.WriteLine(arr6 == arr7); // true
            Console.WriteLine(arr6 == arr8); // false

            int[,] arr10 = new int[3, 2];
        }
    }
}
