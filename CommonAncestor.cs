using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public class CommonAncestor
    {
        public class Node
        {
            public Node Left;
            public Node Right;
            public int Data;

            public Node(int value)
            {
                Data = value;
            }

            public override string ToString()
            {
                return Data + " ";
            }
        }

        public class Result
        {
            public Node Node;
            public bool IsAncestor;

            public Result(Node node, bool isAncesotr)
            {
                Node = node;
                IsAncestor = isAncesotr;
            }

        }

        public Node FindCommonAncestor(Node root, Node p, Node q)
        {
            Result r = ComonAncestorHelper(root, p, q);
            if (r.IsAncestor)
            {
                return r.Node;

            }
            return null;
        }

        public Result ComonAncestorHelper(Node root, Node p, Node q)
        {
            if (root == null)
            {
                return new Result(root, false);
            }

            if (root == p && root == q)
            {
                return new Result(root, true);
            }

            Result rx = ComonAncestorHelper(root.Left, p, q);
            if (rx.IsAncestor)
            {
                return rx;
            }

            Result ry = ComonAncestorHelper(root.Right, p, q);
            if (ry.IsAncestor)
            {
                return ry;
            }

            if (rx.Node != null && ry.Node != null)
            {
                return new Result(root, true);
            }
            else
            {
                if (root == p || root == q)
                {
                    bool isAncestor = rx.Node != null || ry.Node != null;
                    return new Result(root, isAncestor);
                }
                else
                {
                    return new Result(rx.Node != null ? rx.Node : ry.Node, false);
                }
            }
        }

        public class BinaryTree
        {
            public Node Root;
        }
        public void Run()
        {
            BinaryTree tree = new BinaryTree();
            tree.Root = new Node(4);

            tree.Root.Left = new Node(2);

            tree.Root.Right = new Node(5);



           // tree.Root.Left.Left = new Node(1);
           // tree.Root.Left.Right = new Node(3);

            var p = tree.Root.Left;
            var q = tree.Root.Right;

            var x = FindCommonAncestor(tree.Root, p, q);
            Console.Write(x.ToString());
        }
    }
}
