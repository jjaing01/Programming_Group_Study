using System;

/* 
    * nullable 표현을 '?' 으로 할 수 있다.
     
    * 박싱이란?

        1. 박싱은 값 형식(구조체)의 인스턴스를 참조 형식(클래스)의 객체로 변환하는 과정
        2. 값을 힙(heap)에 저장된 참조 형식으로 감싸는 것을 의미
        3. 박싱이 발생하면 값을 복사하는 것이 아니라 값 형식이 힙에 새로운 객체로 복사되고, 그 객체에 대한 참조가 반환

    * 언박싱이란?

        1. 언박싱은 박싱된 객체를 다시 값 형식으로 변환하는 과정
        2. 힙에 저장된 값을 스택으로 복사하는 것을 의미
        3. 명시적인 형변환(캐스트)이 필요
        4. 언박싱이 실패하면 InvalidCastException이 발생
 */


class cBoxing
{
    static void Main()
    {
        // GPT 예제
        int? simplenullableInt = null;
        Nullable<int> nullableInt = 1;
        object boxedValue = nullableInt; // boxing

        object boxedNull = (int?)null;
        int? unboxedValue = (int?)boxedValue; // unboxing

        Console.WriteLine($"Original simplenullableInt: {simplenullableInt}");
        Console.WriteLine($"Original nullableInt: {nullableInt}"); 
        Console.WriteLine($"Boxed Value: {simplenullableInt}");
        Console.WriteLine($"Boxed Value: {boxedValue}");
        Console.WriteLine($"Boxed Null: {boxedNull == null}"); 
        Console.WriteLine($"Boxed Null: {boxedNull}");
        Console.WriteLine($"Unboxed Value: {unboxedValue}");
    }
}