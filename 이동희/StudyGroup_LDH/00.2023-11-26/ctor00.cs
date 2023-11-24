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
        // 0이 나올 것이다. 
        // 참조 타입의 객체를 생성하면 기본적으로 메모리를 잡고 0으로 초기화한다. 그 후 생성자가 호출된다. 
        Console.WriteLine("Point Constructor");
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