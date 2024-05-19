using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyGroup_HSY._240317
{
    internal class Program
    {
        public static void Foo()
        {
            Thread t = Thread.CurrentThread;
            Console.WriteLine($"Foo : {t.ManagedThreadId}");
            Console.WriteLine($"Foo Priority : {t.Priority}");
            Console.WriteLine($"Foo IsThreadPoolThread : {t.IsThreadPoolThread}");
            Console.WriteLine($"Foo IsAlive : {t.IsAlive}");

            Console.WriteLine("Foo Start");
            Thread.Sleep(2000);
            Console.WriteLine("Foo End");
        }

        // 2. Thread 생성자
        public static void F1() { }
        public static void F2(object obj) { }
        public static void F3(string str) { }
        public static void F4(string s1, int n) { }

        public static void Main(string[] args)
        {
            // 1. Thread 생성
            // - Thread 객체 생성
            // - Thread Start() 호출하여 시작.
            Thread t = new Thread(Foo);
            t.Start();

            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"Main : {currentThread.ManagedThreadId}");
            // 3. Thread 우선 순위
            Console.WriteLine($"Main Priority : {currentThread.Priority}");
            // 4. 현재 쓰레드가 쓰레드 풀에 있는 것인지 확인.
            Console.WriteLine($"Main IsThreadPoolThread : {currentThread.IsThreadPoolThread}");
            // 5. 현재 쓰레드가 살아있는지
            Console.WriteLine($"Main IsAlive : {currentThread.IsAlive}");

            Console.WriteLine("Main Start");
            Thread.Sleep(2000);
            Console.WriteLine("Main End");

            // 2-1 Thread 생성자 호출
            // (1) 인자 없는 쓰레드
            Thread t1 = new Thread(F1);
            t1.Start();

            // (2) object 인자 쓰레드
            Thread t2 = new Thread(F2);
            t2.Start("hello f2");

            // (3) object type이 아닌 인자 쓰레드
            // - 내부 delegate는 object 파라미터만 받을 수 있다.
            //Thread t3 = new Thread(F3); // error. => object 타입만 가능하다.
            //t3.Start("hello f3");

            // (3-1) 위 문제 해결 방법.
            // - 새로운 쓰레드를 만들면서 람다 표현식을 수행한다.
            // - () => 인자가 없다는 의미이므로, 인자 없는 쓰레드 Delegate로 간주.
            Thread t4 = new Thread(() => F3("hello f3"));
            t4.Start();

            // (4) object type이 아닌 (인자 + 인자) 쓰레드
            // - 인자의 타입이 object가 아니거나, 인자의 개수가 여러 개인 경우 => 람다 사용.
            // 똑같이 람다 표현식을 사용하여 해결한다.
            Thread t5 = new Thread(() => F4("hello f4", 5));

            
            // 5.   Foreground Thread : 주 스레드가 종료되어도 나머지 쓰레드는 계속 작업을 수행한다.
            //      Background Thread : 주 쓰레드가 종료되면 나머지 쓰레드는 강제로 종료된다.
            t1.IsBackground = true;
            t1.Join(); // 자식 쓰레드의 종료를 대기한다.

        }
    }
}
