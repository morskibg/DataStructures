using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Longest_Subsequence
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
            List<List<int>> lists = new List<List<int>>();
            for (int i = 0; i < nums.Count; ++i)
            {
                if (i == 0 || lists.Last().Last() != nums[i])
                {
                    List<int> innerList = new List<int>();
                    innerList.Add(nums[i]);
                    lists.Add(innerList);
                }
                else
                {
                    lists.Last().Add(nums[i]);
                }
            }
            List<int> longestSeq = lists.OrderByDescending(x => x.Count).First();
            Console.WriteLine(string.Join(" ", longestSeq));
        }
    }
}
