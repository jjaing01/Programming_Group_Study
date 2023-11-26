class Animal
{
    protected Animal() { }
}

class Dog : Animal
{
    public Dog() { }
}

class Program
{
    static void Main()
    {
        Animal ani = new Animal();
        Dog dog = new Dog();
    }
}