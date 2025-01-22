namespace algoritmy_hledani_cesy
{

    using System;

    class Dijkstra
    {
        public static int[] FindShortestPaths(int[,] graph, int source)
        {
            int verticesCount = graph.GetLength(0);
            int[] distances = new int[verticesCount]; // Nejkratší vzdálenosti od zdroje
            bool[] visited = new bool[verticesCount]; // Sledování navštívených vrcholů

            // Inicializace: nastavení všech vzdáleností na nekonečno a vrcholů jako nenavštívených
            for (int i = 0; i < verticesCount; i++)
                distances[i] = int.MaxValue;

            distances[source] = 0; // Vzdálenost zdroje k sobě samému je 0

            for (int i = 0; i < verticesCount - 1; i++)
            {
                int u = MinDistance(distances, visited); // Najdi nejbližší nenavštívený vrchol
                visited[u] = true; // Označ vrchol jako navštívený

                // Aktualizuj vzdálenosti sousedních vrcholů
                for (int v = 0; v < verticesCount; v++)
                {
                    if (!visited[v] && graph[u, v] != 0 && distances[u] != int.MaxValue &&
                        distances[u] + graph[u, v] < distances[v])
                    {
                        distances[v] = distances[u] + graph[u, v];
                    }
                }
            }

            return distances; // Vrať pole vzdáleností
        }

        private static int MinDistance(int[] distances, bool[] visited)
        {
            int min = int.MaxValue, minIndex = -1;

            // Najdi nejbližší nenavštívený vrchol
            for (int i = 0; i < distances.Length; i++)
            {
                if (!visited[i] && distances[i] < min)
                {
                    min = distances[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }


    class FloydWarshall
        {
            public static int[,] FindShortestPaths(int[,] graph)
            {
                int n = graph.GetLength(0); // Počet vrcholů
                int[,] distances = (int[,])graph.Clone(); // Klonování grafu do matice vzdáleností

                // Procházení všech trojic vrcholů (k, i, j)
                for (int k = 0; k < n; k++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            // Pokud je cesta přes k kratší, aktualizuj vzdálenost mezi i a j
                            if (distances[i, k] != int.MaxValue && distances[k, j] != int.MaxValue &&
                                distances[i, k] + distances[k, j] < distances[i, j])
                            {
                                distances[i, j] = distances[i, k] + distances[k, j];
                            }
                        }
                    }
                }

                return distances; // Vrať matici nejkratších vzdáleností
            }
        }

}

