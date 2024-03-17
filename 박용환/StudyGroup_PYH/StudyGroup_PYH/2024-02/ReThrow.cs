using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._2024_02
{
    class Server
    {
        public void Connect()
        {
            throw new TimeoutException();
        }
    }

    internal class ReThrow
    {
        static void Foo()
        {
            Server server = new Server();

            try
            {
                server.Connect();
            }
            catch (TimeoutException e)
            {
                // Main으로 던지자
                throw e; // 예외의 근원을 이쪽으로 본다
                //throw; // 실제 예외의 근원 위치를 찍어준다.
            }

            catch (WebException e) when (e.Status == WebExceptionStatus.NameResolutionFailure)
            {

            }
        }

        public static void Main()
        {
            try
            {
                Foo();
            }
            catch(System.Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}


// 메모 
// redis 대기열 hard, soft 구분?