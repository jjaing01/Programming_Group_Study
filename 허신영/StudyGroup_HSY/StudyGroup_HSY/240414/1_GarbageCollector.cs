using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_HSY._240414
{
    internal class _1_GarbageCollector
    {
        class A { }
        class B { }
        class C { }

        public static void Main(string[] args)
        {
            // 1. C# heap 메모리 할당은 연속적인 공간에 발생한다.
            // (1) C/C++ heap 메모리 할당할 경우
            // 메모리를 특정 크기 블록들로 나눠놓고 적합한 곳을 찾아가는 작업을 진행한다.
            // (2) C#의 메모리 할당은 heap을 연속적으로 사용한다. 그래서 속도가 빠르다.

            A a1 = new A();
            B b1 = new B();
            C c1 = new C();

            // 2. Garbage Collector 원리
            // (1) n세대 heap으로 구분한다. (세대는 2가 max다)
            // - Collector에 수집되지 않은 자원들은 세대가 올라간다.
            // - 높은 세대 자원들은 하위 세대 메모리가 가득 차지 않는 이상 절대로 수집 대상이 되지 않는다.

            // (2) 그래서 단점은?
            // 높은 세대 자원들을 반납하고 싶은데, 하위 세대가 가득차지 않는 이상
            // GC는 높은 세대 메모리를 수집할 생각을 하지 않는다.

            // 2-1. 세대 확인하기
            Console.WriteLine(GC.GetGeneration(a1)); // 0세대
            Console.WriteLine(GC.GetGeneration(b1)); // 0세대
            Console.WriteLine(GC.GetGeneration(c1)); // 0세대

            Console.WriteLine("--------------------");
            GC.Collect(0); // 0세대에 대해 GC를 해달라는 의미.
            Console.WriteLine(GC.GetGeneration(a1)); // 1세대
            Console.WriteLine(GC.GetGeneration(b1)); // 1세대
            Console.WriteLine(GC.GetGeneration(c1)); // 1세대
            Console.WriteLine("--------------------");

            b1 = null;
            Console.WriteLine(GC.GetGeneration(a1));

            // 2-2 결론
            // 사용자가 GC를 하는 것은 좋지 않다.
            // 괜히 세대만 올라가는 경우가 생기고, 반납까지 시간이 더 오래걸리므로
            // GC 자체에서 알아서 관리하도록 하자.
        }
    }
}
