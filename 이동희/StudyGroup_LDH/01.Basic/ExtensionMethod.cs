using System;

namespace StudyGroup_LDH._01.Basic
{
    class Car
    {
        public int speed { get; set; }
        //public int speed => 3;

        public void Go() => Console.WriteLine("GO");
    }

    static class CarExtension
    {
        // 2-1. 확장 메소드 구현하기
        // 인자로 this T를 사용한다.

        // 2-2. 확장 메소드 동작 방식
        // 실제 클래스 멤버 함수를 호출하면 default로 첫 번째 인자는 this class가 숨겨져있다.

        // 2-3. 확장 메소드의 한계점
        // 객체의 멤버 변수에 직접 접근할 수 없다.
        // getter, setter를 사용해서 접근해야 한다.
        public static void Stop<T>(this T car) where T : Car
        {
            Console.WriteLine("Stop");
        }
    }

    // 2-4. 라이브러리 내 class에도 적용이 가능하다.
    static class StringExtension
    {
        public static void Stop(this string str) => Console.WriteLine(str+"Stop");
    }

    class ExtensionMethod
    {
        // 1. 식 본문 메소드 (Expression - body Method)
        // 메소드의 구현이 단순한 경우 블록{ }를 생략하고 '=>' 표기 뒤에 반환 값을 표기하는 기법
        // 1. 예제
        public static int square(int x)
        {
            return x * x;
        }
        // 위 처럼 간단한 식 함수를 편하게 사용 가능하다.
        public static int square2(int x) => x * x;

        public static void Main()
        {
            // 2. 확장 메소드 (Extension Method)
            // 기존 클래스를 수정하지 않고, 새로운 메소드를 추가하는 문법
            // static class의 static 메소드로 제공한다.
            Car car = new();
            car.Go();
            car.Stop();

            string str = "AAA";
            str.Stop();
        }
    }
}
