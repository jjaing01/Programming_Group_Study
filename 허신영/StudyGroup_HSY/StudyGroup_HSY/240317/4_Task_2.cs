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
        public static void F1()
        {
            Console.WriteLine("F1 Start");
            Thread.Sleep(1000);
            Console.WriteLine("F1 End");
        }
        public static void F2(object obj) 
        {
            Console.WriteLine("F2 Start");
            Thread.Sleep(3000);
            Console.WriteLine("F2 End");
        }
        public static int F3(string str) 
        {
            Console.WriteLine("F3 Start");
            Thread.Sleep(1000);
            Console.WriteLine("F3 End");

            return 100;
        }
        public static void F4(string s1, int n) 
        {
            Console.WriteLine("F4 Start");
            Thread.Sleep(1000);
            Console.WriteLine("F4 End");
        }

        public static void Main(string[] args)
        {
            // 1. Task는 기본적으로 Background = true. (주 쓰레드가 종료되면 나머지 쓰레드는 강제로 종료됨.)
            Task t = Task.Run(F1);

            // 2. 종료 대기가 필요한 경우 Wait() 을 사용.
            t.Wait();

            // 3. 인자가 있는 경우
            Task t1 = Task.Run(() => F2("Hello"));

            // 4. Task가 끝났는지 여부.
            Console.WriteLine(t.IsCompleted);

            // 5. Task 반환 값 받기.
            // Task<T>
            // Result : 값을 반환 받을 때까지 대기를 하게 된다.
            Task<int> t2 = Task.Run(() => F3("hello"));
            Console.WriteLine(t2.Result);
        }
    }
}
