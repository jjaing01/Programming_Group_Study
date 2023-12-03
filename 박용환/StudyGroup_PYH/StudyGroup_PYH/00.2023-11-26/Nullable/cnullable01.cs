using System;

/* 
 * Nullable<T>란?

    C#에서 값 형식에 null을 할당할 수 있도록 하는 제네릭 구조체
    일반적으로 값 형식은 null 값을 가질 수 없지만, Nullable<T>를 사용하면 값 형식 변수에 null을 할당하여 "nullable" 상태로 만들 수 있음
 */


class CNullable01
{
    static void Main()
    {
        Nullable<int> noValue = new Nullable<int>();
        Console.WriteLine(noValue == null);

        Nullable<int> someValue = new Nullable<int>(5);
        Console.WriteLine(someValue == null);

        Nullable<int> noValue2 = new Nullable<int>();
        Console.WriteLine(noValue2.GetType());

        Nullable<int> someValue2 = new Nullable<int>(5);
        Console.WriteLine(someValue2 == null);
    }
}