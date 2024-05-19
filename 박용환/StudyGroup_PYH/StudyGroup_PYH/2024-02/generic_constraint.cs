using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._2024_02
{
    class generic_constraint
    {
        // 각각의 타입마다 메소드를 만들어주는 것은 좋지 않다.
        // generic을 사용하는데, 그러려면 내부 구현이 같아야 한다.
        public static int Max(int a, int b) => a.CompareTo(b) < 0 ? b : a;

        public static string Max(string a, string b) => a.CompareTo(b) < 0 ? b : a;

        public static T Max_Generic<T>(T a, T b)
        {
            return a.CompareTo(b) < 0 ? b : a; // object로 사용할 수 있는 연산만 가능하다.
        }

        public static T Max_Generic_New<T>(T a, T b) where T :IComparable
        {
            return a.CompareTo(b) < 0 ? b : a;
        }
        public static void main()
        {
            // ]3. generic constraint (제약 사항)
            // 5개 where T : class, ... -> reference type만 사용 가능
        }
    }
}
