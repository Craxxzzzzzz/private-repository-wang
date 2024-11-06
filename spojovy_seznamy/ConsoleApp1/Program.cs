using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;


class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.Add(3);
            list.Add(6);
            list.Add(4);
            list.Add(5);
            list.Add(7);

        Console.WriteLine("původní LL");
        list.PrintLinkedList();
        list.SortLinkedList();
        Console.WriteLine("\nseřazený LL");
        list.PrintLinkedList();
        }
    }
    class Node
    {
        public Node(int value)
        {
            Value = value;
        }
        public int Value { get; }
        public Node Next { get; set; }
    }
class LinkedList

{
    public Node Head { get; set; }
    public void Add(int value)
    {
        if (Head == null)
            Head = new Node(value);
        else
        {
            Node newNode = new Node(value);
            newNode.Next = Head;
            Head = newNode;

        }
    }
    public bool Find(int value)
    {
        if (Head == null)
            return false;
        Node node = Head;
        while (node != null)
        {
            if (node.Value == value)
                return true;
            node = node.Next;
        }
        return false;

    }
    public void PrintLinkedList()
    {
        Node prvek = Head;
        while (prvek != null) 
        {
            Console.Write(prvek.Value);
            Console.Write(", ");
            prvek = prvek.Next;
        }

    }
    
    public void SortLinkedList()
    {
        if (Head == null)
            return; 

        LinkedList newList = new LinkedList();

        Node current = Head;
        while (current != null)
        {
            newList.InsertSorted(current.Value);
            current = current.Next;
        }

        Head = newList.Head; 
    }

    public void InsertSorted(int value)

    {
        Node newNode = new Node (value);
        if (Head == null || Head.Value >= newNode.Value)
        {
            newNode.Next = Head;
            Head = newNode;
            return;
        }
            
        else
        {
            Node prvek = Head;
            while (prvek != null && prvek.Next.Value < newNode.Value)
            {
                prvek = (Node)prvek.Next;

            }
            newNode.Next = prvek.Next;
            prvek.Next = newNode;

        }

    }
        


}