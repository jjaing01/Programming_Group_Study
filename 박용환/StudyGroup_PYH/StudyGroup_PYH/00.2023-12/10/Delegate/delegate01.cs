using System;

/*
 * 클로저(Closure)
    함수가 선언될 때의 스코프을 기억하고, 나중에 실행될 때에도 그 환경에 접근할 수 있도록 하는 개념이다.
    C#에서는 람다 표현식을 통해 클로저를 만들 수 있다.
*/

class delegate01
{
    static void Main()
    {
        int externalValue = 5;

        Action<int> closureMethod = x =>
        {
            int result = x + externalValue;
            Console.WriteLine($"Result: {result}");
        };

        PerformOperation(10, closureMethod);
    }

    static void PerformOperation(int x, Action<int> callback)
    {
        callback(x);
    }

}