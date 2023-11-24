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
        CPoint cp1;
        CPoint cp2 = new CPoint(); 
        SPoint sp1;
        SPoint sp2 = new SPoint();

        sp1.x = 10;
        sp2.x = 10;

        Console.WriteLine($"{sp1.x}");
        Console.WriteLine($"{sp2.x}");
    }
}