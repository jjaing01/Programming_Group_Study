using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    internal class Program
    {
        public static void Foo(object obj)
        {
            Console.WriteLine($"{(string)obj} - Foo Thread Id : {Thread.CurrentThread.ManagedThreadId}");
            //Thread.Sleep(2000);
        }

        public static void Main(string[] args) 
        { 
            Thread t = new Thread(Foo);
            t.Start("thread Instance");

            // 1. Task 생성
            Task task1 = Task.Run(() => Foo("task Instance"));

            // 2. Thread vs Task
            // - Thread Instance는 무조건 스레드를 생성한다.
            // - Task Instance는 시스템이 스레드풀을 만들어서 최적의 코드를 작성해준다.

            for (int i = 0; i < 20; ++i)
            {
                Task t3 = Task.Run(() => Foo("for roop task Instance"));
            }

            Console.ReadKey(true);
        }
    }
}
