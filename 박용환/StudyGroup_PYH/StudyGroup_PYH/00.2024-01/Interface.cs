using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._00._2024_01
{
    /* [interface]
     * 일관된 형태의 라이브러리를 만들기 위해 '클래스들의 이름을 약속' 하는 것
     * 클래스를 만드는 사람과 사용하는 사람 사이의 규칙을 정의하는 것
     * 
     * C#의 핵심 -> 다양한 인터페이스를 먼저 설계한다.
     * 대부분의 클래스는 특정 인터페이스를 구현하는 방식으로 개발한다.
     */

    interface MyList
    {
        // c# 8.0 부터 접근 제어 지시자 직접 명시 가능, 근데 private는 의미 없음
        // internal 까지는 지원하는 듯?
        void Clear();
    }

    class Stack : MyList
    {
        public void Clear()
        {

        }
    }

    class Interface
    {

    }
}
