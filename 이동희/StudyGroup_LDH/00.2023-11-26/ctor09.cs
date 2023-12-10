using System;

class CPoint
{
    public int x;
    public int y;

    public CPoint(int a = 1, int b = 1)
    {
        Console.WriteLine($"CPoint: {a}, {b}");
        x = a;
        y = b;
    }
}

struct SPoint
{
    public int x;
    public int y;

    public SPoint(int a = 1, int b = 1)
    {
        Console.WriteLine($"SPoint: {a}, {b}");
        x = a;
        y = b;
    }
}

class Program
{
    public static void Main()
    {
        CPoint cp1 = new CPoint(5, 5); // 5,5 --> newobj
        SPoint sp1 = new SPoint(5, 5); // 5,5 --> call 생성자
        CPoint cp2 = new CPoint(2); // 2,1 --> newobj
        SPoint sp2 = new SPoint(2); // 2,1 --> call 생성자

        CPoint cp3 = new CPoint(); // 1,1 --> newobj
        SPoint sp3 = new SPoint(); // 0,0 initobj 
        Console.WriteLine($"SPoint: {sp3.x}, {sp3.y}");


        // 값 타입은 인자 없는 생성자를 가질 수 없다.
        // 그래서 C# 컴파일러는 값 타입에 인자 없는 생성자가 없으니깐 생성자를 부를 필요가 없어.
        // initobj 통해서 메모리잡고 0으로 초기화해야겠어.
    }
}