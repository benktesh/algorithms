using System;
namespace algorithms
{
    public class KLeafBinaryTree
    {
        public KLeafBinaryTree()
        {

        }

        public static void KDistanceFromLeaf(Node node, int[] path,
        bool[] visited, int pathLen, int k)
        {
            if (node == null)
            {
                return;
            }

            path[pathLen] = node.data;
            visited[pathLen] = false;
            pathLen++;

            if (node.left == null && node.right == null
             && pathLen - k - 1 >= 0 && visited[pathLen - k - 1] == false)
            {
                Console.Write(path[pathLen - k - 1] + " ");
                visited[pathLen - k - 1] = true;
            }

            KDistanceFromLeaf(node.left, path, visited, pathLen, k);
            KDistanceFromLeaf(node.right, path, visited, pathLen, k);


        }


        public static void RunMe()
        {
            BinaryTree tree = new BinaryTree();

            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(6);
            tree.root.right.right = new Node(7);
            tree.root.right.left.right = new Node(8);

            int[] path = new int[1000];
            bool[] visited = new bool[1000];
            int k = 1;
            KDistanceFromLeaf(tree.root, path, visited, 0, k);

        }
    }
}
