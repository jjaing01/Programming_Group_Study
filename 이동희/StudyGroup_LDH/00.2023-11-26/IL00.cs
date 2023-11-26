using System;

/*
 1. IL 이란?
자바나 C#은 컴파일 되었을 때, CPU와 OS에 독립적인 기계어 코드가 만들어지고 이것을 '중간 언어(Intermediate Language, IL)' 이라고 함

이것은 CPU가 바로 해석할 수 있는게 아니라 가상 머신이 IL을 가져다가 다양한 환경 (윈도우, 리눅스,맥 등)에서 실행해준다.
(C++ 같은 경우에도 일반 C++ 컴파일러가 아닌 .net C++ 컴파일러를 사용하면 해당 IL 코드를 만들 수 있다)

이 때, 해당 가상머신의 이름을 CLR (Common Language Runtime)이라고 한다.
*/

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
        Point pt1; // 객체
        pt1.x = 2;
        Point pt2 = new Point(); // 객체, 모든 멤버가 초기화

        Console.WriteLine($"{pt1.x}");
    }
}
