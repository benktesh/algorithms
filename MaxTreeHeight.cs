using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public class MaxTreeHeight
    {
        public class Node
        {
            public int Data;

            public Node(int i)
            {
                Data = i;
                Left = null;
                Right = null;
            }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        public class Tree
        {
            public Node Root { get; set; }
           
            public Tree(Node root)
            {
                Root = root;
               
            }
        }
        public int  FindHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            var lHeight = FindHeight(node.Left);
            var rHeight = FindHeight(node.Right);

            return Math.Max(lHeight, rHeight) + 1;  

        }

        public void Run()
        {
            var tree = new Tree(new Node(1));
            tree.Root.Left = new Node(2);
            tree.Root.Left.Left = new Node(4);
            tree.Root.Left.Right = new Node(5);
            tree.Root.Right = new Node(3);

            var height = FindHeight(tree.Root);
        }
    }
}
