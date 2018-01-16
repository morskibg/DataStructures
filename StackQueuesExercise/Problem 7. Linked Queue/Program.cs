using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Problem_7.Linked_Queue
//
    public class LinkedQueue<T>
    {
        private QueueNode<T> head;
        private QueueNode<T> tail;

        public LinkedQueue()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }
        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            QueueNode<T> newNode = new QueueNode<T>(element);
            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
                this.head.NextNode = null;
                this.head.PrevNode = null;
                this.tail.PrevNode = null;
                this.tail.NextNode = null;
            }
            else if (this.Count == 1)
            {
                this.tail = newNode;
                this.head.NextNode = this.tail;
                this.tail.PrevNode = this.head;
            }
            else
            {
                this.tail.NextNode = newNode;
                newNode.PrevNode = this.tail;
                this.tail = newNode;
            }
            ++this.Count;

        }

        public T Dequeue()
        {
            if (this.Count > 0)
            {
                T item = this.head.Value;
                this.head = this.head.NextNode;
                if (this.head != null)
                {
                    this.head.PrevNode = null;
                }
                
                --this.Count;
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
            QueueNode<T> tempNode = this.head;
            int idx = 0;
            while (tempNode != null)
            {
                arr[idx++] = tempNode.Value;
                tempNode = tempNode.NextNode;
            }
            return arr;
        }

        private class QueueNode<T>
        {
            public T Value { get; private set; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }

            public QueueNode(T value)
            {
                this.Value = value;
            }

            public QueueNode()
            {
                
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //LinkedQueue<int> lq = new LinkedQueue<int>();
            //lq.Enqueue(1);
            //lq.Enqueue(2);
            //lq.Enqueue(3);
            //Console.WriteLine(lq.Count);
            //Console.WriteLine(lq.Dequeue());
            //Console.WriteLine(lq.Dequeue());
            //Console.WriteLine(lq.Dequeue());
            //lq.Enqueue(10);
            //lq.Enqueue(21);
            //lq.Enqueue(31);
            //int[] arr = lq.ToArray();
            //int t = 0;
        }
    }
//}
