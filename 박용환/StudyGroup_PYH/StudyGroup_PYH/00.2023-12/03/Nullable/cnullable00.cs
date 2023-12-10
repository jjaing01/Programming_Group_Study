using System;

/* 
    * Nullable<T>란?

        C#에서 값 형식에 null을 할당할 수 있도록 하는 제네릭 구조체
        일반적으로 값 형식은 null 값을 가질 수 없지만, Nullable<T>를 사용하면 값 형식 변수에 null을 할당하여 "nullable" 상태로 만들 수 있음

        이전에는 값이 없음을 나타내는 값을 사전에 정하거나 해당 필드 값이 유효한지에 대해 bool 변수
        해당 값에 유효성 검사가 우선되어야 하기에 오류를 범하기 쉽고 반복적인 코드 사용
 
 */

class CNullableExample
{
    public int? nullableint { set; get; }
    public int notnullableint { set; get; }
}

class CNullable00
{
    static void Main()
    {
        // 초기화
        CNullableExample cne1 = new CNullableExample
        {
            nullableint = null,
            notnullableint = 1
        };

        // null체크
        if (cne1.nullableint is not null) // hasvalue, is not null 둘 다 표현은 가능하지만 가독성은 is not null,
        {
            Console.WriteLine($"Value: {cne1.nullableint.Value}");
        }
        else
        {
            Console.WriteLine("The variable is null.");
        }

        // 리프팅
        // int? a;
        // int? b = null;
        // int c = cne1.nullableint ?? cne1.notnullableint; // x1값이 null이면 x2 반환
        // int d = cne1.nullableint ?? b ?? cne1.notnullableint; // ?? 연산자는 중복이 가능하며 x1, b모두 null 경우에 x2를 평가한다.
        // int e = cne1.nullableint ?? cne1.notnullableint ?? b; // 에러
    }
}