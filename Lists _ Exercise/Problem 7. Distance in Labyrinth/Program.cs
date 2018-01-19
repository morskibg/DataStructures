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

        static int GetVertexNum(int row, int col, int size)
        {
            return size * row + col;
        }

        static int GetRow(int vertexNum, int size)
        {
            return (vertexNum / size);
        }

        static int GetCol(int vertexNum, int size)
        {
            return vertexNum % size;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string [,] matrix = new string[n,n];
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
                        matrix[i, j] = "*";
                    }
                    else if (lineOfChars[j] == '0')
                    {
                        matrix[i, j] = "u";
                    }
                    else
                    {
                        matrix[i, j] = "x";
                    }
                }
            }
            Queue<int> q = new Queue<int>();
            q.Enqueue(GetVertexNum(startRow, startCol, n));
            int step = 0;
            
            while (q.Count > 0)
            {
                int currVertex = q.Dequeue();
                int currRow = GetRow(currVertex, n);
                int currCol = GetCol(currVertex, n);
                
                
                if (IsInBounds(currRow, currCol + 1, n) && matrix[currRow, currCol + 1] == "u")
                {
                   
                    matrix[currRow, currCol + 1] = (step + 1).ToString();
                    q.Enqueue(GetVertexNum(currRow,currCol + 1, n));
                }
                if (IsInBounds(currRow, currCol - 1, n) && matrix[currRow, currCol - 1] == "u")
                {
                    
                    matrix[currRow, currCol - 1] = (step + 1).ToString();
                    q.Enqueue(GetVertexNum(currRow, currCol - 1, n));
                }
                if (IsInBounds(currRow + 1, currCol, n) && matrix[currRow + 1, currCol] == "u")
                {
                   
                    matrix[currRow + 1, currCol] = (step + 1).ToString();
                    q.Enqueue(GetVertexNum(currRow + 1, currCol, n));
                }
                if (IsInBounds(currRow - 1, currCol, n) && matrix[currRow - 1, currCol] == "u")
                {
                   
                    matrix[currRow - 1, currCol] = (step + 1).ToString();
                    q.Enqueue(GetVertexNum(currRow - 1, currCol, n));
                }
                

            }
            int t = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }

            //int vertex = GetVertexNum(3, 2, n);
            //Console.WriteLine(vertex);
            //Console.WriteLine(GetRow(vertex, n));
            //Console.WriteLine(GetCol(vertex, n));


        }
    }
}
