using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Problem4.LinkedStack_v2
//{
    public class LinkedStack<T>
    {
        private Node<T> firstNode;

        public LinkedStack()
        {
            this.firstNode = new Node<T>();
            this.Count = 0;
        }
        public int Count { get; private set; }

        public void Push(T element)
        {
            Node<T> newNode = new Node<T>(element);
            newNode.NextNode = firstNode.NextNode;
            this.firstNode.NextNode = newNode;
            ++this.Count;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T item = this.firstNode.NextNode.value;
            --this.Count;
            firstNode = firstNode.NextNode;
            return item;
        }

        public T[] ToArray()
        {
            T[] arr = new T[this.Count];
            int idx = 0;
            while (this.Count > 0)
            {
                arr[idx] = this.Pop();
                ++idx;
            }
            return arr;
        }
        private class Node<T>
        {
            public T value;
            public Node<T> NextNode { get; set; }

            public Node(T value, Node<T> nextNode = null)
            {
                this.value = value;
                this.NextNode = null;
            }

            public Node()
            {
                this.NextNode = null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedStack<int> stack = new LinkedStack<int>();
            stack.Push(100);
            stack.Push(99);
            stack.Push(98);
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Count);

            Console.WriteLine(string.Join(" ", stack.ToArray()));
            //Console.WriteLine();
        }
    }
//}
