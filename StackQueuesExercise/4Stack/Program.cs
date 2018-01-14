using System;



//namespace ArrStack
//{



    public class ArrayStack<T>
    {
        private T[] elements;
        public int Count { get; private set; }
        private const int InitialCapacity = 16;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
            this.Count = 0;

        }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                this.Grow();
            }
            this.elements[this.Count] = element;
            ++this.Count;
        }

        public T Pop()
        {
            if (this.Count > 0)
            {
                --this.Count;
                return this.elements[this.Count];
            }
            throw new InvalidOperationException();
        }

        public T[] ToArray()
        {
            T[] arr = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                arr[i] = this.elements[this.Count - 1 - i];
            }
            return arr;
        }

        private void Grow()
        {
            T[] newArr = new T[this.elements.Length * 2];
            for (int i = 0; i < this.elements.Length; i++)
            {
                newArr[i] = this.elements[i];
            }
            this.elements = newArr;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            ArrayStack<int> stack = new ArrayStack<int>();
            Console.WriteLine(stack.Count);
            stack.Push(99);
            stack.Push(100);
            Console.WriteLine(string.Join(" ",stack.ToArray()));
            
        int t = 0;
            //for (int i = 0; i < 100; i++)
            //    {
            //        stack.Push(i);
            //    }

            //    Console.WriteLine(stack.Count);
            //    Console.WriteLine(string.Join(" ", stack.ToArray()));

            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine(stack.Pop());

            //    }
            //    Console.WriteLine(stack.Count);
            //    Console.WriteLine(stack.Pop());
        }
    }

//}
