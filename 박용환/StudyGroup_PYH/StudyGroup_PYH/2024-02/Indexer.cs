using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._2024_02
{
    // 1.Indexer : 객체를 배열처럼 사용할 수 있게 하는 문법
    // - C++에서 [] 연산자 재정의
    class Indexer
    {
        class Sentence
        {
            private string[] words = null;
            public Sentence(string str)
            {
                words = str.Split(str); // 단어별로 분리해서 반환해준다.
            }

            // 2. 인덱서 생성
            // - 형태 : 반환 타입 + this[params] {}
            public string this[int idx]
            {
                get { return words[idx]; }
                set { words[idx] = value; }
            }

            public override string ToString()
            {
                // string.join = words에 있는 모든 요소들은 "" 기준으로 합친다
                // return string.Join(" ", words);
                return base.ToString();
            }            
        }

        // Property vs Indexer 동작 원리
        // - Property - get_(), set_(T Value)
        // - Indexer - get_(int idx), set_(int idx, T Value)

        // 즉, 인덱서는 파라미터 변수를 가지는 프로퍼티이다.
        class Test
        {
             public int this[int idx] { get { return 0; } }
            public int this[string idx] { get { return 0; } }
            public int this[int idx1, int idx2] { get { return 0; } }
            public int this[int idx1, string idx2] { get { return 0; } }
        }
        public static void main()
        {
            var sentence = new Sentence("Today Study Day");
            sentence[0] = "Yesterday";
            Console.WriteLine(sentence[0]);
            Console.WriteLine(sentence); // Tostring재정의 해야함

            // 4. 주의 사항
            // 인덱스의 타입이 반드시 정수일 필요는 없다.
            // 2개 이상의 인덱스 값도 가질 수 있다.
            Test test = new();
            int n1 = test["A"];
            int n2 = test[0, 1];
            int n3 = test[0, "A"];
        }
    }
}
