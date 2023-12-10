using System;

struct SPoint
{
    public int x = 0;
    public int y = 0;
}

class Program
{
    static void Main()
    {
        SPoint sp1 = new SPoint();
    }
}


/*
 struct SPoint : Base
{
    public int x; 
    public int y; 

    public SPoint()
    {
        a = 100;
        b = 100;
        Base(); // 기반 클래스가 존재한다면 이 순서로 생성자를 호출
    }
}

== 값 타입은 인자 없는 생성자를 만들 수가 없다.
그래서 값 타입은 필드 초기화를 시킬 수 없다.
 */