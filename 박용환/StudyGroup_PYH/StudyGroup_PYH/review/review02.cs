class Animal
{
    protected Animal() { } // abstract 로 객체 x
}

class Dog : Animal
{
    public Dog() { }
}

class Program
{
    static void Main()
    {
        //Animal ani = new Animal();
        Dog dog = new Dog();
    }
}