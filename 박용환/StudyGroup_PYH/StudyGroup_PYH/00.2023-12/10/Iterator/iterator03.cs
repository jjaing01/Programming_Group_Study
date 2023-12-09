using System;
using System.Collections.Generic;

/*
 * 최적화
    MoveNext()를 반복하여 호출하는 동안 그 값을 계속 유지해야 할 때는 항상 필드에 저장된다.
 */
class iterator03
{
    static void Main()
    {

    }

    public static IEnumerable<int> GenerateIntegers(int count)
    {
        try
        {
            for (int i = 0; i< count; ++i)
            {
                Console.WriteLine("Yielding {0}", i);
                yield return i;

                // doubled는 코드 내에서 초기화되고, 그 값을 출력한 뒤 반환된다.
                // 메서드를 벗어나면 이 값은 더 이상 유지될 필요가 없으므로 컴파일러에 의해 최적화 대상이 되며,
                // 릴리스 빌드에서는 이 값을 필드에 저장하지 않는다. 디버깅에서는 저장.
                //
                int doubled = i * 2;
                Console.WriteLine("Yielding {0}", doubled);
                yield return doubled;

                // 두줄이 바뀐다면 이야기가 달라진다. 필드에 저장한다. (최적화 대상이 되지 않는다.)
                // yield return doubled를 수행하고 값을 출력하기 때문이다.
                // yield return doubled;
                // Console.WriteLine("Yielding {0}", doubled);
            }
        }
        finally
        {
            Console.WriteLine("In finally block");
        }
    }
}