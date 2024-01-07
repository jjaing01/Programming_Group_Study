using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    class Base
    {
        public void Foo()
        {
            Console.WriteLine("Base foo");
        }
    }

    class Derived : Base
    {
        // new 표기법을 사용하면 오버라이딩 함수 또한 오류를 제거 할 수 있다. -> 그러나 가상함수가 되는 것은 아니다.
        // new를 표기한 함수는 가상 함수를 오버라이딩 하는 것이 아닌 새로운 함수를 정의한 것이다.
        public new void Foo()
        {
            Console.WriteLine("Derived foo");
        }
    }

    class Program
    {
        public static void Main()
        {
            Base b1 = new Base();
            b1.Foo(); // Base.Foo

            Derived d1 = new /* Derived */();
            d1.Foo(); // Derived.Foo

            Base b2 = new Derived();
            b2.Foo(); // Base Foo
        }
    }
}
