using System;

class Base
{
    //public Base() { Console.WriteLine("Base()"); }
    public Base(int i) { Console.WriteLine("Base(int)"); }
}

class Derived : Base
{
    public Derived() : base() { Console.WriteLine("Derived()"); }
    public Derived(int i) : base() { Console.WriteLine("Derived(int)"); }
}

class Program1
{
    static void Main()
    {
        Derived d = new Derived();
    }
}