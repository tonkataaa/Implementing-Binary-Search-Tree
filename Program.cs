public class Node
{
    public int Value { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinarySearchTree
{
    public Node? Root { get; set; }

    public BinarySearchTree()
    {
        Root = null;
    }

    public void Insert(int value)
    {
        Node newNode = new Node(value);

        if (Root == null)
        {
            Root = newNode;
            return;
        }

        Node current = Root;

        while (true)
        {
            if (value < current.Value)
            {
                if (current.Left == null)
                {
                    current.Left = newNode;
                    return;
                }
                current = current.Left;
            }
            else if (value > current.Value)
            {
                if (current.Right == null)
                {
                    current.Right = newNode;
                    return;
                }
                current = current.Right;
            }
            else
            {
                return;
            }
        }
    }

    public Node? Lookup(int value)
    {
        //TODO
        return null;
    }

    //Remove
}



