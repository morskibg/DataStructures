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
        ++this.Count;
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
        // TODO: Throw exception if the list is empty
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        // TODO
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        // TODO
        throw new NotImplementedException();
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
