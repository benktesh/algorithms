using System;
namespace algorithms
{

    public class IdentiticalTree
    {
        public static bool IdenticalTrees(Node a, Node b)
        {
            //if both empty
            if (a == null && b == null)
            {
                return true;
            }

            //if none empty, then compare
            if (a != null && b != null)
            {
                return (a.data == b.data
                    && IdenticalTrees(a.left, b.left)
                        && IdenticalTrees(a.right, b.right));
            }

            //if one is empty and other is not then return
            return false;
        }


        public static void RunMe()
        {
            BinaryTree tree = new BinaryTree();

            tree.root1 = new Node(1);
            tree.root1.left = new Node(2);
            tree.root1.right = new Node(3);
            tree.root1.left.left = new Node(4);
            tree.root1.left.right = new Node(5);

            tree.root2 = new Node(1);
            tree.root2.left = new Node(2);
            tree.root2.right = new Node(3);
            tree.root2.left.left = new Node(4);
            tree.root2.left.right = new Node(5);

            //must be identical
            Console.WriteLine("Are Identical: " + IdenticalTrees(tree.root1, tree.root2));

            Print(tree.root1);
           // Print(tree.root2);

            //Console.WriteLine("Are Identical: " + IdenticalTrees(tree.root1.right, tree.root2));


        }


        public static void Print(Node a)
        {
           if(a == null)
            {
                return;
            }

            Console.Write(a.data + " ");

            Print(a.left);
            Print(a.right);   
        }




    }
}
