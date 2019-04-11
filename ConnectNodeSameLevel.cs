using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Algorithms
{

    /// <summary>
    /// Write a function to connect all the adjacent nodes at the same level in a binary tree.
    /// </summary>
    public class ConnectNodeSameLevel
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node NextRight { get; set; }
        

        public Node(int d)
            {
                Data = d;
                Left = null;
                Right = null;
                NextRight = null; 
            }
        }

        public void Connect(Node root, int l,List<List<int>> result )
        {
            if (root == null)
            {
                return;
            }

            if (result.Count <= l|| result.Count == 0)
            {
                result.Add(new List<int>());
            }
            result[l].Add(root.Data);
            Connect(root.Left, l+1, result);
            Connect(root.Right, l + 1, result);
        }

        

        public void Run()
        {
            Node root = new Node(10);
            root.Left = new Node(8);
            root.Right = new Node(2);
            root.Left.Left = new Node(3);
            root.Left.Right = new Node(90);

            var result = new List<List<int>>();
            Connect(root, 0, result);
        }
    }
}
