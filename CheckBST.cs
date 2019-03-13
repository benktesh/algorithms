using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    /*
    Class to check if a tree is BST
    A binary search tree(BST) is a node based binary tree data structure which has the following properties.
    • The Left subtree of a node contains only nodes with keys less than the node’s key.
    • The Right subtree of a node contains only nodes with keys greater than the node’s key.
    • Both the Left and Right subtrees must also be binary search trees.


    From the above properties it naturally follows that:
    • Each node (item in the tree) has a distinct key.
    */
    public class CheckBST
    {
        public class Node
        {
            public int Data;
            public Node Left, Right;

            public Node(int item)
            {
                Data = item;
                Left = Right = null; 
            }
        }

        public class BinaryTree
        {
            public Node root;

            public virtual bool BST
            {
                get
                {
                    return isBSTUtil(root, int.MinValue, int.MaxValue);
                }
            }

            private bool isBSTUtil(Node node, int min, int max)
            {
                if (node == null)
                {
                    return true;
                }
                if (node.Data < min || node.Data > max)
                {
                    return false;
                }
                return isBSTUtil(node.Left, min, node.Data - 1) && isBSTUtil(node.Right, node.Data + 1, max);
            }
        }

        public void Run()
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(4);
            tree.root.Left = new Node(2);
            tree.root.Right = new Node(5);
            tree.root.Left.Left = new Node(1);
            tree.root.Left.Right = new Node(3);

            if (tree.BST)
            {
                Console.WriteLine("IS BST");
            }
            else
            {
                Console.WriteLine("IS NOT BST");
            }
        }
    }
}
