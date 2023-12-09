using System;
using System.Collections.Generic;

/*
 * iterator
    이터레이터 블록을 포함하는 메서드나 속성을 말하며, 이터레이터 블록은 yield return이나 yield break 문을 사용하는 코드 블록을 말한다.
    IEnumerable, IEnumerable<T>, IEnumerator, IEnumerator<T> 반환 타입으로 하는 메서드나 속성을 구현할 때만 사용할 수 있다.
 */
class iterator00
{
    static void Main()
    {
        // iterator 메서드 호출
        foreach (var number in GetNumbers(5))
        {
            Console.WriteLine(number);
        }

        foreach (int value in CreateSimpleIterator())
        {
            Console.WriteLine(value);
        }
    }

    // iterator 메서드
    static IEnumerable<int> GetNumbers(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // yield를 사용하여 값을 호출자에게 반환, 지연 수행
            yield return Multiply(i);
        }
    }
    static int Multiply(int x)
    {
        Console.WriteLine($"Multiply of {x}");
        return x * x;
    }

    static IEnumerable<int> CreateSimpleIterator()
    {
        yield return 10;
        for (int i = 0; i< 3; ++i)
        {
            yield return i;
        }
        yield return 20;
    }
}