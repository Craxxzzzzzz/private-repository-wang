using System;
using System.Collections.Generic;

namespace spammovani_na_minimum
{
    class Program
    {
        static void Main()
        {
            // Čteme počet studentů
            int n = int.Parse(Console.ReadLine());

            // Inicializace matice grafu
            int[,] graph = new int[n, n];
            List<string> studentNames = new List<string>();

            // Čtení matice vzdáleností (grafu)
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    graph[i, j] = int.Parse(line[j]);  // Naplnění matice vzdálenostmi
                }
            }

            // Čtení seznamu jmen studentů
            studentNames.AddRange(Console.ReadLine().Split(';'));

            // Čteme jméno počátečního studenta
            int start = studentNames.IndexOf(Console.ReadLine().Trim());

            // Zavoláme Dijkstrův algoritmus
            var usedEdges = Dijkstra(graph, start, n);

            // Výstupní matice - zobrazení, které hrany byly použity
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(usedEdges[i, j] ? "1 " : "0 ");  // Pokud hrana byla použita, vypíše 1, jinak 0
                }
                Console.WriteLine();  // Přechod na nový řádek pro každou řadu
            }
        }

        // Dijkstrův algoritmus pro nalezení nejkratších cest
        static bool[,] Dijkstra(int[,] graph, int start, int n)
        {
            int[] dist = new int[n];  // Pole pro vzdálenosti
            bool[] visited = new bool[n];  // Pole pro sledování navštívených studentů
            bool[,] usedEdges = new bool[n, n];  // Matice pro sledování použitých hran

            // Inicializace vzdáleností na "nekonečno"
            for (int i = 0; i < n; i++) dist[i] = int.MaxValue;
            dist[start] = 0;  // Počáteční vzdálenost je 0

            // Hlavní cyklus Dijkstrova algoritmu
            for (int count = 0; count < n; count++)
            {
                // Výběr studenta s minimální vzdáleností, který ještě nebyl navštíven
                int u = -1;
                for (int i = 0; i < n; i++)
                    if (!visited[i] && (u == -1 || dist[i] < dist[u])) u = i;

                // Pokud již není možné zpracovávat vzdálenosti, ukončujeme
                if (dist[u] == int.MaxValue) break;

                visited[u] = true;  // Označení studenta jako navštíveného

                // Relaxace hran (aktualizace vzdáleností sousedních studentů)
                for (int v = 0; v < n; v++)
                    if (graph[u, v] != -1 && !visited[v] && dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];  // Aktualizace vzdálenosti
                        usedEdges[u, v] = true;  // Označení použité hrany
                    }
            }

            return usedEdges;  // Vrátíme matici použitých hran
        }
    }
}

