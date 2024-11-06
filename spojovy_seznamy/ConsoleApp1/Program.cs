using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;


class Program
    {
        static void Main(string[] args)
        {
            LinkedList list1 = new LinkedList();
            list1.Add(3);
            list1.Add(6);
            list1.Add(4);
            list1.Add(5);
            list1.Add(7);

            LinkedList list2 = new LinkedList();
            list2.Add(3);
            list2.Add(6);
            list2.Add(4);
            list2.Add(5);
            list2.Add(7);



        Console.WriteLine("původní LL1");
        list1.PrintLinkedList();

        Console.WriteLine("původní LL2");
        list2.PrintLinkedList();
        
        list1.SortLinkedList();
        list2.SortLinkedList();
        
        Console.WriteLine("\nseřazený LL1");
        list1.PrintLinkedList();
        
        Console.WriteLine("\nseřazený LL2");
        list2.PrintLinkedList();

        LinkedList result = LinkedList.DestruktivniRozdeleni(list1, list2);
        Console.WriteLine("\nDestruktivní rozdělení");
        result.PrintLinkedList();

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
    public static LinkedList DestruktivniRozdeleni (LinkedList list1, LinkedList list2)
        {
            LinkedList result = new LinkedList();
            HashSet<int> set = new HashSet<int>(); // našel jsem na internetu, vůbec nevím co to dělá
            
            Node prvek1 = list1.Head;
            while (prvek1 != null)
            {
                set.Add(prvek1.Value);
                prvek1 = prvek1.Next;
            }

            Node prvek2 = list2.Head;
            Node resultTail = null;

            while (prvek2 != null)
            {
                if (set.Contains(prvek2.Value))
                {
                    set.Remove(prvek2.Value);

                    Node newNode = new Node (prvek2.Value);

                    if (result.Head == null)
                    {
                        result.Head = newNode;
                        resultTail = newNode; // nový pointer co ukazuje nový list, můžeme přidávat nový node na konci výsledku
                    }

                    else
                    {
                        resultTail.Next = newNode;
                        resultTail = resultTail.Next;
                    }
                }
                prvek2 = prvek2.Next;
            }
            return result;
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
                prvek = prvek.Next;

            }
            newNode.Next = prvek.Next;
            prvek.Next = newNode;

        }

    }
}
