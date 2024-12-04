using System;
using System.Collections.Generic;
using System.Linq;


namespace zasobnik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] Ochars = { '(', '{', '[' };
            char[] Zchars = { ')', '}', ']' };

            Console.WriteLine("Zadejte soubor závorek");

            string zavorky = Console.ReadLine();

            Stack<char> zasobnik = new Stack<char>();

            bool spravne = true;

            foreach (char zavorka in zavorky)
            {
                if (Ochars.Contains(zavorka))
                {
                    zasobnik.Push(zavorka);
                }
                else if (Zchars.Contains(zavorka))
                {
                    if (zasobnik.Peek() == Ochars[Array.IndexOf(Zchars, zasobnik)])
                    {
                        zasobnik.Pop();
                    }
                    else
                    {
                        Console.WriteLine("Je to špatný seznam závorek");
                        spravne = false;
                        break;

                    }
                }
            }

            if (spravne == true)
            {
                Console.WriteLine("Závorky jsou správně");
            }
        }
        static void soucet(string[] args)
        {
            Console.WriteLine("Zadejte číslo");
            
            string cislo = Console.ReadLine();
            
            int number = int.Parse(cislo);

            Stack<int> seznam = new Stack<int>(); 
                
        }
        static void Findnumber (int number, Stack<int> seznam)
        {
            if (number == 0)
            {
                Console.WriteLine(string.Join("+", seznam));
                return ;
            }

            int start = seznam.Count > 0 ? seznam.Peek() : 1;

            for (int i = start; i < number; i++)
            {
                seznam.Push(i);
                Findnumber(number - 1, seznam);
                seznam.Pop();
            }

        }
    }
}
