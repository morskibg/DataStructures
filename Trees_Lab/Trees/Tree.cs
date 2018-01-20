using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get;  set; }
    public List<Tree<T>> Children;
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();
        foreach (var child in children)
        {
            this.Children.Add(child);
        }
    }

    public void Print(int indent = 0)
    {
        Console.Write(new string(' ', 2 * indent));
        Console.WriteLine(this.Value);
        foreach (var child in Children)
        {
            child.Print(indent + 1);
        }

    }

    
    public void Each(Action<T> action)
    {
        action(this.Value);
        foreach (var child in Children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        List<T> result = new List<T>();
        this.DFS(this, result);
        return result;
    }

    private void DFS(Tree<T> tree, List<T> result)
    {
        foreach (var child in tree.Children)
        {
            this.DFS(child, result);
        }
        result.Add(tree.Value);
    }
    public IEnumerable<T> OrderBFS()
    {
        List<T> result = new List<T>();
        Queue<Tree<T>> queue = new Queue<Tree<T>>();
        queue.Enqueue(this);
        while (queue.Count > 0)
        {
            Tree<T> currTree = queue.Dequeue();
            result.Add(currTree.Value);
            {
                foreach (var child in currTree.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }
        return result;
    }

    
}
