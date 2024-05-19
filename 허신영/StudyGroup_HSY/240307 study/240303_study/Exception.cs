using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _240303_study
{
    class Exception
    {
        public static class FileManager
        {
            // 방법1
            // 반환 값을 통한 성공/실패 처리 및 결과 값.

            public static int CopyFile_1(string srcFileName, string dstFileName)
            {
                return -1;
            }

            // 방법2
            // out Param을 통한 반환값과 오류 전달을 분리.
            // TryAdd, TryGetValue .... 
            public static bool CopyFile_2(string srcFileName, string dstFileName, out int len)
            {
                len = 100;
                return false;
            }

            // 파일을 복사하고 파일 크기 반환 함수.
            public static int CopyFile(string srcFileName, string dstFileName)
            {
                // if (FAIL).....
                throw new System.Exception("파일 접근 권한 없음.");

                return 0;
            }
        }

        public static void Main()
        {
            try
            {
                Console.WriteLine("기존 파일 카피");
                FileManager.CopyFile("C:\\a.txt", "D:\\b.txt");

                Console.WriteLine("기존 파일 삭제");
                Console.WriteLine("기존 파일 생성");
            }
            // 각 예외에 대한 처리를 하고자 하는 경우를 구분할 수 있음.
            catch (System.ArgumentNullException e)
            {

            }
            catch (System.ArgumentException e)
            {

            }
            // 모든 예외를 한번에 처리하고 싶은 경우 -> 각 예외 catch를 처리할 경우에는 해당 catch를 가장 마지막에 추가해야 함.
            catch (System.Exception e) 
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ToString());
            }

            // 2. Finally
            // - try 블록을 벗어날 때 항상 실행한다.
            // - try 블록에서 return 하더라도 finally는 꼭 호출된다.
            // 2-1 Finally 사용한 자원 관리.
            // C#에서는 일반적인 객체들은 Garbage Collector에 의해 자동으로 수집된다.
            // 그래서 명시적으로 자원을 해지할 필요가 없다.
            // 그런데... 파일, 네트워크 등의 자원을 관리하는 객체는 Dispose() 메소드를 호출해서 명시적으로 자원을 해제해야 한다.
            // 이들은 외부 리소스이기 때문에 GC가 직접 핸들링 불가능.
            finally
            {
                Console.WriteLine("프로그램 계속 진행");
            }


            // 1. System.Exception
            // - 모든 예외 클래스의 기반 글래스이다.

            // 1-1. 주요 멤버
            // (1) Message : 예외를 설명하는 문자열.
            // (2) StackTrace : 예외의 근원지부터 catch 블록에 도달할 때까지의 모든 메소드에 대한 정보.

        }
    }
}
