using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._2024_02_Extension
{
    class Car
    {
        public int speed { get; set; }
        //public int speed => 3; // get property 다
        public void Go() => Console.WriteLine($"{speed}");
    }

    // 2-4. 라이브러리 내 class에도 적용이 가능하다.
    static class StringExtension
    {
        public static void Stop(this String str) => Console.WriteLine("Stop");
    }

    // static 클래스는 generic 안됨. static은 시점을 알 수 없으니
    // 외부 클래스라고 가정
    static class CarExtension
    {
        // 2-1. 확장 메소드 구현하기
        // 인자로 this T 를 사용한다.

        // 2-2. 확장 메소드 동작 방식
        // 실제 클래스 멤버 함수를 호출하면 default로 첫 번째 인자는 this class가 숨겨져있다.

        // 2-3. 확장 메소드의 한계점
        // 객체의 멤버 변수에 직접 전근할 수 없다.
        // getter, setter를 사용해서 접근해야 한다.
        public static void Stop(this Car car) => Console.WriteLine("Stop");
        // public static void Stop<T>(this T car) => Console.WriteLine("Stop");
    }

    class Extension
    {
        // 1. 식 본문 메소드 (Expression - body Method)
        // 메소드의 구현이 단순한 경우 블록{ }를 생략하고 '=>' 뒤에 반환 값을 표기하는 기법
        // 1. 예제
        static int square(int x)
        {
            return x * x;
        }

        // 간단한 식 함수를 편하게 사용 가능하다.
        static int square2(int x) => x * x;
        static void main()
        {
            // 2. 확장 메소드 (Extension Method)
            // 기존 클래스를 수정하지 않고 새로운 메소드를 추가하는 문법
            // static class의 static 메소드로 제공한다.
            Car car = new();
            car.Go();
            car.Stop();

            string str = "AAA";
            str.Stop();
        }
    }
}
