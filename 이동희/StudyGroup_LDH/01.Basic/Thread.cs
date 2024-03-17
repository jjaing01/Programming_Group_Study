using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace StudyGroup_LDH._01.Basic
{
    internal class Program
    {
        public static void Foo()
        {
            // Thread Id 
            Thread t = Thread.CurrentThread;
            Console.WriteLine($"Foo : {t.ManagedThreadId}");

            // 3. Thread 우선 순위
            Console.WriteLine($"Foo Priority : {t.Priority}");

            // 4. 현재 쓰레드가 쓰레드 풀에 있는 것인지 확인
            Console.WriteLine($"Foo IsThreadPoolThread : {t.IsThreadPoolThread}");

            // 5. 현재 쓰레드가 살아있는지
            Console.WriteLine($"Foo IsAlive : {t.IsAlive}");

            Console.WriteLine("Foo Start");
            Thread.Sleep(5000);
            Console.WriteLine("Foo End");
        }

        public static void Main(string[] args)
        {
            Thread t1 = new Thread(Foo);
            t1.Start();

            // 1. thread id
            Console.WriteLine($"{t1.ManagedThreadId}");
            // 2. Thread 우선 순위
            Console.WriteLine($"{t1.Priority}");
            // 3. 현재 쓰레드가 쓰레드 풀에 있는 것인지 아닌지
            Console.WriteLine($"{t1.IsThreadPoolThread}");
            // 4. 현재 쓰레드가 살아있는지
            Console.WriteLine($"{t1.IsAlive}");

            // 5. Foreground Thread: 주 스레드가 종료되어도 나머지 쓰레드는 계속 작업을 수행한다.
            //    Background Thread: 주 스레드가 종료되면 나머지 스레드는 강제로 종료된다.
            t1.IsBackground = true;
            t1.Join(); // 자식 쓰레드의 종료를 대기한다.
        }
    }
}
