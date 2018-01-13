using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Reverse_Numbers_with_a_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = 
                new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            Console.WriteLine(string.Join(" ", stack.ToArray()));


        }
    }
}
