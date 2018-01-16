using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Distance_in_Labyrinth
{
    class Program
    {
        static bool IsInBounds(int row, int col, int size)
        {
            if (row >= 0 && row < size && col >= 0 && col < size)
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char [,] matrix = new char[n,n];
            int startRow = -1;
            int startCol = -1;

            for (int i = 0; i < n; ++i)
            {
                char[] lineOfChars = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; ++j)
                {

                    if (lineOfChars[j] == '*')
                    {
                        startCol = j;
                        startRow = i;
                    }
                    else if (lineOfChars[j] == '0')
                    {
                        matrix[i, j] = 'u';
                    }
                    else
                    {
                        matrix[i, j] = 'x';
                    }
                }
            }
            int steps = 0;

        }
    }
}
