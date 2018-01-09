using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sort_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            if (line != String.Empty)
            {
                List<string> words = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .OrderBy(x => x)
                    .ToList();
                Console.WriteLine(string.Join(" ", words));

            }
        }
    }
}
