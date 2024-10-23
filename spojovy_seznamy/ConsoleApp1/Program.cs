using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;


class Program
    {
        static void Main(string[] args)
        {
            Node uzlik = new Node(8);
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
    public LinkedList()
    {

    }
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
        LinkedList newList = new LinkedList();
        newList.Head = new Node (Head.Value);
        if (Head != null)
        {
            Node prvek = Head.Next;
            while (prvek != null)
            {
                newList.InsertSorted(prvek.Value);
                prvek = prvek.Next;
            }
        }       
    }
    public void InsertSorted(int value)
    {
        if (Head == null)
            Head = new Node(value);
        else
        {
            Node prvek = Head;
            while (prvek != null)
            {
                if (prvek.Value < Value)
                    if (prvek.Next != null)
                        prvek = prvek.Next;
                    else
                        break;
                else
                    break;

            }
            if (prvek != null)
            {
                Node newNode = new Node(value);
                newNode.Next = prvek.Head;
                prvek.Next = newNode;
            }

        }

    }
        


}