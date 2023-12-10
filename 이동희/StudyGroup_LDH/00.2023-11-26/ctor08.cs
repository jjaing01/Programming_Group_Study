using System;

class CPoint
{
    public int x;
    public int y;
    public int cnt;

    public CPoint(int a, int b)
    {
        x = a;
        y = b;
    }
}

struct SPoint
{
    public int x;
    public int y;
    public int cnt;

    public SPoint(int a, int b)
    {
        x = a;
        y = b;
    }
}

class Program
{
    public static void Main()
    {
        CPoint pt = new CPoint(1, 2);
        SPoint pt1 = new SPoint(1, 2);

    }
}