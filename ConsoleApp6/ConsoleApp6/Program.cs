using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ExceptionServices;

namespace connect4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int player = 1;
            int winReq = 4;
            int[] position = { 5, 0 };

            int[,] board = new int[6, 7]{
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 2, 1, 0 },
                { 2, 2, 2, 2, 2, 1, 0 }
            };

            Check(player, board, winReq, position);
        }

        static bool Check(int player, int [,] field, int winReq, int[] curPosition)
        {
            return column(player, field, winReq, curPosition) || row(player, field, winReq, curPosition) || diagonal(player, field, winReq, curPosition);
        }
        static bool column(int numPlayer, int[,] field, int winReq, int[] curPosition)
        {
            int row = curPosition[0];
            int col = curPosition[1];
            int count = 0;
            int rows = field.GetLength(0);

            for (int i = row; i < rows; i++)
                if (numPlayer == field[i + 1, col])
                    count++;
                else break;

            return count >= winReq;

        }
        static bool row(int numPlayer, int[,] field, int winReq, int[] curPosition)
        {
            int row = curPosition[0];
            int col = curPosition[1];
            int count = 0;
            int cols = field.GetLength(1);


            for (int i = col; i >= 0; i--)
                if (field[row, i] == numPlayer)
                    count++;
                else break;

            for (int i = col + 1; i <= cols; i++)
                if (field[row, i] == numPlayer)
                    count++;
                else break;

            return count >= winReq;

        }
        static bool diagonal(int numPlayer, int[,] field, int winReq, int[] curPosition)
        {
            return rightDiagonal(numPlayer, field, winReq, curPosition) || leftDiagonal(numPlayer, field, winReq, curPosition);
        }
        static bool rightDiagonal(int numPlayer, int[,] field, int winReq, int[] curPosition)
        {
            int row = curPosition[0];
            int col = curPosition[1];
            int count = 0;
            int cols = field.GetLength(1);
            int rows = field.GetLength(0);

            for (int i = row ; i>= 0; i--)
            {
                for (int j = col; j >= cols; j++)
                {
                    if (field[i, j] == numPlayer)
                        count++;
                    else break;
                }
            }

            for (int i = row + 1; i >= rows; i++)
                for (int j = col - 1 ; j >= 0; j--)
                {
                    if (field[i, j] == numPlayer)
                        count++;
                    else break;
                }


            return count >= winReq;
        }

        static bool leftDiagonal(int numPlayer, int[,] field, int winReq, int[] curPosition)
        {
            int row = curPosition[0];
            int col = curPosition[1];
            int count = 0;
            int cols = field.GetLength(1);
            int rows = field.GetLength(0);

            for (int i = row; i >= 0; i--)
            {
                for (int j = col; j >= 0; j--)
                {
                    if (field[i, j] == numPlayer)
                        count++;
                    else break;
                }
            }

            for (int i = row + 1; i >= rows; i++)
                for (int j = col - 1; j <= cols; j++)
                {
                    if (field[i, j] == numPlayer)
                        count++;
                    else break;
                }

            return count >= winReq;
        }

    }
}
