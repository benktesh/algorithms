using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace algorithms
{
    public class SumLinkedList
    {
        public class Node
        {
            public Node Next;
            public int Value;

            public Node(int data)
            {
                Value = data;
            }
        }

        public class LinkedList
        {
            public Node Head;
            public void AddNode(int data)
            {
                Node newNode = new Node(data);
                newNode.Next = Head;
                Head = newNode;
            }

        }

        public LinkedList AddLists(LinkedList first, LinkedList second)
        {
            StringBuilder firstNumber = new StringBuilder();

            var fs = new Stack<int>();

            var cur = first.Head;
            while (cur != null)
            {
                int d = cur.Value;
                cur = cur.Next;
                fs.Push(d);
            }

            StringBuilder secondNumber = new StringBuilder();
            var ss = new Stack<int>();

            cur = second.Head;
            while (cur != null)
            {
                int d = cur.Value;
                cur = cur.Next;
                ss.Push(d);
            }

            int ssC = ss.Count;
            int fsC = fs.Count;

            if (ssC > fsC)
            {
                for (int i = 0; i < ssC - fsC; i++)
                {
                    fs.Push(0);
                }
            }
            else
            {
                for (int i = 0; i < fsC - ssC; i++)
                {
                    ss.Push(0);
                }
            }

            int sum = 0;
            int digit =fs.Count-1;
            while (fs.Count > 0 && ss.Count > 0)
            {
                
                sum = sum + (fs.Pop() + ss.Pop()) *(int) Math.Pow(10,digit);
                digit--;
            }

            //390
            LinkedList final = new LinkedList();
            var rs = new Stack<int>();
            while (sum > 0)
            {
                rs.Push(sum%10);
                sum /= 10;
            }

            while (rs.Count > 0)
            {
                final.AddNode(rs.Pop());
            }
            return final;

        }

        public void Run()
        {
            var first = "4 5".Split(' ').Select(k => Int32.Parse(k)).ToArray();
            var second = "3 4 5".Split(' ').Select(k => Int32.Parse(k)).ToArray();

            var firstList = MakeLinkedList(first);
            var secondList = MakeLinkedList(second);

            AddLists(firstList, secondList);
        }

        private static LinkedList MakeLinkedList(int[] second)
        {
            LinkedList list = new LinkedList();
            foreach (var item in second)
            {
                list.AddNode(item);
            }
            return list;
        }
    }
}
