using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._2024_02
{
    class Exception
    {
        public static class FileManager
        {
           // 파일 복사, 파일 크기 반환 함수
           public static int CopyFile_1(string srcFileName, string dstFileName)
           {
                // if(FAIL)....
                throw new System.Exception("파일 접근 권한 없음");

                return 100;
           }

           // 방법1
           // 반환 값을 통한 성공/실패 처리
           public static int CopyFile_2(string srcFileName, string dstFileName)
           {
                return -1;
           }

           // 방법2
           // Out Param을 통한 반환갑소가 오류 전달을 분리한다.
           // TryAdd, TryGetValue ....
           public static bool CopyFile_3(string srcFileName, string dstFileName, out int len)
           {
                len = 100;
                return false;
           }
        }

        public static void Main()
        {
            Dictionary<int, int> dict = new();
            dict.TryAdd(1, 1);
            dict.TryGetValue(1, out var value);

            try
            {
                FileManager.CopyFile_1("C:\\a.txt", "D:\\b.txt");
            }
            

            catch (System.ArgumentNullException e)
            {

            }

            catch (System.ArgumentException e)
            {

            }
            catch (System.Exception e) 
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            // 2. Finally
            // - try 블록을 벗어날 때 항상 실행한다.
            // - try 블록에서 return 하더라도 finally는 꼭 호출된다.

            // 2. Finally

            // 2-1. Finally 사용한 자원 관리
            // C#에서는 일반적인 객체들은 Garbage Collector에 의해 자동으로 수집된다.
            // 그래서 명시적으로 자원을 해지할 필요가 없다.
            // 그런데.. 파일, 네트워크, 이벤트 등의 자원을 관리하는 객체는 Dispose() 메소드를 호출해서 명시적으로 자원을 해제
            finally
            {
                Console.WriteLine("프로그램 계속 실행");
            }
        }

        // 1. System.Exception
        // - 모든 예외 클래스의 기반 클래스이다

        // 1-1 주요 멤버
        // (1) Message : 예외를 설명하는 문자열
        // (2) StackTrace : 예외의 근원지부터 catch 블록에 도달할 때까지의 

    }
}


// 메모 
// redis 대기열 hard, soft 구분?