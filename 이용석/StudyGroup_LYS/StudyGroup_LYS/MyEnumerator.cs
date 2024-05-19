using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LYS
{
    internal class MyEnumerator
    {
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

        // 핵심 내용
        class IntLinkedListEnumerator : IEnumerator
        {
            public Node head = null;
            public Node curr = null;

            public IntLinkedListEnumerator(Node n)
            {
                head = n;
            }

            public object Current => curr.data;

            public bool MoveNext()
            {
                // 최초 호출
                if (curr == null)
                {
                    curr = head;
                }
                else
                {
                    curr = curr.next;
                }

                return curr != null;
            }

            public void Reset()
            {
                curr = null;
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
                return new IntLinkedListEnumerator(head);
            }
        }

        public static void Main()
        {
            IntLinkedList st1 = new IntLinkedList();
            st1.AddFirst(10);
            st1.AddFirst(20);
            st1.AddFirst(30);
            st1.AddFirst(40);
            st1.AddFirst(50);

            // 1. 열거자
            IEnumerator e1 = st1.GetEnumerator();
            while (e1.MoveNext())
            {
                Console.WriteLine(e1.Current);
            }
        }
    }
}
