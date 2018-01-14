using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    
    private Node head;
    private Node tail;

    public DoublyLinkedList()
    {
        
        this.Count = 0;
    }
    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        Node newNode = new Node(element);
        if (this.Count == 0)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            newNode.nextNode = this.head;
            this.head.prevNode = newNode;
            this.head = newNode;
        }
        ++this.Count;
    }

    public void AddLast(T element)
    {
        Node newNode = new Node(element);
        if (this.Count == 0)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            this.tail.nextNode = newNode;
            newNode.prevNode = this.tail;
            this.tail = newNode;
            
        }
        ++this.Count;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        T item = this.head.value;
        --this.Count;
        if (this.Count == 0)
        {
            this.head = null;
            this.tail = null;
        }
        else
        {
            this.head = this.head.nextNode;
            this.head.prevNode = null;
        }
        
        
        return item;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        T item = this.tail.value;
        --this.Count;
        if (this.Count == 0)
        {
            this.head = null;
            this.tail = null;
        }
        else
        {
            this.tail = this.tail.prevNode;
            this.tail.nextNode = null;
        }


        return item;
    }

    public void ForEach(Action<T> action)
    {
        Node currNode = this.head;
        while (currNode != null)
        {
            action(currNode.value);
            currNode = currNode.nextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node currNode = this.head;
        while (currNode != null)
        {
            yield return currNode.value;
            currNode = currNode.nextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] arr = new T[this.Count];
        int idx = 0;
        Node tempNode = this.head;
        while (tempNode != null)
        {
            arr[idx] = tempNode.value;
            ++idx;
            tempNode = tempNode.nextNode;
        }
        return arr;
    }

    private class Node
    {
        public T value { get; private set; }
        public Node prevNode { get; set; }
        public Node nextNode { get; set; }

        public Node(T value)
        {
            this.value = value;
            this.prevNode = null;
            this.nextNode = null;
        }
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
