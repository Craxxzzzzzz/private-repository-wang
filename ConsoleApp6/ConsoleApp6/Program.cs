using System;
using System.Collections.Generic;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Počet hráčů: ");
            int playerCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Šířka pole: ");
            int gameWidth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Výška pole: ");
            int gameHeight = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Počet tokenů k výhře: ");
            int winReq = Convert.ToInt32(Console.ReadLine());

            Game game = new Game(gameHeight, gameWidth, winReq, playerCount);
            game.Start();
        }
    }

    class Game
    {
        private Board board;
        private List<string> players;
        private int currentPlayer;

        public Game(int rows, int cols, int winReq, int playerNum)
        {
            board = new Board(rows, cols, winReq);
            for (int i = 0; i == playerNum; i++)
            {
                players.Add(((char)('A' + i)).ToString()); //Podle abecedy přidává ke každému hráči své vlastní písmeno
            }
            if (playerNum == 0 || rows == 0 || cols == 0 || winReq == 0) 
            {
                Console.WriteLine("Chybný zadání");
            }
            
            
            currentPlayer = 0;
        }

        public void Start()
        {
            while (true)
            {
                board.Print();
                Console.WriteLine("Hráč " + players[currentPlayer] +  ", zadej sloupec (0-" + (board.Cols - 1) +  "):");

                if (int.TryParse(Console.ReadLine(), out int col) && board.validMove(col)) // tryparse vraci nejenom cislo prevedeny na int ale i jestli true nebo false
                {
                    board.MakeMove(col, players[currentPlayer]);
                    if (board.CheckWin(players[currentPlayer]))
                    {
                        board.Print();
                        Console.WriteLine($"Hráč {players[currentPlayer]} vyhrál!");
                        break;
                    }
                    if (board.IsFull())
                    {
                        board.Print();
                        Console.WriteLine("Remíza!");
                        break;
                    }
                    currentPlayer = (currentPlayer + 1) % players.Count;
                }
                else
                {
                    Console.WriteLine("Neplatný tah, zkuste to znovu.");
                }
            }
        }
    }

    class Board
    {
        private string[,] grid;
        public int Rows { get; } // tento value nemuzeme menit jenom se podivat
        public int Cols { get; }
        private int winReq;

        public Board(int rows, int cols, int winReq) // vytvarime novy board 
        {
            Rows = rows;
            Cols = cols;
            this.winReq = winReq;
            grid = new string[rows, cols];
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                    Console.Write(grid[i, j] ?? "." + " ");
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', Cols * 2));
        }

        public bool validMove(int col)
        {
            if (col>=0 && Cols>=col && grid[0, col] == null)
                return true;
            return false;
        }

        public void MakeMove(int col, string symbol)
        {
            for (int row = Rows - 1; row >= 0; row--)
            {
                if (grid[row, col] == null)
                {
                    grid[row, col] = symbol;
                    break;
                }
            }
        }

        public bool IsFull()
        {
            foreach (var cell in grid)
                if (cell == null) return false;
            return true;
        }

        public bool CheckWin(string symbol)
        {
            return CheckDirection(symbol, 1, 0) || CheckDirection(symbol, 0, 1) ||
                   CheckDirection(symbol, 1, 1) || CheckDirection(symbol, 1, -1);
        }

        private bool CheckDirection(string symbol, int dRow, int dCol)
        {
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Cols; col++)
                {
                    int count = 0;
                    for (int i = 0; i < winCondition; i++)
                    {
                        int newRow = row + i * dRow;
                        int newCol = col + i * dCol;
                        if (newRow < 0 || newRow >= Rows || newCol < 0 || newCol >= Cols || grid[newRow, newCol] != symbol)
                            break;
                        count++;
                    }
                    if (count == winCondition) return true;
                }
            return false;
        }
    }
}
