using System;

class CPoint
{
    public int x;
    public int y;
}

struct SPoint
{
    public int x;
    public int y;
}

class Program
{
    static void Main()
    {
        CPoint cp1; // 참조 변수
        CPoint cp2 = new CPoint(); // 객체 생성
        SPoint sp1; // 객체 (스택에 메모리만 잡아둔것, 초기화 X)
        SPoint sp2 = new SPoint(); // 객체 생성 (initobj)

        ////sp1.x = 10;
        ////sp2.x = 10;

        Console.WriteLine($"{sp1.x}");
        Console.WriteLine($"{sp2.x}");
    }
}