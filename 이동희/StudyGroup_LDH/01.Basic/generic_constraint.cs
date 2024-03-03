using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    class Program
    {
        // 각각의 타입마다 메소드를 만들어주는 것은 좋지 않다.
        // generic을 사용한다.
        // generic을 사용하려면 내부 구현이 같아야 한다.

        public static int Max(int a, int b) => a.CompareTo(b) < 0 ? b : a;

        public static string Max(string a, string b) => a.CompareTo(b) < 0 ? b : a;

        ////public static T Max_Generic<T>(T a, T b)
        ////{
        ////    return a.CompareTo(b) < 0 ? b : a; // object로 할 수 있는 연산만 가능하다.
        ////}

        public static T Max_Generic_New<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b) < 0 ? b : a;
        }

        public static void Main()
        {
            // [3. Generic Constraint (제약 사항)]
            // - where T : class, ...               ->  Reference Type만 사용 가능
            // - where T : struct, ...              ->  Value Type만 사용 가능
            // - where T : new(), ...               ->  디폴트 생성자가 있어야만 사용 가능 (가장 뒤에 추가해야 한다)
            // - where T : 인터페이스 이름, ...      ->  해당 인터페이스가 구현되어 있는 타입만 사용 가능
            // - where T : 클래스 이름, ...          ->  해당 클래스로부터 파생된 타입만 사용 가능
        }
    }
}
