using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStack
{

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
            this.elements[this.Count - 1] = element;
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
                arr[i] = this.elements[i];
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

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

