using System;
using System.ComponentModel.Design.Serialization;
using System.Net.Security;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace algorithms
{
    //Given a root of a tree, and an integer k.Print all the nodes which are at k distance from root.
    public class PrintNodeKDistance
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
            public Node Root;
            public Tree(Node root)
            {
                Root = root;
            }
        }

        public void PrintNodes(Node node, int k)
        {
            GetNodeLevel(node, 0, k);
        }
        //We are looking at it recursively
        //starting from root, we look at left (if there is value) or right incrementing the level by 1
        //if level is equal to k, then we print it at each call
        //if node is null or level is > k we simply return;
        public void GetNodeLevel(Node node, int level, int k)
        {
            if (level > k || node == null)
            {
                return;
            }

            if (level == k)
            {
                Console.Write(node.Data + " ");
            }
            GetNodeLevel(node.Left, level + 1, k);
            GetNodeLevel(node.Right, level + 1, k);
        }

        public void Run()
        {
            /*
                             1
                          /     \
                         2       3
                       /   \     /
                      4     5   8  
             */

            var tree = new Tree(new Node(1));
            tree.Root.Left = new Node(2);
            tree.Root.Left.Left = new Node(4);
            tree.Root.Left.Right = new Node(5);
            tree.Root.Right = new Node(3);
            tree.Root.Right.Left = new Node(8);

            PrintNodes(tree.Root, 2);
        }
    }
}
