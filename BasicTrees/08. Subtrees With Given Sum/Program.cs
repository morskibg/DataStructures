using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_Subtrees_With_a_Given_Sum_W
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
        static List<Tree<int>> GetSubtrees(Tree<int> root, int target)
        {
            var roots = new List<Tree<int>>();
            DFS(root, target, 0, roots);
            return roots;

        }
        static int DFS(Tree<int> node, int target, int current, List<Tree<int>> roots)
        {
            if(node == null)
            {
                return 0;
            }
            current = node.Value;
            foreach(var child in node.Children)
            {
                current += DFS(child, target, current, roots);
            }
            if(current == target)
            {
                roots.Add(node);
            }
            return current;
        }
        static void PrintSubTrees(List<Tree<int>> roots)
        {
            foreach(var node in roots)
            {
                PrintPreOrder(node);
                Console.WriteLine();
            }
        }
        private static void PrintPreOrder(Tree<int> root)
        {
            Console.Write(root.Value + " ");
            foreach (var child in root.Children)
            {
                PrintPreOrder(child);                
            }
        }
        static void Main(string[] args)
        {
            ReadTree();
            int targetSum = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"Subtrees of sum {targetSum}:");            
            Tree<int> rootNode = GetRootNode();
            List<Tree<int>> subtrees = GetSubtrees(rootNode, targetSum);
            PrintSubTrees(subtrees);
            int t = 0;
        }
    }
}
