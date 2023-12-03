using System;

// 객체로 만들 수 없다.
public abstract class AAA { } // 기반 클래스 됨 기본생성자 protected
public static class BBB { } // 생성자 x

public class Point
{
    public int x;
    public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}


class Program
{
    static void Main()
    {
        Point pt = new Point(1, 2);
        Console.WriteLine($"{pt.x}, {pt.y}");
    }
}

