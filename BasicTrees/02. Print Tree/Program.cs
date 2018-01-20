using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Print_Tree
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

        static void ReadTree()
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
        static void Main(string[] args)
        {
            ReadTree();
            Tree<int> rootNode = GetRootNode();
            Print(rootNode, 0);
            
        }
    }
}
