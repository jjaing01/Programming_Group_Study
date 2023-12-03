using System;

/* 
 * 
 */


class CNullable01
{
    static void Main()
    {
        Nullable<int> noValue = new Nullable<int>();
        Console.WriteLine(noValue == null);

        Nullable<int> someValue = new Nullable<int>(5);
        Console.WriteLine(someValue!.GetType()); // 생성 시 무조건 값이 있다라고 하면 ! 키워드 사용

        Nullable<int> noValue2 = new Nullable<int>();
        Console.WriteLine(noValue2?.GetType()); // nullable은 항상 ? 를 사용한다.

        Nullable<int> someValue2 = new Nullable<int>(5);
        Console.WriteLine(someValue2 == null);
    }
}