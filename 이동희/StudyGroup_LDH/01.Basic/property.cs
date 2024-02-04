using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    class People
    {
        // 1. Public 필드의 문제점
        // - 외부에서 잘못된 사용으로 객체의 상태가 변할 수 있다.
        // - 필드 접근 시 "스레드 동기화", "로깅" 등을 수행할 수 없다.
        public int publicAge = 0;

        // 2. 캡슐화
        // - 필드는 private, setter와 getter 메소드를 사용해서 접근한다.
        // - C#은 setter와 getter 메소드는 자동으로 생성할 수 있다. -> Property 문법
        public int getAge() { return privateAge; }
        public void setAge(int age) { if (age > 0) privateAge = age; }

        private int privateAge = 0;
    }

    class Person
    {
        // 3. Property를 만드는 방법
        // 만드는 사람은 메소드처럼 보이지만, 사용하는 사람은 필드처럼 보이는 것이 Property 이다. (프로퍼티의 특징)
        
        public int Age { get => age; set => age = value; }
        public int ProPertyAge { get; } = 1;
        private int age = 0; // backing field, background field
        
        // 4. backing field가 없는 속성을 만들 수도 있다.
        public bool IsAdult => age > 18;

        // 5. Automatic Property (자동 속성)
        // - getter + setter + backing field 구현을 자동으로 제공하는 Property이다.
        public int Age3 { get; set; } = 10; // age

        public List<Person> personList { get; set; } = new();
    }

    class Point
    {
        // 자동 속성 프로퍼티
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public int test = 0;
    }

    class Program
    {
        public static void Main()
        {
            People p = new People();
            p.publicAge = 10;
            p.publicAge = -5;

            Point point = new();
            Point point2 = new Point { X = 10 }; // 프로퍼티의 초기화 방법: 가장 기본적인 객체 생성

            // 5. 무명 타입
            var p5 = new { Name = "Kim", Age = 5 };
            Console.WriteLine(p5.Age);
            //p5.Age = 10; // 무명 타입의 프로퍼티는 읽기 전용이다.
        }
    }

    // 4. Property 문법 
    // - 컴파일러가 setter, getter 메소드를 자동으로 생성한다.
    // - 메소드 이름: set_Age, get_Age로 내부에서 실제 만들어진다.
    // - 사용자가 property 함수와 이름을 똑같이 정의하면 중복 에러가 난다.
}
