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

            foreach(char zavorka in zavorky)
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
    }
}
