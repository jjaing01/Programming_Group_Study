using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LYS
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
                //throw e;   // 예외의 근원을 이 쪽으로 본다
                throw;       // 일반적이고 좋은 표기, 실제 예외의 근원을 찾음
            }
            catch (WebException e) when (e.Status == WebExceptionStatus.NameResolutionFailure)
            {
                // 참이라면 이쪽으로 캐치한다.
            }
        }
        public static void Main()
        {
            try
            {
                Foo();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
