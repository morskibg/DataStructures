using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Count_of_Occurrences
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
            int[] counterArr = new int[1001];
            foreach (var num in nums)
            {
                counterArr[num]++;
            }
            for (int i = 0; i < 1001; ++i)
            {
                if (counterArr[i] != 0)
                {
                    Console.WriteLine($"{i} -> {counterArr[i]} times");
                }
            }
        }
    }
}
