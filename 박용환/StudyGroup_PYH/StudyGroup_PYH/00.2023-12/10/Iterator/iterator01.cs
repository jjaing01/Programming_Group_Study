using System;
using System.Collections.Generic;

/*
        시퀀스의 끝까지 순회하지 않은 경우에 이터레이터에 대해 Dispose를 호출하지 않으면, 리소스가 누수되거나
        최소한 리소스 정리에 지연이 발생한다.

        제네릭이 아닌 IEnumerator 인터페이스는 IDisposable을 확장하지 않는다. 하지만 foreach 루프는 런타임에
        IDisposable 인터페이스의 구현 여부를 확인하여 Dispose를 호출한다. 제네릭 타입인 IEnumerator<T> 인터페이스는
        IDisposable을 확장하므로 좀 더 단순하다.
        
        이터레이터를 이용하여 시퀀스에 대한 순회를 진행할 때 직접적으로 MoveNext() 를 호출해야 하는 경우라면,
        Dispose 호출 작업 또한 직접 처리해 주어야 한다. 제네릭이라면 using문을 사용하면 되지만, 다른 시퀀스를 함께
        다루어야 한다면 컴파일러가 foreach 구문을 만났을 때 그랬던 것처럼, 런타임에 IDisposable 인터페이스의 
        구현 여부를 확인한 후 Dispose 호출 작업을 직접 처리해 주어야 한다.
 */
class iterator01
{
    static void Main()
    {
        IEnumerable<int> enumerable = CreateSimpleIterator(5);

        // IEnumerable<T> 를 이용하여 IEnumerator<T>를 가져온다.
        // Dispose 메서드는 using 문을 통해 자동으로 호출
        using (IEnumerator<int> enumerator = enumerable.GetEnumerator())
        {
            // 값이 있다면 다음 위치로 이동
            while (enumerator.MoveNext())
            {
                int value = enumerator.Current;
                Console.WriteLine(value);
            }
        }
    }

    private static IEnumerable<int> CreateSimpleIterator(int count)
    {
        for (int i = 0; i < count; ++i)
        {
            yield return i;
        }     
    }

    // MoveNext() 메서드의 간략화 버전
    //public bool MoveNext()
    //{
    //    try
    //    {
    //        switch (state)
    //        {
    //            // 메서드 내에서 올바른 위치로 점프하기 위한 점프 테이블
    //        }
    //        // yield return  으로 값을 반환하기 위한 코드
    //    }
    //    fault // 예외 발생 시 수행할 코드
    //    {
    //        DisPose(); // 예외 발생 시 정리를 위한 코드
    //    }
    //}
}