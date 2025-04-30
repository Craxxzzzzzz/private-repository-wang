using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace cisilka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Postfix (1) or Prefix (2)?");
            int version = int.Parse(Console.ReadLine());


            Console.WriteLine("Zadejte příklad");
            string equation = Console.ReadLine();

            if (version == 1)
            {
                Postfix calulator = new Postfix();
                try
                {
                    float vysledek = calulator.Calculate(equation);
                    Console.WriteLine("Váš výsledek je " + vysledek);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("chyba!");
                }
            }
            else if (version == 2)
            {
                Prefix calulaor = new Prefix();

                try
                {
                    float vysledek = calulaor.Calculate(equation);
                    Console.WriteLine("Výsledek je " + vysledek);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("dělíš nulou");
                }
            }
        }
    }

    class Prefix
    {
        public float Calculate(string equation)
        {
            string[] list = equation.Split(" ");
            Stack<float> stack = new Stack<float>();
            
            for (int i = list.Length - 1; i >= 0; i--)
            {

                if (float.TryParse(list[i], out float number))
                {
                    stack.Push(number);
                    continue;
                }
                char ch = list[i][0];
                switch (ch)
                {
                    case '*':
                        float number1 = stack.Pop();
                        float newNum = number1 * stack.Pop();

                        stack.Push(newNum);
                        break;

                    case '/':
                        float number2 = stack.Pop();
                        if (stack.Peek() == 0)
                        {
                            throw new DivideByZeroException("Dělíš nulou!");
                        }
                        stack.Push(number2 / stack.Pop());

                        break;

                    case '+':
                        float number3 = stack.Pop();
                        stack.Push(stack.Pop() + number3);
                        break;

                    case '-':
                        float number4 = stack.Pop();
                        stack.Push(number4 - stack.Pop());
                        break;
                }
            }

            if (stack.Count != 1)
            {
                throw new InvalidOperationException("chyba");
            }

            return stack.Pop();
        }
    }

    class Postfix
    {
        public float Calculate(string equation)
        {

            string[] list = equation.Split(" ");

            Stack<float> stack = new Stack<float>();

            for (int i = 0; i < list.Length; i++)
            {
                if (float.TryParse(list[i], out float number))
                {
                    stack.Push(number);
                }
                else
                {
                    char ch = list[i][0];
                    switch (ch)
                    {
                        case '*':
                            float number1 = stack.Pop();
                            float newNum = number1 * stack.Pop();

                            stack.Push(newNum);
                            break;

                        case '/':
                            float number2 = stack.Pop();
                            if (number2 == 0)
                            {
                                throw new DivideByZeroException("Dělíš nulou!");
                            }
                            stack.Push(stack.Pop() / number2);
                            break;

                        case '+':
                            float number3 = stack.Pop();
                            stack.Push(stack.Pop() + number3);
                            break;

                        case '-':
                            float number4 = stack.Pop();
                            stack.Push(stack.Pop() - number4);
                            break;

                    }
                }
            }
            if (stack.Count != 1)
            {
                Console.WriteLine("Chyba!");
            }

            return stack.Pop();
        }
    }
}
