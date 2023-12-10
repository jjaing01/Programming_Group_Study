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
    // Q.값 타입은 이렇게 만들면, 메모리만 존재하고 초기화가 안된다고 했는데 왜 멤버로 들어가면 초기화가 될까?
    // A. SPoint를 가지고 있는 SCircle을 만들 때, new를 통해서 모든 멤버를 초기화하기 때문이다.

    // 즉, 값 타입은 객체를 생성한다고 메모리가 초기화 되는 것은 아니다. new를 통해 메모리를 초기화한다.
    // 참조 타입은 new를 하지 않으면 객체가 아니고 참조 변수일 뿐이다.
    public SPoint center;
}

class Program
{
    public static void Main()
    {
        CCircle cc1; // 참조 변수(객체 아님)
        CCircle cc2 = new CCircle(); // 객체 (newobj)

        SCircle sc1; // 객체, 스택에 메모리만 잡혀있고 초기화X
        SCircle sc2 = new SCircle(); // 객체, 메모리 존재하고 초기화O

        int n1 = cc1.center.x;
        int n2 = cc2.center.x;
        int n3 = sc1.center.x;
        int n4 = sc2.center.x;
    }
}