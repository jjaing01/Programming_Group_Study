using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[5] { 1, 2, 3, 4, 5 };

            FileStream fs = new FileStream("A.txt", FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None);

            // 1. C#에서 메모리는 자동으로 소멸되지만, File 객체 같은 경우는 Dispose를 통해서 반납해야 한다.
            // 일반적인 타입: GC에 의해 자동으로 관리된다.
            // 파일, 네트워크, DB 등: Dispose()를 통해서 명시적으로 자원을 해지해야 한다.
            fs.Dispose();
        }
    }

    class Program2
    {
        class Car
        {
            public void Go()
            {
                Console.WriteLine("Car GO");
            }

            public static void Main(string[] args)
            {
                // 2. Garbage Collector
                Car c1 = new Car();
                Car c2 = new Car();

                // 2-1. 참조 변수를 더 이상 참조하지 않아도 메모리는 즉시 반환되는 것은 아니다.
                // 왜? 아직까지 Heap 메모리는 충분한 공간이 있어서 바로 삭제하는 것은 오히려 성능 저하를 초래한다.
                // 언제? 특정 조건 (메모리 부족, 직접적인 호출 등)을 만족할 때 메모리가 반납된다.
                c2 = null;

                // 2-2. 강제로 더 이상 사용하지 않는 메모리를 반납하는 방법
                GC.Collect(); // 이 순간에는 바로 반환되는 것이 아니다.
                GC.WaitForPendingFinalizers(); // 이 순간에 반환된다.

                // 2-3. Dispose 사용 이유
                // 실제 Finalizer()를 명시적으로 호출하여 반납을 하기 위함이다.
            }
        }
    }
}
