using System;

/*
 * 델리게이트 간의 호환성
    델리게이트가 참조하는 메서드의 시그니처가 일치하는 경우에 발생한다.
    호환성은 매개변수의 개수와 타입, 반환 형식이 동일한 경우에 성립한다.
*/

// 델리게이트 정의
delegate void voidDelegate(int x, int y);
delegate int intDelegate(int x, int y);
class delegate02
{
    static void Main()
    {
        // 호환되는 델리게이트 인스턴스 생성
        voidDelegate addDelegate = Add;
        voidDelegate subDelegate = Sub;

        // 델리게이트 호출
        addDelegate(1, 2);
        subDelegate(1, 2);

        // 람다 표현식을 이용한 델리게이트 인스턴스 생성
        voidDelegate multiplyDelegate = (a, b) => Console.WriteLine($"result: {a + b}"); 

        // 델리게이트 호출
        multiplyDelegate(1, 2);
    }
    static void Add(int a, int b)
    {
        Console.WriteLine($"Sum: {a + b}");
    }

    static void Sub(int a, int b)
    {
        Console.WriteLine($"Difference: {a - b}");
    }

    //static void Main()
    //{
    //    // 반환 형식이 같은 메서드를 참조하는 델리게이트 인스턴스 생성
    //    intDelegate addDelegate = Add;

    //    // 델리게이트 호출
    //    int result = addDelegate(5, 3);
    //    Console.WriteLine($"Result: {result}");
    //}

    //static int Add(int a, int b)
    //{
    //    return a + b;
    //}
}