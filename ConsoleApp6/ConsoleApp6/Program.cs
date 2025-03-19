using System.Data;

namespace connect4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static bool Check(int numPlayers, int [,] field, int winReq, int[] curPosition)
        {
            return column(numPlayers, field, winReq, curPosition) || row(numPlayers, field, winReq, curPosition) || diagonal(numPlayers, field, winReq, curPosition);
        }

        static bool column(int numPlayer, int[,] field, int winReq, int[] curPosition)
        {
            int positionColumn = field.GetLength(curPosition[0]);
            int positionRow = field.GetLength(curPosition[1]);

            static int FirstRowUnder(int positionRow, int positionColumn)
            {
                int value = field[positionColumn, positionRow];

                if 

                    return true;
                else
                    return false;
            }
        }

        static bool row(int numPlayer, int[,] field, int winReq, int[] curPosition)
        {

        }

        static bool diagonal(int numPlayer, int[,] field, int winReq, int[] curPosition)
    }
}
