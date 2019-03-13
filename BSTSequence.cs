using System;
using System.Collections.Generic;

namespace algorithms
{
    public class BstSequence
    {
        public List<Node> ConstructTrees(int start, int end)
        {
            var list = new List<Node>();

            if (start > end)
            {
                list.Add(null);
                Console.WriteLine($"{start},{end}->{string.Join(' ', list)}");
                return list;
            }

            for (var i = start; i <= end; i++)
            {
                var lSubTree = ConstructTrees(start, i - 1);
                var rSubTree = ConstructTrees(i+1, end);

                foreach (var left in lSubTree)
                {
                    foreach (var right in rSubTree)
                    {
                        var node = new Node(i) {Left = left, Right = right};
                        list.Add(node);
                    }
                }
            }

            
            Console.WriteLine($"{start},{end}->{string.Join(' ', list)}");
            return list;
        }

        public void PreOrder(Node root)
        {
            if (root != null)
            {
                Console.Write(root.Data + " ");
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }

        public void Run()
        {
            var totalTree = ConstructTrees(1, 3);
            foreach (var t in totalTree)
            {
                PreOrder(t);
                Console.WriteLine();
            }
        }

    }
}
