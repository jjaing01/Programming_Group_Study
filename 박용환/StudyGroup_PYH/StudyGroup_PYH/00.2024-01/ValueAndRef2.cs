using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// value type
// struct, enum
// int, double 등의 수치 타입

// ref type
// class, interface, delegate, array, object, string 등 .netFramework 에서 지원하는 수많은 library

namespace StudyGroup_PYH._00._2024_01
{
    enum STATE { NONE }

    class ValueAndRef2
    {
        static void Main()
        {
            STATE state = STATE.NONE;

            // value? reference? type 확인
            // 모든 타입에는 gettype() 존재, type 클래스의 isvaluetype 속성 확인
            int[] arr = { 1, 2, 3 };
            Type t = arr.GetType();
            Console.WriteLine(t.IsValueType);

            var test = state.GetType();
            Console.WriteLine(testc.isValueType);

        }
    }
}
