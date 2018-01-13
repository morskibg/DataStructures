using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;

public class LinkedList<T> : IEnumerable<T>
{
    private Node _head;
    private Node _tail;

    
    public int Count { get; private set; }

    public LinkedList()
    {
        _head = null;
        _tail = null;
        Count = 0;
    }

    public void AddFirst(T item)
    {
        Node newNode = new Node(item);
        if (Count == 0)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.NextNode = _head;
            _head = newNode;
        }
        ++Count;
    }

    public void AddLast(T item)
    {
        Node newNode = new Node(item);
        if (Count == 0)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            Node tempNode = _tail;
            tempNode.NextNode = newNode;
            _tail = newNode;
        }
        ++Count;
    }

    public T RemoveFirst()
    {

        if (Count == 0)
        {
            throw new InvalidOperationException();
        }
        else
        {
            T item = _head.Value;
            Node tempNode = _head;
            _head = tempNode.NextNode;
            --Count;
            return item;
        }
    }

    public T RemoveLast()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }
        else
        {
            T item = _tail.Value;
            Node tempNode = _head;
            for (int i = 1; i < Count - 1; ++i)
            {
                tempNode = tempNode.NextNode;
            }
            _tail = tempNode;
            --Count;
            return item;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node currentNode = _head;
        while (currentNode.NextNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class Node
    {
        public T Value { get; set; }
        public Node NextNode { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }
}
