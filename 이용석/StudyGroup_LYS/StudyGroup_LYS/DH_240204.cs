using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LYS
{
    // 1. 식 본문 메소드 ( Expresiion - body method )
    // 메소드의 구현이 단순한 경우 블록{}를 생략하고 '=>' 표기 뒤에 반환 값을 표기하는 기법
    // 아래 두개는 동일하다
    //static int square(int x)
    //{
    //    return x * x;
    //}

    //static int squareEX(int x) => x * x;
    //

    class Car
    {
        // speed에도 사용가능함 Getter임
        private int speed;
        protected int protectedSpeed;
        public void Go() => Console.WriteLine("GO");
    }

    static class CarExtension
    {
        // 2-1. 확장 메서드 구현하기
        // this를 무조건 붙여야함 

        // 2-2. 확장 메소드 동작 방식
        // 실제 클래스 멤버 함수를 호출하면 default로 첫 번째 인자는 this class가 숨겨져 있다.

        // 2-3. 확장 메서드의 한계점
        // 객체의 멤버 변수에 직접 접근할 수 없다.
        // getter, setter를 사용해서 접근해야 한다.
        //public static void Stop(this Car car) => Console.WriteLine("Stop");
        public static void Stop(this Car car)
        {
            Console.WriteLine("Stop");

            // 여기서는 Car의 private, protected 필드에는 접근할 수 없다.
            // 당연하게 상속이 아니므로

        }

        // where 공부하기
        public static void Stop<T>(this T car) where T : Car
        {
            Console.WriteLine("Stop");

            // 여기서는 Car의 private, protected 필드에는 접근할 수 없다.
            // 당연하게 상속이 아니므로
        }
    }

    // 2-4  라이브러리 내 class에도 적용이 가능하다.
    static class Stringextension
    {
        public static void Stop(this string str) => Console.WriteLine("Stop");
    }


    class dh
    {
        static void Main(string[] args)
        {
            // 2. 확장 메서드 (Extension Method)
            // 기존 클래스를 수정하지 않고, 새로운 메소드를 추가하는 문법
            // static lass의 static 메소드로 제공한다.

            Car car = new Car();
            car.Go();
            car.Stop();
        }
    }
}
