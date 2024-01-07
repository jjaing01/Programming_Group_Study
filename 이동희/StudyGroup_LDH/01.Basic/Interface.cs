using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    /*
     [인터페이스]
    - 일관된 형태의 라이브러리를 만들기 위해 "클래스들의 이름을 약속" 하는 것
    - 클래스를 만드는 사람과 사용하는 사람 사이의 규칙을 정의하는 것

    - C# 핵심 -> 다양한 인터페이스를 먼저 설계한다.
    -- 대부분의 클래스는 특정 인터페이스를 구현하는 방식으로 개발한다.
     */
    interface IMyList
    {
        // Interface 내부 메소드는 접근 지정자를 표기 못했다.
        // C# 8.0부터 접근 지정를 표기해도 된다.
        void Clear();
    }

    class Stack : IMyList
    {
        public void Clear()
        {
        }
    }
}
