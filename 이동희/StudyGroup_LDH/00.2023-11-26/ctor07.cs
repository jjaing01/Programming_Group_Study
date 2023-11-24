using System;

struct SPoint
{
    public int x;
    public int y;
}

class CCircle
{
    public SPoint center;
}

struct SCircle
{
    public SPoint center;
}

class Program
{
    public static void Main()
    {
        CCircle cc1;
        CCircle cc2 = new CCircle();

        SCircle sc1;
        SCircle sc2 = new SCircle();

        int n1 = cc1.center.x;
        int n2 = cc2.center.x;
        int n3 = sc1.center.x;
        int n4 = sc2.center.x;
    }
}