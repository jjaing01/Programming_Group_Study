using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace StudyGroup_PYH._00._2024_01_21_Casting
{
    class Ani
    {

    };

    class Dog
    {

    }

    class Point
    {
        public int x;
        public int y;

        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        // 변환 연산자 재정의
        // explicit 키워드를 꼭 표기해야 한다.
        public static explicit operator int(Point pt) { return pt.x; }
        public static explicit operator Point(int x) { return new Point(x, x); }
    }

    // [캐스팅 규칙]
    // 데이터 손실이 발생하지 않는 경우 -> 암시적 형변환 가능
    // 데이터 손실이 발생하는 경우 -> 항상 명시적 캐스팅을 사용해야 한다.
    class casting
    {
        public static void Foo(Animal ani)
        {
            // ani.Cry() // error -> Animal.Cry() 없다.

            // 0. Animal 참조 타입을 Dog 참조 타입으로 캐스팅
            Dog d = (Dog)ani;
            d.Cry(); // Foo(new Animal()); 일 경우 예오 ㅣ발생, try ~ catch로 잡아야 한다.

            // 1. 타입 조사하기
            // (1) is : 참조 변수가 가르키는 실제 타입을 조사한다.
            if(ani is Dog)
            {
                Console.WriteLine("dog");
                Dog d1 = (Dog)ani;
                d1.Cry();
            }


            // 간략화
            if(ani is Dog dog)
            {
                Console.WriteLine("Dog");
                dog.Cry();
            }

            // (2) as : 조사한 타입과 맞지 않을 경우 null 반환
            Dog d2 = ani as Dog;
            if(d2 == null)
            {
                Console.WriteLine("dog null");
            }

            // 간략화
            Dog d3 = ani as Dog ?? new Dog();
        }
        public static void main()
        {
            int n = 3;
            double d = 3.4;

            d = n; // 암시적 가능
            n = d; // 명시적 필요

            Foo(new Dog());
            Foo(new Animal());

            // 3. 값 타입의 as 사용
            int num = 3;
            object obj = n;

            int num1 = obj as int; // int는 null을 값으로 받을 수 없다.
            int? num2 = obj as int?;

            // 4. 변환 연산자
            Point pt = new Point(10, 20);
            int number = pt; // 에러 
            int number2 = (int)pt; // OK

            Point pt2 = (Point)number;

            // 4-1 주의점
            Point p3 = number2 as Point; // error (Point)number2  
        }
    }
}
