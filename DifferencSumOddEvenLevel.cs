using System;
using System.Collections.Generic;
using System.Linq;

namespace algorithms
{
    public class DifferencSumOddEvenLevel
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Left { get; set; }

            public Node Right { get; set; }
            public Node(int data)
            {
                Data = data;
                Left = Right = null;
            }
        }

        public class Tree
        {
            public Node Root { get; set; }

            public Tree(Node node)
            {
                Root = node;
            }
        }

        private List<int> even = new List<int>();
        private List<int> odd = new List<int>();

        public void PrintSum(Node node)
        {
            PrintSum(node, 1);

            var result = odd.Sum(k => k) - even.Sum(k => k);
            Console.WriteLine(result);
        }

        
        private void PrintSum(Node node, int level)
        {
            if (node == null)
            {
                return;
            }

            if (level % 2 == 0)
            {
                even.Add(node.Data);
            }
            else
            {
                odd.Add(node.Data);
            }

            PrintSum(node.Left, level+1);
            PrintSum(node.Right, level + 1);
        }

        public void Run()
        {
            var tree = new Tree(new Node(5));
            tree.Root.Left = new Node(2);
            tree.Root.Left.Left = new Node(1);
            tree.Root.Left.Right = new Node(4);
            tree.Root.Left.Right.Left = new Node(3);
            tree.Root.Right = new Node(6);
            tree.Root.Right.Right = new Node(8);
            tree.Root.Right.Right.Left = new Node(7);
            tree.Root.Right.Right.Right = new Node(9);
            PrintSum(tree.Root);
        }
    }
}