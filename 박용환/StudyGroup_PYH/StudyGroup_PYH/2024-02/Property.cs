using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._2024_02_Property
{
    class People
    {
        // 1. Public 필드의 문제점
        // - 외부에서 잘못된 사용으로 객체의 상태가 변할 수 있다.
        // - 필드 접근 시 "스레드 동기화", "로깅" 등을 수행할 수 없다.
        public int publicAge = 0;

        // 2. 캡슐화
        // - 필드는 private, setter/getter 메소드를 사용해서 접근한다.
        // - C#은 setter/getter 메소드는 자동으로 생성할 수 있다. -> Property 문법
        public int GetPublicAge() { return publicAge; }


        private int privateAge = 0;
    }

    class Person
    {
        // 3. Property를 만드는 방법
        // 만드는 사람은 메소드처럼 보이지만, 사용하는 사람은 필드처럼 보이는 것이 Property 이다. (프로퍼티의 특징)
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        
        // public int PropertyAge { get; set; } // 위와 같아

        private int age = 0; // backing field, background field

        // 4. backing field가 없는 속성을 만들 수도 있다.
        public bool IsAdult => age > 18;

        // 5. Automatic Property (자동 속성)
        // - getter, setter, backing field 구현을 자동으로 제공하는 property이다.
        public int AgeAuto { get; set; } = 10;

        public List<Person> persionList { get; set; } = new();
    }   

    class Point
    {
        // 자동 속성 Property
        public int X { get; set; } = 0;
    }


    class Property
    {
        public static void main()
        {
            var p = new People();

            Point point = new();
            Point point2 = new Point() { X = 10 }; // 프로퍼티의 초기화 방법: 가장 기본적인 객체 생성
            // 프로퍼티와 필드는 다르다.
            // 프로퍼티는 함수 줄인 개념 느낌

            // 6. 무명 타입. 프로퍼티는 읽기 전용
            var p5 = new { Name = "Kim", Age = 5 };
        }

        // 4 Property 문법
        // 컴파일러가 setter, getter 메소드를 자동으로 생성한다. (automatic property 라고 부른다)
        // - 메소드 이름 : set_Age, get_Age로 내부에서 실제 만들어진다.
        // ㄴ 이거는 il코드 확인해보면 될듯
        // - 사용자가 property 함수와 이름을 똑같이 정의하면 중복 에러가 난다.
    }
}
