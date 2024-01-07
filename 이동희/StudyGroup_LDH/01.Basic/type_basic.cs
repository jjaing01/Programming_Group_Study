using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    class type_basic
    {
        class Base //: System.Object
        {
            public void Foo()
            {
                Console.WriteLine("Base foo");
            }
        }

        public static void Main()
        {
            // 1. C#은 할당되지 않은 변수를 사용할 수 없다.
            // C++은 쓰레기 값으로 초기화가 된다.
            int n1 = 10;
            Console.WriteLine(n1);

            // 2. 자료형이 서로 맞지 않은 상태에서 대입 연산을 하면 타입 에러 발생
            double n2 = 10;
            var n3 = int.TryParse("1", out var _);
            var n4 = n2;

            // 3. C#에서 모든 것은 "객체", 모든 타입들은 Object를 상속받는다.
            10.ToString();

            Base b = new();
            b.Equals
            // ==, !=

            int n5 = 10; // int는 별칭일 뿐이다.
            System.Int32 n6 = 10;


            // string == String == System.String
            string s1 = "AAA";
            String s2 = "AAA";
            System.String s3 = "AAA";   

        }
    }
}
