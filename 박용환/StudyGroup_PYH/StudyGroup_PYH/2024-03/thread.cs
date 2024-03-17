using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyGroup_PYH._2024_03
{
    internal class Program
    {
        public static void Foo()
        {
            // Thread Id
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"Foo : ({currentThread.ManagedThreadId}))");

            // 3. Thread 우선순위
            Console.WriteLine($"priority : {currentThread.Priority}");

            // 4. 현재 스레드가 풀에 들어가 있는지 확인
            Console.WriteLine($"isthreadfool :  {currentThread.IsThreadPoolThread}");

            // 5. 현재 스레드가 살아있는지
            Console.WriteLine($"isalive : {currentThread.IsAlive}");

            Console.WriteLine("Foo Start");
            Thread.Sleep(1000);
            Console.WriteLine("Foo End");
        }

        public static void F1() { }
        public static void F2(object obj) { }
        public static void F3(string str) { }
        public static void Main()
        {
            // 1. Thread 생성
            // - Thread 객체 생성
            // - Thread Start() 호출하여 시작
            Thread thread = new Thread(Foo);
            thread.Start();

            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"Main : {currentThread.ManagedThreadId})");

            // 3. Thread 우선순위
            Console.WriteLine($"priority : {currentThread.Priority}");

            // 4. 현재 스레드가 풀에 들어가 있는지 확인
            Console.WriteLine($"isthread :  {currentThread.IsThreadPoolThread}");

            // 5. 현재 스레드가 살아있는지
            Console.WriteLine($"isalive : {currentThread.IsAlive}");

            Console.WriteLine("Main Start");
            Thread.Sleep(1000);
            Console.WriteLine("Main End");

            // 2-1. Thread 생성자 호출
            // (1) 인자 없는 스레드
            Thread t1 = new Thread(F1);
            t1.Start();

            // 2-2 object 있는 스레드
            Thread t2 = new Thread(F2);
            t2.Start("hello f2");

            // (3) object type이 아닌 진짜 스레드
            // - 내부 delegate는 object 파라미터만 받을 수 있다.
            Thread t3 = new Thread(F3); // error -> object 타입만 가능하다.
            t3.Start("hello f3");

            // 3-1 위 문제 해결 방법
            // - 새로운 스레드를 만들면서 람다 표현식을 수행한다.
            // - () => 인자가 없다는 의미이므로 인자 없는 쓰레드 delegate로 간주한다.
            Thread t4 = new Thread(() => F3("hello f3"));
            t4.Start();

            // 5. Foreground Thread = 주 스레드가 종료되어도 나머지 쓰레드는 곟속 작업을 수행한다.
            currentThread.IsBackground = true;
        }
    }
}
