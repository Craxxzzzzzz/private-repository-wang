using System;
using System.Security.Cryptography.X509Certificates;


namespace BST
{
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

            public void Insert(int newKey, T newValue)
            {
                Node<T> _insert(Node<T> node, int key, T value)
                {
                    if (node == null)
                        return new Node<T>(key, value);

                    if (key < node.Key)
                        node.LeftSon = _insert(node.LeftSon, key, value);

                    else if (key > node.Key)
                        return node;

                    else
                        return node;

                    return node;
                }
                if (Root == null)
                {
                    Root = new Node<T>(newKey, newValue);
                }
                else
                {
                    _insert(Root, newKey, newValue);
                }
            }
            public Node<T> Find(int key)
            {
                Node<T> _find(Node<T> node, int key2)
                {
                    if (node == null)
                        return null;
                    if (key == node.Key)
                        return node;
                    else if (key > node.Key)
                        return _find(node.RightSon, Key);
                    else
                        return _find(node.LeftSon, key);

                }
                return _find(Root, key);
            }

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
            public Node<T> Max()
            {
                return _max(Root);
            }
            private Node<T> _max(Node<T> node)
            {
                if (node.RightSon == null)
                    return node;
                return _max(node.RightSon);
            }

            public Node<T> Min()
            {
                return _min(Root);
            }
            private Node<T> _min(Node<T> node)
            {
                if (node.LeftSon == null)
                    return node;
                return _min(node.LeftSon);
            }
            private Node<T> FindMin(Node<T> node)
            {
                while (node.LeftSon != null)
                    node = node.LeftSon;
                return node;
            }

            public void Delete(int key)
            {
                Node<T> _delete(Node<T> node, int targetKey)
                {
                    if (node == null)
                        return node;
                    if (targetKey < node.Key)
                        node.LeftSon = _delete(node.LeftSon, targetKey);
                    else if (targetKey > node.Key)
                        node.RightSon = _delete(node.RightSon, targetKey);

                    else
                    {
                        if (node.LeftSon == null && node.RightSon == null)
                            return null;
                        if (node.LeftSon == null)
                            return node.RightSon;
                        else if (node.RightSon == null)
                            return node.LeftSon;

                        Node<T> successor = FindMin(node.RightSon);
                        node.Key = successor.Key;
                        node.Value = successor.Value;
                        node.RightSon = _delete(node.RightSon, successor.Key);
                    }
                    return node;
                }

                Root = _delete(Root, key);
            }

            public void DeleteEven()
            {
                void _deleteEven(Node<T> node)
                {
                    if (node == null)
                        return;
                    _deleteEven(node.LeftSon);

                    if (node.Key % 2 == 0)
                    {
                        Delete(node.Key);
                    }
                    _deleteEven(node.RightSon);

                }
                _deleteEven(Root);

            }
        }



        class Student
        {
            public int Id { get; }
            public string FirstName { get; }
            public string LastName { get; }
            public int Age { get; }
            public Student (int id, string firstName, string lastname, int age, string className)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastname;
                Age = age;
                ClassName = className; 

            }
            public override string ToString()
            {
                return string.Format("{0} {1} (ID:{2}) Ze třídy {3}");
            }
        }
    }




}


   