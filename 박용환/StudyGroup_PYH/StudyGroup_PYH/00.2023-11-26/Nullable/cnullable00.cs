using System;
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
        if (cne1.nullableint.HasValue)
        {
            Console.WriteLine($"Value: {cne1.nullableint.Value}");
        }
        else
        {
            Console.WriteLine("The variable is null.");
        }

        // 리프팅
        int a = cne1.nullableint ?? cne1.notnullableint; // x1값이 null이면 x2 반환

        int? b = null;
        int c = cne1.nullableint ?? b ?? cne1.notnullableint; // ?? 연산자는 중복이 가능하며 x1, b모두 null 경우에 x2를 평가한다.
        //int d = cne1.nullableint ?? cne1.notnullableint ?? b; // 에러

        Console.WriteLine($"Value: {a}"); // 1
        Console.WriteLine($"Value: {b}");
        Console.WriteLine($"Value: {c}"); // 1
        //Console.WriteLine($"Value: {d}"); // 1
    }
}