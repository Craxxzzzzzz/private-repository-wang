using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int number = 9; // Vstupní číslo
        Console.WriteLine($"Všechny rozklady čísla {number} na sčítance:");
        FindPartitions(number, new Stack<int>());
    }

    static void FindPartitions(int target, Stack<int> stack)
    {
        if (target == 0)
        {
            // Pokud jsme dosáhli cíle, vypíšeme aktuální rozklad
            Console.WriteLine(string.Join("+", stack));
            return;
        }

        // Začínáme od posledního čísla ve stacku nebo od 1
        int start = stack.Count > 0 ? stack.Peek() : 1;

        for (int i = start; i <= target; i++)
        {
            stack.Push(i); // Přidáme číslo na stack
            FindPartitions(target - i, stack);
            stack.Pop(); // Odebereme číslo (backtracking)
        }
    }
}
