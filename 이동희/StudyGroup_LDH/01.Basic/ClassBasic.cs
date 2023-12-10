using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    class Base
    {
        // 1. 접근 지정자는 모든 멤버에 개별적으로 표기한다.
        public int data1 = 10;
        public int data2 = 20;
    }

    // 2. 상속은 : 연산자 사용한다.
    class Dervied : Base
    {
        // 4. 기반 클래스에 있는 변수를 새로 만들고 싶어 >> 그런데 warning
        //public int data1 = 20;

        // 4-1. 기반 클래스에 있는 변수를 새로 만들 때는 new 키워드를 사용하자
        public new int data1 = 30;
    }

    class Program
    {
        static void Main()
        {
            // 3. 객체 생성 시에는 () 있어야한다.
            Dervied d = new();

            Console.WriteLine(d.data1); // 30
            Console.WriteLine(((Base)d).data1); // 10
        }
    }
}
