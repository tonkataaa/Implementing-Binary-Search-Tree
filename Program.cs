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
        Node current = Root;

        while (current != null)
        {
            var comparison = value.CompareTo(current.Value);

            if (comparison > 0)
            {
                current = current.Right;
            }
            else if (comparison < 0)
            {
                current = current.Left;
            }
            else
            {
                return current;
            }
        }

        return null;
    }

    //Delete
    public void Delete(int value)
    {
        Node current = Root;
        Node parent = null;

        while (current != null && current.Value != value)
        {
            parent = current;
            if (value < current.Value)
            {
                current = current.Left;

            }
            else
            {
                current = current.Right;
            }
        }

        if (current == null) 
        { 
            return;
        }

        //First case: Node without childs
        if (current.Left == null && current.Right == null)
        {
            if (parent == null)
            {
                Root = null;
            }
            else if (parent.Left == current)
            {
                parent.Left = null;
            }
            else
            {
                parent.Right = null;
            }
        }
        //Second case: Node with one child
        else if (current.Left == null || current.Right == null)
        {
            Node child = (current.Left != null) ? current.Left : current.Right!;

            if (parent == null)
            {
                Root = child;
            }
            else if (parent.Left == current)
            {
                parent.Left = child;
            }
            else
            {
                parent.Right = child;
            }
        }
        //Third case: Node with two children
        else
        {
            Node successorParent = current;
            Node successor = current.Right!;
            while (successor.Left != null)
            {
                successorParent = successor;
                successor = successor.Left;
            }

            current.Value = successor.Value;

            if (successorParent.Left == successor)
            {
                successorParent.Left = successor.Right;

            }
            else
            {
                successorParent.Right = successor.Right;
            }
        }
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        BinarySearchTree tree = new BinarySearchTree();

        tree.Insert(32);
        tree.Insert(29);
        tree.Insert(66);
        tree.Insert(65);
        tree.Insert(84);
        tree.Insert(69);
        tree.Insert(85);
        tree.Insert(28);
        tree.Insert(30);

        Console.WriteLine(tree.Lookup(29) != null ? "Found 29" : "Not found");

        
        Console.WriteLine(tree.Lookup(30) != null ? "Found 30" : "Not found");
        tree.Delete(30);
        Console.WriteLine(tree.Lookup(30) != null ? "Found 30" : "Not found");

    }
}




