using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LYS.generic_constraint
{
    class Program
    {
        // 아래처럼 각각의 타입마다 메소드를 만들어주는 것은 좋지 않다.
        // generic을 사용한다.
        // generic을 사용하려면 내부 구현이 같아야한다.
        public static int Max(int a, int b) => a.CompareTo(b) < 0 ? b : a;
        public static string Max(string a, string b) => a.CompareTo(b) < 0 ? b : a;

        //public static T Max_Generic<T>(T a, T b)
        //{
        //    return a.CompareTo(b) <0 ? b : a;  // object로 할 수 있는 연산만 가능하다.
        //}

        public static T Max_Generic_New<T>(T a, T b) where T :IComparable
        {
            // ComapreTo 는 IComparable에 구현되어 있으므로 where를 걸면 여기에는 CompareTo 가 구현된 객체만 들어올 수 있따.
            return a.CompareTo(b) < 0 ? b : a;  
        }

        public static void Main(string[] args) 
        {
            // Generic Constrait - 제양
            // where T : class, -> Reference Type만 사용 가능
            // where T : stuct, -> Value Type만 사용 가능
            // where T : new(), -> 디폴트 생성자가 있는애들만(가장 뒤에 추가해야 한다)
            // where T : 인터페이스 이름 -> 해당 인터페이스가 구현되어 있는 타입만 사용 가능
            // where T : 클래스명 -> 해당 클래스로부터 파생된 타입만 사용 가능
            //
        }
    }
}
