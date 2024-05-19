using System;
using System.Net;

namespace _240303_study
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
                // Main으로 던지자.
                //throw e;    // 예외의 근원을 이쪽으로 본다.
                throw;    // 일반적이고 좋은 표기. 실제 예외의 근원을 찾음. 
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
            catch (Exception e)
            {
                // 결국 최초로 호출한 쪽에서 예외를 잡아야 근원을 찾을 수 있음.
                Console.WriteLine(e.ToString());
            }
        }
    }
}
