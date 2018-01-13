using System;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 4;
    private T[] arr;
    private int head;
    private int tail;

    public int Count { get; private set; }

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.arr = new T[capacity];
        this.head = 0;
        this.tail = -1;
        this.Count = 0;
    }

    public void Enqueue(T element)
    {
        if (this.arr.Length == this.tail + 1)
        {
            this.Resize();
        }
        
        this.arr[this.tail + 1] = element;
        ++this.tail;
        ++this.Count;
    }

    private void Resize()
    {
        T [] newArr = new T[this.arr.Length * 2];
        this.CopyAllElements(newArr);
        this.arr = newArr;
    }

    private void CopyAllElements(T[] newArray)
    {
        for (int i = 0; i < this.arr.Length; i++)
        {
            newArray[i] = this.arr[i];
        }
    }

    // Should throw InvalidOperationException if the queue is empty
    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        else
        {
            T item = this.arr[this.head];
            --this.Count;
            if (this.Count == 0)
            {
                this.head = 0;
                this.tail = -1;
            }
            else
            {
                ++this.head;
            }
            return item;
        }
        
    }

    public T[] ToArray()
    {
        T[] arrToReturn = new T[this.Count];
        for (int i = 0; i < this.Count; i++)
        {
            arrToReturn[i] = this.arr[i + this.head];
        }
        return arrToReturn;
    }
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
