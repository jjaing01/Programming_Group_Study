using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyGroup_HSY._240317
{
    internal class Program
    {
        public static void Foo(object obj)
        {
            Console.WriteLine($"{(string)obj} - Foo : {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
        }

        public static void Main(string[] args )
        {
            Thread t = new Thread(Foo);
            t.Start();

            // 1. Task 생성.
            Task task1 = Task.Run(() => Foo("task Instance"));

            // Thread vs Task
            // - Thread Instance는 무조건 쓰레드를 생성한다.
            // - Task Instance는 시스템이 쓰레드 풀을 만들어서 최적의 코드를 작성해준다.

            for(int i = 0; i < 20;  i++)
            {
                Task t3 = Task.Run(() => Foo("for loop task Instance"));
            }
            Console.ReadKey(true); // 메인 쓰레드 종료되지 않도록 대개.
        }
    }
}
