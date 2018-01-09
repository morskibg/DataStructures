using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Remove_Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            List<int> nums = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Select(int.Parse)
                .ToList();
            List<int> evenOcurrences = new List<int>();
            foreach (var num in nums)
            {
                int occurenceCounter = nums.Count(x => x == num);
                if (occurenceCounter % 2 == 0)
                {
                    evenOcurrences.Add(num);
                }

            }
            Console.WriteLine(string.Join(" ", evenOcurrences));
        }
    }
}
