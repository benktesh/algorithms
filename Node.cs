namespace algorithms
{
    public class Node
    {
        public Node Left;
        public Node Right;
        public int Data;

        public Node(int data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
