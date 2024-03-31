using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudyGroup_PYH._2024_03
{
    // [Coroutine]
    // c# 언어는 코루틴을 완벽하게 지원하지 않는다. (일부만 지원함)
    // 콜렉션의 열거자를 만들 때 지원한다.
    // Linq 등이 코루틴 개념을 사용해서 작성되었다.

    // c# 컬렉션은 열거자를 반환할 수 있어야 한다.
    // 이걸 코루틴으로 변환해보자.

    // 1. 코루틴을 사용한 열거자 만들기
    // - 별도의 열거자 타입이 필요없다.
    // - IntLinkedListEnumerator가 필요 없다.
    class Node
    {
        public int data;
        public Node next;
        public Node(int data, Node next)
        {
            this.data = data;
            this.next = next;
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
                Console.WriteLine("yield return"); ;
                yield return curr.data;
                curr = curr.next;
            }
        }
    }

    internal class coroutine
    {         
        public static int Foo()
        {
            Console.WriteLine("1"); return 10;
            Console.WriteLine("2"); return 20;
        }

        public static IEnumerator<int> Goo()
        {
            Console.WriteLine("G1"); yield return 10;
            Console.WriteLine("G2"); yield return 20;
        }

        // 컬렉션 인터페이스 타입 반환
        public static IEnumerable<int> Zoo()
        {
            Console.WriteLine("Z1"); yield return 10;
            Console.WriteLine("Z2"); yield return 20;
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

            // (1) 처음 MoveNext() 호출 -> public IEnumerator GetEnumerator() 호출
            // (2) public IEnumerator GetEnumeator() -> yield return -> 반환 값이 다시 호출한 곳의 e1.Current에 저장이된다.
            // (3) 다음 MoveNext() 호출 -> yield return -> 반환 값이 다시 호출한 곳의 e1.Current에 저장이 된다
            // (4) 반복 (조건이 true이면)

            while(e1.MoveNext())
            {
                Console.WriteLine("BBB");
                Console.WriteLine(e1.Current);
            }

            // 2. 코루틴 학습
            // (1) Coroutine Method (열거자 타입 변환)
            // (1-1) 반환 타입은 4가지 중 하나만 가능하다.
            // IEnumerator, IEnumerable => object type 반환
            // IEnumerator<T>, IEnumerable<T> -> T type 반환 // 박싱 언박싱 최소화 위해 나왔겠지

            int n1 = Foo();
            int n2 = Foo();
            Console.WriteLine($"{n1}, {n2} \n");

            // 2-1. coroutine method (열거자 타입 반환) 호출하기
            // (1) 메소드 호출 후 열거자 참조 얻기
            // (2) 열거자 MoveNext() 호출
            // (3) 메소드가 yield return 한 반환값은 열거자.Current를 통해 얻을 수 있다.
            IEnumerator<int> e = Goo();
            e.MoveNext();
            Console.WriteLine(e.Current);

            e.MoveNext();
            Console.WriteLine(e.Current);

            // 3. coroutine method 호출
            IEnumerable<int> collect = Zoo();
            IEnumerator<int> collect_e = collect.GetEnumerator(); // GetEnumerator() 때마다 새로운 참조자를 생성한다.

            // 3-1
            collect_e.MoveNext();
            Console.WriteLine(collect_e.Current);

            collect_e.MoveNext();
            Console.WriteLine(collect_e.Current);

            // foreach(int i in c3) == for(IEnumerator<int> p = c3.GetEnumerator(); p.MoveNext;) 
            // 새로운 enumerator를 받아서 순회한다
            // 새로운 객체
            foreach (var item in collect) // collect_e 는 반복을 못한다(foreach)
                Console.WriteLine(item);

            collect_e.MoveNext();
            Console.WriteLine(collect_e.Current); // 30

            // 핵심
            // foreach(int i in c3) == for(IEnumerator<int> p = c3.GetEnumerator(); p.MoveNext;) 

            // GetEnumerator() 를 호출할 때마다 새로운 반복자를 생성한다. (매우매우중요)
        }
    }
}
