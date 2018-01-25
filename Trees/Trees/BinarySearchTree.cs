using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node root;

    private BinarySearchTree(Node node)
    {
        this.Copy(node);
    }
    public BinarySearchTree()
    {
        this.root = null;
    }
    private Node Insert(Node node, T value)
    {
        if (node == null)
        {
            return new Node(value);
        }
        int compare = node.Value.CompareTo(value);
        if (compare > 0)
        {
            node.leftNode = Insert(node.leftNode, value);
        }
        else if (compare < 0)
        {
            node.rightNode = Insert(node.rightNode, value);
        }

        return node;
    }
    public void Insert(T value)
    {
        this.root = this.Insert(this.root, value);
        //if (this.root == null)
        //{
        //    this.root = new Node(value);
        //    return;
        //}
        //Node parent = null;
        //Node current = this.root;
        //while (current != null)
        //{
        //    int compare = current.Value.CompareTo(value);
        //    if (compare > 0)
        //    {
        //        parent = current;
        //        current = current.leftNode;
        //    }
        //    else if (compare < 0)
        //    {
        //        parent = current;
        //        current = current.rightNode;
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
        //Node newNode = new Node(value);
        //if (parent.Value.CompareTo(newNode.Value) > 0)
        //{
        //    parent.leftNode = newNode;
        //}
        //else if (parent.Value.CompareTo(newNode.Value) < 0)
        //{
        //    parent.rightNode = newNode;
        //}
    }

    public bool Contains(T value)
    {
        Node current = this.root;

        while (current != null)
        {
            int compare = current.Value.CompareTo(value);
            if (compare > 0)
            {

                current = current.leftNode;
            }
            else if (compare < 0)
            {

                current = current.rightNode;
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }
        Node parent = null;
        Node current = this.root;
        while (current.leftNode != null)
        {
            parent = current;
            current = parent.leftNode;
        }
        if (parent == null)
        {
            this.root = current.rightNode;
        }
        else
        {
            parent.leftNode = current.rightNode;
        }
    }
    public BinarySearchTree<T> Search(T item)
    {
        Node current = this.root;
        while (current != null)
        {
            int compare = current.Value.CompareTo(item);
            if (compare > 0)
            {
                current = current.leftNode;
            }
            else if (compare < 0)
            {
                current = current.rightNode;
            }
            else
            {
                return new BinarySearchTree<T>(current);
            }
        }


        return null;
    }
    private void Copy(Node node)
    {
        if (node == null)
        {
            return;
        }
        this.Insert(node.Value);
        this.Copy(node.leftNode);
        this.Copy(node.rightNode);
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        List<T> result = new List<T>();
        this.Range(this.root, result, startRange, endRange);
        return result;
    }
    private void Range(Node node, List<T> result, T start, T end)
    {
        if(node == null)
        {
            return;
        }
        int compareLow = node.Value.CompareTo(start);
        int compareHigh = node.Value.CompareTo(end);
        if(compareLow > 0)
        {
            this.Range(node.leftNode, result, start, end);
        }
        if(compareLow >= 0 && compareHigh <= 0)
        {
            result.Add(node.Value);
        }
        if(compareHigh < 0)
        {
            this.Range(node.rightNode, result, start, end);
        }
    }
    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }
        this.EachInOrder(node.leftNode, action);
        action(node.Value);
        this.EachInOrder(node.rightNode, action);
    }
    private class Node
    {
        public T Value { get; set; }
        public Node leftNode { get; set; }
        public Node rightNode { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.leftNode = null;
            this.rightNode = null;
        }
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> BST = new BinarySearchTree<int>();
        BST.Insert(20);
        BST.Insert(15);
        BST.Insert(12);
        BST.Insert(34);
        BST.Insert(30);
        BST.Insert(13);
        BST.Insert(56);
        BST.Search(15);
        //List<int> list = new List<int>();
        //BST.EachInOrder(list.Add);
        int t = 0;
    }
}
