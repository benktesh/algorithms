using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Algorithms
{
    /*
     * Check if a given Binary Tree is SumTree
       Write a function that returns true if the given Binary Tree is SumTree else false. 
       A SumTree is a Binary Tree where the value of a node is equal to sum of the nodes 
       present in its left subtree and right subtree. An empty tree is SumTree and sum 
       of an empty tree can be considered as 0. A leaf node is also considered as SumTree.
                                26
                              /    \
                            10      3
                           /   \     \
                         4      6     3
     */
    public class BinaryTreeSumTree
    {
        public int Sum(Node node)
        {
            if (node == null)
                return 0;
            else
            {
                return Sum(node.Left) + node.Data + Sum(node.Right);
            }
        }
        public bool IsSumTree(Node root)
        {
            int ls = 0;
            int rs = 0;
            if (root == null || (root.Right == null && root.Left == null))
            {
                return true;
            }

            ls = Sum(root.Left);
            rs = Sum(root.Right);

            return (ls + rs == root.Data) && IsSumTree(root.Left) && IsSumTree(root.Right);
        }
        
        public void Run()
        {
            Node root = new Node(26);
            root.Left = new Node(10);
            root.Right = new Node(3);

            root.Left.Left = new Node(4);
            root.Left.Right = new Node(6);

            root.Right = new Node(3);
            root.Right.Right = new Node(3);

            var x = IsSumTree(root);
            Console.WriteLine($"Is Sum Tree? {x}" );
        }
    }
}
