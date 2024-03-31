using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LYS
{
    // [COROUTINE]
    // C# 언어는 코루틴을 완벽하게 지원하지 않는다. (일부만 지원함)
    // 콜렉션의 열거자를 만들 때 지원한다.
    // Linq 등이 코루틴 개념을 사용해서 작성되었다.

    // C# 컬렉션은 열거자를 반환할 수 있어야 한다.
    // 이걸 코루틴으로 변환해보자

    // 1. 코루틴을 사용한 열거자 만들기
    // - 별도의 열거자 타입이 필요없다.
    // - IntLinkedListEnumerator 가 필요 없다.

    class Node
    {
        public int data;
        public Node next;
        public Node(int d, Node n)
        {
            data = d;
            next = n;
        }
    }

    class IntLinkedList : IEnumerable
    {
        public Node head = null;
        public void AddFirst(int data)
        {
            head = new Node(data, head);
        }

        public IEnumerator GetEnumerator()
        {
            // 2-1 열거자를 반환해야 한다.
            // - GetEnumerator() 에서 컬렉션이 가진 모든 요소에 대해 yield return 수행한다.
            // - yield return : 코루틴을 사용한다 라는 의미
            Console.WriteLine("Get Enumerator() Start!");
            Node curr = head;

            while (curr != null)
            {
                Console.WriteLine("yield return");
                yield return curr.data;
                curr = curr.next;
            }
        }
    }
    internal class Coroutine
    {
        public static int Foo()
        {
            Console.WriteLine("F1"); return 10;
            Console.WriteLine("F2"); return 20;
            Console.WriteLine("F3"); return 30;
            Console.WriteLine("F4"); return 40;
            Console.WriteLine("F5"); return 50;
        }

        public static IEnumerator<int> Goo()
        {
            Console.WriteLine("G1"); yield return 10;
            Console.WriteLine("G2"); yield return 20;
            Console.WriteLine("G3"); yield return 30;
            Console.WriteLine("G4"); yield return 40;
            Console.WriteLine("G5"); yield return 50;
        }

        // 컬렉션 인터페이스 타입 반환
        public static IEnumerable<int> Zoo()
        {
            Console.WriteLine("Z1"); yield return 10;
            Console.WriteLine("Z2"); yield return 20;
            Console.WriteLine("Z3"); yield return 30;
            Console.WriteLine("Z4"); yield return 40;
            Console.WriteLine("Z5"); yield return 50;
        }

        public static void Main()
        {
            IntLinkedList st1 = new IntLinkedList();
            st1.AddFirst(10);
            st1.AddFirst(20);
            st1.AddFirst(30);
            st1.AddFirst(40);
            st1.AddFirst(50);

            // (0) GetEnumerator()를 호출해도 바로 함수에 진입하지 않는다.
            IEnumerator e1 = st1.GetEnumerator();
            Console.WriteLine("AAA");

            // (1) 처음 MoveNext() 호출 ->  public IEnumerator GetEnumerator() 호출
            // (2) public IEnumerator GetEnumerator() -> yield return -> 반환 값이 다시 호출한 곳의 e1.Current에 저장이 된다.
            // (3) 다음 MoveNext() 호출 -> yield return -> 반환 값이 다시 호출한 곳의 e1.Current에 저장이 된다.
            // (4) 반복 (조건이 참일 때 까지)
            while (e1.MoveNext())
            {
                Console.WriteLine("BBB");
                Console.WriteLine(e1.Current);
            }

            // 2. 코루틴 학습
            // (1) Coroutine Method (열거자 타입 반환)
            // (1-1) 반환 타입은 4가지 중 하나만 가능하다
            // IEnumerator, IEnumerable => object type 반환
            // IEnumerator<T>, IEnumerable<T> => T type을 반환

            int n1 = Foo();
            int n2 = Foo();
            Console.WriteLine($"{n1},{n2}\n");

            // 2-1. Coroutine Method (열거자 타입 반환) 호출하기
            // (1) 메소드 호출 후 열거자 참조 얻기
            // (2) 열거자 MoveNext() 호출
            // (3) 메소드가 yield return 한 반환값은 열거자.Current를 통해 얻을 수 있다.
            IEnumerator<int> e = Goo();
            e.MoveNext();
            Console.WriteLine(e.Current);
            e.MoveNext();
            Console.WriteLine(e.Current + "\n\n\n");

            // 3. Coroutine Method 호출
            IEnumerable<int> collect = Zoo();
            IEnumerator<int> collect_e = collect.GetEnumerator();

            // 3-1
            collect_e.MoveNext();
            Console.WriteLine(collect_e.Current);
            collect_e.MoveNext();
            Console.WriteLine(collect_e.Current);

            var collect_e2 = collect.GetEnumerator();
            collect_e2.MoveNext();
            Console.WriteLine(collect_e2.Current + "\n\n\n\n\n\n");

            //foreach (var i in collect) == for(IEnumerator<int> p = collect.GetEnumerator(); p.MoveNext();)
            foreach (var e3 in collect)
                Console.WriteLine(e3);
        }
    }
}
