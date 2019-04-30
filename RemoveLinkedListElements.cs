using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    
    public class RemoveLinkedListElements
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            var listNode = new ListNode(0); //a dummy node to track the progress
            listNode.next = head; //set the next to current head
            var temp = listNode; //create a temp node

            while (temp.next != null)
            {
                if (temp.next.val == val)
                {
                    temp.next = temp.next.next;
                }
                else
                {
                    temp = temp.next;
                }
            }

            return listNode.next; //this will always point to the correct head.

        }

        public ListNode RemoveElementsRecursive(ListNode head, int val)
        {
            if (head == null)
            {
                return null;
            }
            head.next = RemoveElementsRecursive(head.next, val);
            return head.val == val ? head.next : head;

        }

        public void Run()
        {
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(6);
            head.next.next.next = new ListNode(3);
            head.next.next.next.next = new ListNode(4);
            head.next.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next.next = new ListNode(6);

            var x = RemoveElements(head, 6);
        }
    }
}
