using System;

class CPoint
{
    public int x;
    public int y;

    public CPoint(int a = 1, int b = 1)
    {
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
        x = a;
        y = b;
    }
}

class Program
{
    public static void Main()
    {
        CPoint cp1 = new CPoint(5, 5);
        SPoint sp1 = new SPoint(5, 5);
        CPoint cp2 = new CPoint(2);
        SPoint sp2 = new SPoint(2);
        CPoint cp3 = new CPoint();
        SPoint sp3 = new SPoint();
    }
}