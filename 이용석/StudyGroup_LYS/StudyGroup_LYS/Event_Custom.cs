using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LYS.Event
{
    delegate void Handler();

    class Button
    {
        public Handler handler_test = null;
        // 1. event
        // +=, -= 연산자만 사용할 수 있고, = 연산자는 사용할 수 없다.
        // 이전에 등록한 것을 삭제할 수 없도록 한다.
        // event는 구독자 간의 독립성을 위한 것이다.

        public event Handler handler_event = null;

        public void Press_Test()
        {
            // 값의 존재 여부를 확인할 수 없다.
            handler_test();
        }
        public void Press_Event()
        {
            // 
            handler_event?.Invoke();
        }
    }
    // 2. Event를 사용하는 순간 내부에서는 아래 Class 형태로 변환해준다.
    class Button_Event
    {
        public event Handler handler_event = null;
        public void add_handler(Handler f) { handler_event += f; }
        public void remove_handler(Handler f) { handler_event -= f;}
    }



    class Program
    {
        public static void Main(string[] args) 
        {
            Button btn = new Button();
            btn.handler_test = F1;      // A라는 사람이 등록
            btn.handler_test += F2;     // B라는 사람이 등록
            btn.handler_test = F3;      // C라는 사람이 실수로 F3으로 대입을 해벌임
                                        // 앞의 사용자가 등록한 기능들이 사라짐
            btn.Press_Test();

            // 위 실수를 방지 하기 위해 event를 사용
            btn.handler_event += F1;     // A라는 사람이 등록
            btn.handler_event += F2;     // B라는 사람이 등록
            //btn.handler_event = F3;    // C라는 사람이 실수로 F3으로 대입을 해버릴 수 없음

            btn.Press_Event();
        }

        public static void F1() { Console.WriteLine("F1"); }
        public static void F2() { Console.WriteLine("F2"); }
        public static void F3() { Console.WriteLine("F3"); }
    }
}
