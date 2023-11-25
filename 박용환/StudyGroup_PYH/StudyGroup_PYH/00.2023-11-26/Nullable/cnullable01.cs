using System;

class CNullable01
{
    static void Main()
    {
        // 책 예제
        Nullable<int> noValue = new Nullable<int>();
        object noValueboxed = noValue; // HasValue가 false인 객체를 박싱
        Console.WriteLine(noValueboxed == null); // true를 출력 : 박싱의 결과는 null 참조

        Nullable<int> someValue = new Nullable<int>(5);
        object someValueboxed = someValue; // HasValue가 true 객체를 박싱
        Console.WriteLine(someValueboxed == null); // System.Init32를 출력 : 박싱의 결과는 박싱된 int

        Nullable<int> noValue2 = new Nullable<int>();
        //Console.WriteLine(noValue2.GetType()); // nullreferenceexception 

        Nullable<int> someValue2 = new Nullable<int>(5);
        Console.WriteLine(someValue2 == null); // System.Init32를 출력. typeof(int) 결과와 동일

        // GPT 예제
        int? nullableInt = 1;
        object boxedValue = nullableInt; // boxing

        object boxedNull = (int?)null; // no boxing
        int? unboxedValue = (int?)boxedValue;

        Console.WriteLine($"Original Nullable: {nullableInt}"); // Original Nullable: 1
        Console.WriteLine($"Boxed Value: {boxedValue}"); // Boxed Value: 1
        Console.WriteLine($"Boxed Null: {boxedNull}"); // Boxed Null
        Console.WriteLine($"Unboxed Value: {unboxedValue}"); // Unboxed Value: 1
    }
}