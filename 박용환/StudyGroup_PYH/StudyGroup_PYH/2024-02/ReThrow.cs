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
                // throw e; -> 근원지인 connect() 가 아니라 현재 라인의 익셉션이라고 본다. -> 이렇게 사용 x
                // throw; -> 근원지인 connect() 콜스택까지 알려준다
                // 정리 : 중간에 throw를 잡지 말자 넘길때마다 콜스택 하나씩 증가하므로 근원지 찾기가 수월하다.

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
                // 최초로 호출한 쪽에서 예외를 잡아야 근원을 찾을 수 있음
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}


// 메모 
// redis 대기열 hard, soft 구분?