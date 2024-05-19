using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LYS
{
    class People
    {
        // 1. Public 필드의 문제점
        // - 외부에서 잘못된 사용으로 객체의 상태가 변할 수 있다.
        // - 필드 접근 시 "스레드 동기화", "로깅" 등을 수행할 수 없다.
        public int publicAge = 0;

        // 2. 캡슐화
        // - 접근 지정자를 통해 필드는 private, setter와 getter 메소드를 사용해서 접근 지정자.
        // - C#은 setter와 getter를 자동으로 생서할 수 있다. -> Property
        private int privateAge = 0;
        public int getAge() { return privateAge; }
        public void setAge(int age) {  if(age > 0) privateAge = age; }
    }

    class Person
    {
        // 3. Property를 만드는 방법
        // 만드는 사람은 메소드처럼 보이지만, 사용하는 사람은 필드처럼 보이는 것이 Property이다.

        private int age = 0;
        public int Age
        {
            get { return age; }

            set => age = value;
            // backing field 
            // Age에서 사용하는 age라는 변수는 backing field라고 부른다.
        }

        public int ProPertyAge { get => age; set => age = value; }
        
        // 내부에서도 사용 불가능
        // 생성자에서는 사용 가능한데 될 수 있으면 초기화를 통해 제어
        public int readonlyAge { get; }
        //public int readonlyAge { get; } = 1;

        // 4. backing field가 없는 속성을 만들 수도있다.
        public bool isAdult
        {
            get { return age > 18; }
        }
        //public bool isAdult => age > 18;

        // 5. Automatic Property (자동 속성)
        // - getter + setter + backing field 구현을 자동으로 제공하는 Property 이다.
        
        // property는 함수라고 생각해야한다.
        // backing field에 실제 값이 있는겨
        public int Age3 { get; set; } = 10;
    }

    // Property의 Initalize
    class Point
    {
        // 자동 속성 프로퍼티
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
    }
    
    class Property
    {
        public static void Main()
        {
            Point point = new();
            Point point2 = new Point();
            Point point3 = new Point() { X = 10, Y = 20 };

            // 5. 무명타입
            var p5 = new { X = 10, Y = 20 };
            // p5.X = 10; // 무명 타입의 프로퍼티는 읽기 전용이다.
        }
    }

    // 4. Property 문법
    // - 컴파일러가 setter, getter 메소드를 자동으로 생성한다.
    // - 메소드 이름 : set_Age, get_Age로 내부에서 실제 만들어진다.
    // - 사용자가 property 함수와 이름을 똑같이 정의하면 중복 에러가 난다.
}
