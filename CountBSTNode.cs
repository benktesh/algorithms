using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using algorithms;

namespace Algorithms
{
    public class CountBSTNode
    {
        private int count = 0;
        private int recurCOunt = 0; 
        public void NodesInRange(Node root, int[] range)
        {
            recurCOunt++;
            if (root == null)
            {
                return;
            }
            int current = root.Data;
            if (current <= range[1] && current >= range[0])
            {
                Console.Write(current + " ");
                count++;
            }
            NodesInRange(root.Right, range);
            NodesInRange(root.Left, range);
        }

        public int NodesInRange1(Node root, int[] range)
        {
            recurCOunt++;
            if (root == null)
            {
                return 0;
            }
            int current = root.Data;
            if (current <= range[1] && current >= range[0])
            {
                Console.Write(current + " ");
                return 1 + NodesInRange1(root.Right, range) + NodesInRange1(root.Left, range);
            }
            if(current > range[1])
            {
                return NodesInRange1(root.Left, range);
                
            }
            return NodesInRange1(root.Left, range);
        }

        public bool IsInRange(int n, int[] range)
        {
            return n <= range[1] && n >= range[0];
        }
        public int NodesInRangeIterative(Node root, int[] range)
        {
            count = 0;
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                if (IsInRange(cur.Data, range))
                {
                    count++;
                    Console.Write(cur.Data + " ");
                }
                if (cur.Left != null)
                {
                    queue.Enqueue(cur.Left);
                }
                if (cur.Right != null)
                {
                    queue.Enqueue(cur.Right);
                }
            }

            return count;
        }
        public void Run()
        {
            Node root = new Node(10);
            root.Left = new Node(5);
            root.Left.Left = new Node(1);

            root.Right = new Node(50);
            root.Right.Left = new Node(40);
            root.Right.Right = new Node(100);
            var range = new int[] {5, 45};

            count =  NodesInRange1(root, new int[] { 5, 45});
            Console.WriteLine(recurCOunt);
            Console.WriteLine(count);

            recurCOunt = 0; 
            NodesInRange1(root, new int[] { 5, 45 });
            Console.WriteLine(recurCOunt);
            Console.WriteLine(count);

            count = NodesInRangeIterative(root,range);
            Console.WriteLine(count);


        }
    }
}
