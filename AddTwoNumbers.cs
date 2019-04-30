using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    /*
     * You are given two non-empty linked lists representing two non-negative integers.
     * The digits are stored in reverse order and each of their nodes contain a single digit.
     * Add the two numbers and return it as a linked list.
       
       You may assume the two numbers do not contain any leading zero, except the number 0 itself.
       
       Example:
       
       Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
       Output: 7 -> 0 -> 8
       Explanation: 342 + 465 = 807.
     */

    public class AddTwoNumbers
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode AddListNode(ListNode l1, ListNode l2)
        {
            var q1 = new Queue<ListNode>();
            var q2 = new Queue<ListNode>();

            while (l1 != null)
            {
                q1.Enqueue(l1);
                l1 = l1.next;
            }

            while (l2 != null)
            {
                q2.Enqueue(l2);
                l2 = l2.next;
            }

            int carry = 0;
            var q3 = new Queue<int>();
            while (q1.Count > 0 && q2.Count > 0)
            {
                var first = q1.Dequeue();
                var second = q2.Dequeue();
                var final = first.val + second.val + carry;
                carry = final / 10;
                final = final % 10;
                q3.Enqueue(final);
            }

            while (q1.Count > 0)
            {
                var data = q1.Dequeue();
                var final = data.val + carry;
                carry = final / 10;
                final = final % 10;
                q3.Enqueue(final);
            }

            while (q2.Count > 0)
            {
                var data = q2.Dequeue();
                var final = data.val + carry;
                carry = data.val / 10;
                final = final % 10;
                q3.Enqueue(final);
            }

            if (carry > 0)
            {
                q3.Enqueue(carry);
            }

            var result = new ListNode(q3.Dequeue());
            var next = result;
            while (q3.Count > 0)
            {
                next.next = new ListNode(q3.Dequeue());
                next = next.next;
            }

            return result;
        }
        public void Run()
        {
            var l1 = new ListNode(2);
            var l2 = new ListNode(4);
            var l3 = new ListNode(3);
            l1.next = l2;
            l2.next = l3;

            
            var r1 = new ListNode(5);
            var r2 = new ListNode(6);
            var r3 = new ListNode(4);

            r1.next = r2;
            r2.next = r3; 

            
            var result = AddListNode(l1, r1);
        }
    }
}
