using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Paths_With_Given_Sum
{
    class Program
    {
        public class Tree<T>
        {
            public T Value { get; set; }
            public Tree<T> Parent { get; set; }
            public List<Tree<T>> Children { get; private set; }

            public Tree(T value, params Tree<T>[] children)
            {
                this.Value = value;
                this.Children = new List<Tree<T>>();
                foreach (var child in children)
                {
                    child.Parent = this;
                    this.Children.Add(child);

                }
            }
        }
        static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        static Tree<int> GetNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }
            return nodeByValue[value];
        }

        static void AddEdge(int parent, int child)
        {
            Tree<int> parentNode = GetNodeByValue(parent);
            Tree<int> childNode = GetNodeByValue(child);

            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }

        static int ReadTree()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                int[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .Select(int.Parse)
                    .ToArray();
                int parent = data[0];
                int child = data[1];
                AddEdge(parent, child);

            }
            return int.Parse(Console.ReadLine());
        }

        static Tree<int> GetRootNode()
        {
            return nodeByValue.Values.First(x => x.Parent == null);
        }

        static void Print(Tree<int> currNode, int indent)
        {
            Console.Write(new string(' ', indent * 2));
            Console.WriteLine(currNode.Value);
            if (currNode.Children.Count != 0)
            {
                foreach (var child in currNode.Children)
                {
                    Print(child, indent + 1);
                }
            }

        }

        static void FindLeafs(Tree<int> currNode, List<int> result)
        {
            foreach (var child in currNode.Children)
            {
                if (child.Children.Count == 0)
                {
                    result.Add(child.Value);
                }
                else
                {
                    FindLeafs(child, result);
                }
            }
        }

        static void FindMiddles(Tree<int> currNode, List<int> result)
        {
            foreach (var child in currNode.Children)
            {
                if (child.Children.Count > 0 && child.Parent != null)
                {
                    result.Add(child.Value);
                }
                else
                {
                    FindMiddles(child, result);
                }
            }

        }
        static void Main(string[] args)
        {
            int sumToLookFor = ReadTree();
            Console.WriteLine($"Paths of sum {sumToLookFor}:");
            Tree<int> rootNode = GetRootNode();
            List<int> leafs = new List<int>();
            FindLeafs(rootNode, leafs);
            foreach (var leaf in leafs)
            {
                Tree<int> currLeaf = nodeByValue[leaf];
                int currSum = currLeaf.Value;
                List<int> path = new List<int> {currSum};

                while (currLeaf.Parent != null)
                {
                    currLeaf = currLeaf.Parent;
                    currSum += currLeaf.Value;
                    path.Add(currLeaf.Value);
                }
                if (currSum == sumToLookFor)
                {
                    path.Reverse();
                    Console.WriteLine(string.Join(" ", path));
                }
            }
        }
    }
}
