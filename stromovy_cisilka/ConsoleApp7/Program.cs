using System.Collections.Specialized;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte příklad v postfixu");
            string equation = Console.ReadLine();
            ExpresionTree stromecek = new ExpresionTree(equation);
            Console.WriteLine("postfix: " + stromecek.ShowPostfix());
            Console.WriteLine("prefix: " + stromecek.ShowPrefix());
            Console.WriteLine("infix: " + stromecek.ShowInfix());

                
        }
    }
    class ExpresionTree
    {
        public ExpresionTree(string equation)
        {
            string[] list = equation.Split(" ");
            Stack<Node> stack = new Stack<Node>();
            for (int i = 0; i < list.Length; i++)
            {
                if (float.TryParse(list[i], out float number))
                {
                    Node node = new Node(list[i]);
                    stack.Push(node);
                }
                else
                {
                    Node node = new Node(list[i]);
                    node.RightSon = stack.Pop();
                    node.LeftSon = stack.Pop();
                    stack.Push(node);
                }

            }

            root = stack.Pop();

        }
         private Node root { get; }

        public string ShowPostfix()
        {
            StringBuilder sb = new StringBuilder();
            void showPostfix(Node node)
            {
                if (node.LeftSon == null ) /// je to list, tady jenom čísla
                {
                    sb.Append(node.Symbol + " ");

                }
                else /// tady znaménka
                {
                    showPostfix(node.LeftSon);

                    showPostfix(node.RightSon);

                    sb.Append(node.Symbol + " ");

                }
            }
            showPostfix(root);
            return sb.ToString();
        }
        public string ShowPrefix()
        {
            StringBuilder sb = new StringBuilder();
            void showPrefix(Node node)
            {
                if (node == null) /// je to list, tady jenom čísla
                {
                    return;

                }
                sb.Append(node.Symbol + " ");
                showPrefix(node.LeftSon);
                showPrefix(node.RightSon);

            }
            showPrefix(root);
            return sb.ToString();
        }

        public string ShowInfix()
        {
            StringBuilder stringBuilder = new StringBuilder();
            void showInfix(Node node)
            {
                if (node.LeftSon != null) stringBuilder.Append("(");
                showInfix(node.LeftSon);
                stringBuilder.Append(node.Symbol);
                showInfix(node.RightSon);
                if (node.RightSon != null) stringBuilder.Append(")");
            }
            showInfix(root);
            return stringBuilder.ToString();
        }
        
    }
    class Node
    {
        public Node(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; }

        public Node LeftSon { get; set; }
        public Node RightSon { get; set; }
    }
}
