using System;

public abstract class AAA { }
public static class BBB { }

public class Point
{
    public int x;
    public int y;

    public Point (int x, int y)
    {
        // 1.이 부분이 주석일 경우, 쓰레기 값이 나올 것인지 0이 나올 것인지?
        Console.WriteLine("Point Constructor");
        this.x = x;
        this.y = y;
    }
}

class Program
{
    static void Main()
    {
        Point pt = new Point(); // 참조 타입은 객체를 생성하는 순간 메모리를 초기화한다.
        Console.WriteLine($"{pt.x}, {pt.y}");
    }
}