using System;

struct Point
{
    public int x;
    public int y;
}

class Program
{
    public static void Main(string[] args)
    {
        // 아래 2개의 코드의 차이점을 IL 코드로 알아보자.
        Point pt1;
        Point pt2 = new Point();

        Console.WriteLine($"{pt2.x}");
    }
}
