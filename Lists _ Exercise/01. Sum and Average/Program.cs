using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sum_and_Average
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            if (line != String.Empty)
            {
                List<int> nums = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .Select(int.Parse)
                    .ToList();
               
                Console.WriteLine($"Sum={nums.Sum()}; Average={nums.Average():f2}");
            }
            else
            {
                Console.WriteLine($"Sum=0; Average=0.00");
            }
            
           
        }
    }
}
