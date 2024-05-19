using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LYS.idx
{

    class Program
    {
        // 1. Indexer = 객체를 배열처럼 사용할 수 있게 하는 문법

        class Sentece
        {
            private string[] words = null;
            public Sentece(string str)
            {
                words = str.Split(); //단어별로 분리해서 반환
            }

            // 2. 인덱서 생성
            // - 형태 : 반환 타입 + this[params] {}
            // 
            public string this[int idx]
            {
                get { return words[idx]; }
                set { words[idx] = value; }
            }

            public override string ToString()
            {
                // WriteLine은 ToString을 출력 함 
                // ToString을 override해서 호출하면 이거 호출
                return string.Join(" ", words);
            }

        }

        // 3. Property vs Indexer 동작 원리
        // - Property - get_(), set_(T Value)
        // - Indexer - get_(int idx), set_(int idx, T_Value)


        // 즉, 인덱서는 파라미터 변수를 가지는 프로퍼티이다.

        class Test
        {
            public int this[int idx] { get { return 0; } }
            public int this[string idx] { get { return 0; } }
            public int this[int idx1, int idx2] { get { return 0; } }
            public int this[int idx1, string idx2] { get { return 0; } }
        }

        public static void Main()
        {
            Sentece sentece = new("Today Study Day");
            sentece[0] = "Yesterday";

            Console.WriteLine(sentece[0]);
            Console.WriteLine(sentece);


            // 4. 주의 사항
            // 인덱스의 타입이 반드시 정수일 필요는 없다.
            // 2개 이상의 인덱스 값도 가질 수 있다.
            Test test = new();
            int n1 = test["a"];
            int n2 = test[1, 2];
        }
    }

    
}
