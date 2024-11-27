namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var friendships = Console.ReadLine().Split(" ");
            var goalFriend = Console.ReadLine().Split(); // rozdělí text na řetězce mezerou, int.Parse převádí řetězec na celé číslo, .ToArray = typ proměnné "goalFriend" je odovozen jako int ==> ukládá do pole

            int start = int.Parse(goalFriend[0]); 
            int end = int.Parse(goalFriend[1]);

            var graph = new Dictionary<int, List<int>>(); // vytváří graf
            for (int i = 0; i < number + 1; i++)
            {
                graph[i] = new List<int>(); // každý prvek v grafu bude mít list přátel (zatím prázdný)
            }

            foreach (var edge in friendships) // prochází hrany v friendships
            {
                var nodes = edge.Split("-").Select(int.Parse).ToArray(); // rozdělí řetězec hran na dvě části podle znaku "-", každý řetězec převede na celé číslo, převede výsledek na pole
                int u = nodes[0], v = nodes[1]; // zapisuje čísla(uzly) do proměnných

                graph[u].Add(v); // přidává čísla do druhého uzlu 
                graph[v].Add(u);
            }

            var path = FindPathBFS(graph, start, end); // vyhledává cestu pomocí BFS
            if (path == null)
            {
                Console.WriteLine("neexistuje");
            }
            else
            {
                Console.WriteLine(string.Join(" ", graph));
            }
        }

        static List<int> FindPathBFS(Dictionary<int, List<int>> graph, int start, int end) //vrací nám seznam čísel, která bude obsahovat uzly. Graph je slovníkem, kde klíče jsou čísla. "start" index odkud začne hledat cestu a "end" = index uzlu, ke kterému chceme najít cestu
        {
            var queue = new Queue<List<int>>(); // kolekce, používa FIFO (first in first out), každý prvek, který bude uložen ve frontě bude seznamen celých čísel
            var visited = new HashSet<int>(); // zanechává neduplikáty, bude obsahovat celá čísla

            queue.Enqueue(new List<int> { start }); //přidává prvek na konci fronty. Přidáváme do fronty nový seznam, který obsahuje počáteční uzel
            visited.Add(start); // uchovává všechny uzly které již navštívil, přidá do "visited" "start" => nebudu už tenhle uzel zkoumat

            while (queue.Count > 0) // bude se provádět smyčka do té doby než bude queue prázdný
            {
                var currentPath = queue.Dequeue(); 
                int currentNode = currentPath.Last(); //current node je posledním uzlem ve currenPathu -> current node je uzel, který právě zpracováváme

                if (currentNode == end) // jestli current node je tím co hledáme tak to vrací tento uzel
                {
                    return currentPath;
                }

                foreach (var neighbour in graph[currentNode]) //prochází sousední uzly uzlu currentNode
                {
                    if (!visited.Contains(neighbour)) // kontroluje jestli sousední uzel už byl navšítvenej, pokud už byl přidáváme ho do skupiny "visited"
                    {
                        visited.Add(neighbour); // pokud už byl přidáváme ho do skupiny "visited"
 
                        var newPath = new List<int>(currentPath) { neighbour }; // kopie předešlé cesty ale na konci se přidává "neighbor"
                        queue.Enqueue(newPath); // nový seznam dáváme do fronty
                    }

                }
            }
            return null;
        }
    }
}
