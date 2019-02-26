using System;
namespace algorithms
{
    public class ReverseLinkedList
    {
        public ReverseLinkedList()
        {

        }

        public static void RunMe()
        {
            LinkedList list = new LinkedList();
            //85 15 4 20
            list.AddNode(new Node(85));
            list.AddNode(new Node(15));
            list.AddNode(new Node(4));
            list.AddNode(new Node(20));

            list.Print();
            list.ReverseList();
            list.Print();

        }
    }

    public class Node
    {
        public int data;
        public Node next;

        public Node(int d)
        {
            data = d;
            next = null;
        }
    }

    public class LinkedList
    {
        Node head;

        public void AddNode(Node node)
        {
            if (head == null)
                head = node;
            else
            {
                var temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = node;
            }
        }

        /// <summary>
        /// Reverses the list.
        /// We ceate three variables, prev, current and next. 
        /// Prev and next are set to null initially and current is set to the head.
        /// If current node is null, then head, previous and current are all null;
        /// If current node is not null, we swap prev and next of the current and move the current to next.
        /// When the current is null, we have reached the end of the list and we set the head to prev which at the time would be the last node before the current
        /// </summary>
        public void ReverseList()
        {
            Node prev = null;
            Node current = head;
            Node next = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            //once we are done through the list, we set head to previous
            head = prev;
        }

        public void Print()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.data + "->");
                current = current.next;
            }
            Console.Write("Null\n");
        }

    }
}
