using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Problem4.LinkedStack
//{
    public class LinkedStack<T>
    {
        private Node<T> firstNode;

        private Node<T> lastNode { get; set; }
        //private Node<T> dataNode;
        public int Count { get; private set; }

        public LinkedStack()
        {
            this.firstNode = new Node<T>();
            
            this.Count = 0;
        }
        

        public void Push(T element)
        {
            Node<T> newNode = new Node<T>(element);
            if (this.Count == 0)
            {
                this.firstNode.NextNode = newNode;
                
            }
            else
            {
                this.lastNode.NextNode = newNode;
            }
            this.lastNode = newNode;
            ++this.Count;
        }

        public T Pop()
        {
            if (this.Count > 0)
            {
                T item = this.lastNode.value;
                --this.Count;
                Node<T> tempNode = this.firstNode;
                for (int i = 0; i < this.Count; ++i)
                {
                    tempNode = tempNode.NextNode;
                }
                this.lastNode = tempNode;
                return item;
            }
            else
            {
                throw new InvalidOperationException();
            }
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
            public T value { get; set; }
            public Node<T> NextNode { get; set; }

            public Node(T value, Node<T> nextNode = null)
            {
                this.NextNode = null;
                this.value = value;
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
            //Console.WriteLine(stack.Count);
            stack.Push(100);
            //Console.WriteLine(stack.Count);
            stack.Push(99);
            stack.Push(98);
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
             stack.Push(97);
            //int[] arr = stack.ToArray();
            Console.WriteLine(string.Join(" ", stack.ToArray()));

            int t = 0;
        }
    }
//}
