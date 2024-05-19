using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyGroup_PYH._2024_03
{
    internal class MyTask
    {
        public static void Foo()
        {
            Console.WriteLine($"Foo Thread Id : {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
        }

        public static void Foo(string str)
        {
            Console.WriteLine($"Foo Thread Id : {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
        }

        public static void main()
        {
            Thread t = new Thread(Foo);
            t.Start();

            // 1. Task 생성
            Task tak1 = Task.Run(Foo);

            Task tak2 = Task.Run(() => Foo("task Instance"));

            // 2. Thread vs Task
            // - Thread Instance는 무조건 스레드를 생성한다.
            // - Task Instance는 시스템이 스레드풀을 만들어서 최적의 코드를 작성해준다.


        }
    }
}
