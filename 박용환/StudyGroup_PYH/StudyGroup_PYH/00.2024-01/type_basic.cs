using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._00._2024_01
{
    class type_basic
    {
        public static void Main()
        {
            // 1. C#은 할당되지 않은 변수를 사용할 수 없다.
            int i; // error

            // 2. 자료형이 서로 맞지 않는 상태에서 대입 연산을 하면 타입 에러 발생
            double d = 10.0;
            int i2 = d; // 다운 캐스팅 불가  (int) 명시적으로 작성해야 함.
            var n3 = int.TryParse("1", out var _); // no named parameter or anonymous

            // 3. C#에서 모든 것은 "객체", 모든 타입들은 Object를 상속받는다.
            10.ToString(); // 10도 객체
            int n4 = 10; // int는 별칭일 뿐이다.
            System.Int32 n5 = n4;

            // string == String == String.string
            string s = "AAA";
            String s = "AAA";
            System.String s = "AAA";

            // is as == 차이
        }
    }
}
