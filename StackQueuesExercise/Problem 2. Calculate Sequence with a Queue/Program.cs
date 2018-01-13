using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Calculate_Sequence_with_a_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(num);
            List<int> nums = new List<int>();
            nums.Add(num);
            while (true) 
            {
                int a = queue.Dequeue();
                int b = a + 1;
                int c = 2 * a + 1;
                int d = a + 2;
                nums.Add(b);
                if (nums.Count == 50)
                {
                    break;
                }
                nums.Add(c);
                if (nums.Count == 50)
                {
                    break;
                }
                nums.Add(d);
                if (nums.Count == 50)
                {
                    break;
                }
                queue.Enqueue(b);
                queue.Enqueue(c);
                queue.Enqueue(d);

            }
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
