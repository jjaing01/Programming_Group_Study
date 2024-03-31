using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LYS
{
    class Exception
    {

        public static void Main()
        {
            try
            {

            }
            catch (System.ArgumentNullException e)
            {

            }
            catch (System.ArgumentException e)
            {

            }
            catch(System.Exception e)
            {

            }
            finally 
            {
                // - 의미
                // try 블록을 벗어날 때 항상 실행한다.
                // 
                // - Finally를 이용한 자원관리
                // 메모리를 해제하지 않아도 가비지컬렉터가 알아서 다해준다.
                // 하지만 파일 네트워크와 같은 외부 리소스는 GC가 직접 핸들링할 수 없다.
                // 그래서 자원을 관리하는 객체는 Dispose() 메소드를 호출해서 명시적으로 자원을 해제해야한다.
                // 가비지 컬렉터가 처리를 안해준다.
            }
        }
    }
}
