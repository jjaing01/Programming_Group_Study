using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    delegate void HANDLER();
    class Button
    {
        public HANDLER handler_test = null;
        // 1.event
        // 특징: +=, -= 연산자만 사용할 수 있고, = 연산자는 사용할 수 없다.
        // 이전에 등록한 것을 삭제할 수 없도록 한다.
        // event는 구독자 간의 독립성을 위한 것이다.
        public event HANDLER handler_event = null;

        public void Press()
        {
            // 값의 존재 여부를 확인할 수 없다.
            handler_test();
            handler_event?.Invoke();
        }
    }

    // 2. event를 사용하는 순간 내부에서는 아래 class 형태로 변환해준다.
    class Button_Event
    {
        public event HANDLER handler_event = null;
        public void add_handler(HANDLER f) { handler_event += f; }
        public void remove_handler(HANDLER f) { handler_event -= f; }
        public void press()
        {
            handler_event?.Invoke();
        }
    }

    class Program
    {
        public static void Main()
        {
            Button btn = new Button();
            btn.handler_test = F1; // A라는 사람이 등록했음
            btn.handler_test += F2; // B라는 사람이 등록했음
            btn.handler_test = F3; // C라는 사람이 실수로 F3 대입을 해버렸어 => 앞에 사용자들이 등록했던 기록들이 사라진다.
            btn.Press();

            // 위 실수를 방지하기 위해 event를 사용한다.
            btn.handler_event += F1; // btn.add_handler(F1);
            btn.handler_event += F2;
            btn.handler_event += F3; // C라는 사람이 실수로 F3 대입을 해버렸어 => 앞에 사용자들이 등록했던 기록들이 사라진다.
            btn.Press();
        }
        public static void F1() { Console.WriteLine("F1"); }
        public static void F2() { Console.WriteLine("F2"); }
        public static void F3() { Console.WriteLine("F3"); }
    }
}
