using System.ComponentModel.Design;
using System.Data;
using System.Runtime.ExceptionServices;

namespace connect4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        static bool Check(int numPlayers, int [,] field, int winReq, int[] curPosition)
        {
            return column(numPlayers, field, winReq, curPosition) || row(numPlayers, field, winReq, curPosition) || diagonal(numPlayers, field, winReq, curPosition);
        }

        static bool column(int numPlayer, int[,] field, int winReq, int[] curPosition)
        {
            FirstRowUnder(int[,] field, int winReq, int[] curPosition);
        }
        bool FirstRowUnder(int[,] field, int winReq, int[] curPosition)
        {
            int row = curPosition[0];
            int col = curPosition[1];
            int value = field[row, col];
            int valueUnder = field[row + 1, col];
            int count = 1;
            int totalRows = field.GetLength(0);

            if (value == valueUnder)
            {
                count++;

                if (count >= winReq)
                    return true;

                row = row + 1;

                if (row >= totalRows)
                    return false;

                return FirstRowUnder(field, winReq,curPosition);
            }
            else
                return false;
        }
        static bool row(int numPlayer, int[,] field, int winReq, int[] curPosition)
        {

        }

        static bool diagonal(int numPlayer, int[,] field, int winReq, int[] curPosition)
        {

        }
    }
}
