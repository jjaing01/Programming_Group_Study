using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Base
{
    public Base() { Foo(); }
    public virtual void Foo() { Console.WriteLine("Base.Foo"); }
    public virtual void Goo(int n = 10) { Console.WriteLine($"Base.Goo({n})"); }
}

class Derived : Base
{
    public int a = 100; // 필드 초기화
    public int b; // 생성자 초기화

    public Derived()
    {
        b = 100;
    }

    public override void Foo() =>  
        Console.WriteLine($"Derived.Foo: {a}, {b}");
    

    public override void Goo(int n = 20)
    {
        Console.WriteLine($"Derived.Goo({n})");
    }
}


/*
 class Derived : Base
{
    public int a; 
    public int b; 

    public Derived()
    {
        a = 100;
        Base();
        b = 100;
    }
즉, 필드 초기화의 원리는 필드 초기화가 기반 클래스 생성자보다 먼저 진행된다.
}
 */

class Program
{
    public static void Main()
    {
        // 생성자와 가상함수
        Derived d = new Derived();

        // 가상 함수와 Optional Parameter(선택적 파라미터)
        Base b = new Derived();
        b.Goo();
    }
}