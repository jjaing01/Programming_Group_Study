using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// value type
// - struct, enum
// - int, double 등의 수치 관련 타입

// reference type
// - class, interface, delegate
// - object, string, array../  .netFramework에서 지원하는 수많은 클래스 라이브러리들
namespace StudyGroup_LDH._01.Basic
{
    enum STATE { NONE }

    class valueAndReference2
    {
        static void Main()
        {
            STATE state = STATE.NONE;
            // value? reference? type 조사하기
            // 모든 타입에는 GetType()이 존재하고 Type 클래스의 isValueType 속성으로 확인 가능하다.
            int[] arr = { 1, 2, 3 };
            Type t = arr.GetType();
            Console.WriteLine(t.IsValueType);

            var test = state.GetType();
            Console.WriteLine(test.IsValueType);
        }
    }
}
