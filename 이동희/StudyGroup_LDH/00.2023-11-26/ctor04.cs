using System;

class CPoint
{
    public int x;
    public int y;

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
   
    public SPoint(int a, int b)
    {
        x = a;
        y = b;
    }
}

class Program
{
    static void Main()
    {
        CPoint cp1 = new CPoint(1, 2);
        ////CPoint cp2 = new CPoint(); // error
        SPoint sp1 = new SPoint(1, 2);
        SPoint sp2 = new SPoint(); // ok
        SPoint sp3 = default;
    }
}

/*
 (1) Reference Type
- 사용자가 생성자를 구현하지 않은 경우, 컴파일러가 인자 없는 생성자를 제공한다.
- 사용자가 생성자를 구현하면, 컴파일러는 인자 없는 생성자를 제공하지 않는다.

(2) Value Type
- 사용자가 인자 없는 생성자를 만들 수 없다.
- 컴파일러가 인자 없는 생성자를 제공하지 않는다.
-- 값 타입의 객체는 언제라도 생성할 수 있도록 (생성자가 없어도) 허용한다. - CLR 규칙

(3) 정리
- 참조 타입
-- 객체를 만드려면 반드시 생성자가 필요함
-- 사용자는 인자 없는 생성자와 인자를 가지는 생성자 모두 만들 수 있음

- 값 타입
-- 생성자가 없어도 객체를 만들 수 있다
-- 사용자는 인자를 가지는 생성자만 만들 수 있다 (C#만의 제약)
 */