using System;


namespace BST
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Node<string> node1 = new Node<string>(1, "Čau");
            Node<string> node2 = new Node<string>(2, "Zdravím");
            Node<string> node3 = new Node<string>(3, "Ahoj");

            node1.LeftSon = node2;
            node1.RightSon = node3;

            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            tree.Root = node1;

            Console.WriteLine(tree.Show());
            Console.WriteLine(tree.Find(2));
        }
    }

    class Node<T>
    {
        public int Key { get; set; }
        public T Value { get; set; }

        public Node<T> LeftSon { get; set; }
        public Node<T> RightSon { get; set; }

        public Node(int key, T value)
        {
            Key = key;
            Value = value;
        }
    }
    class BinarySearchTree<T>
    {
        public Node<T> Root { get; set; }

        public string Show()
        {
            string output = "";
            void _show(Node<T> node)
            {
                if (node == null)
                    return;
                _show(node.RightSon);

                output += node.Key.ToString() + " ";

                _show(node.LeftSon);


            }

            if (Root == null)
                return "Strom je prázdný";
            _show(Root);
            return output;

        }

        public T Find(int key)
        {
            Node<T> _find(Node<T> node, int key2)
            {
                if (node == null)
                    return null;
                if (node.Key == key)
                    return node;
                if (key2 < node.Key)
                    return _find(node.LeftSon, key2);
                else
                    return _find(node.RightSon, key2);
            }
            return _find(Root, key).Value;

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            // odtud by mělo být přístupné jen to nejdůležitější, žádné vnitřní pomocné implementace.
            // Strom a jeho metody mají fungovat jako černá skříňka, která nám nabízí nějaké úkoly a my se nemusíme starat o to, jakým postupem budou splněny.
            // rozhodně také nechceme mít možnost datovou stukturu nějak měnit jinak, než je dovoleno (třeba nějakým jiným způsobem moct přidat nebo odebrat uzly, aniž by platili invarianty struktury)

            BinarySearchTree<Student> tree = new BinarySearchTree<Student>();

            // čteme data z CSV souboru se studenty (soubor je uložen ve složce projektu bin/Debug u exe souboru)
            // CSV je formát, kdy ukládáme jednotlivé hodnoty oddělené čárkou
            // v tomto případě: Id,Jméno,Příjmení,Věk,Třída
            using (StreamReader streamReader = new StreamReader("studenti_shuffled.csv"))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    string[] studentData = line.Split(',');

                    Student student = new Student(
                        Convert.ToInt32(studentData[0]),    // Id
                        studentData[1],                     // Jméno
                        studentData[2],                     // Příjmení
                        Convert.ToInt16(studentData[3]),    // Věk
                        studentData[4]);                    // Třída

                    // vložíme studenta do stromu, jako klíč slouží jeho Id
                    tree.Insert(student.Id, student);
                    line = streamReader.ReadLine();
                }
            }
            Console.WriteLine(tree.Find(20).Value);

        }

    }
}

