using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Problem_6.Implement_the_Data_Structure_ReversedList
//{
    public class ReversedList<T> : IEnumerable<T>
    {
        private T[] arr { get; set; }
        private const int InitialSize = 2;
        public int Count { get; private set; }

        public ReversedList()
        {
            this.arr = new T[InitialSize];
            this.Count = 0;
        }

        public int Capacity
        {
            get
            {
                return this.arr.Length;
            }
            set { }
        }

        public void Add(T item)
        {
            if (this.Capacity == this.Count)
            {
                T[] newArr = new T[this.Capacity * 2];
                for (int i = 0; i < this.Count; i++)
                {
                    newArr[i] = this.arr[i];
                }
                this.arr = newArr;
                this.Capacity *= 2;
            }
            this.arr[this.Count] = item;
            ++this.Count;
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                int modIdx = this.Count - 1 - index;
                for (int i = modIdx; i < this.Count - 1; i++)
                {
                    this.arr[i] = this.arr[i + 1];
                }
                --this.Count;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public T this[int index]
        { 
            get
            {
                if (index >= 0 && index < this.Count)
                {
                    return this.arr[(this.Count - 1) - index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < this.Count)
                {
                    this.arr[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }

            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.arr[this.Count - 1 - i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //ReversedList<int> revList = new ReversedList<int>();
            //Console.WriteLine(revList.Count);
            //revList.Add(1);
            //revList.Add(2);
            //revList.Add(3);
            //revList.Add(4);
            //revList.Add(5);
            //Console.WriteLine(revList[0]);
            //revList.RemoveAt(0);
            //foreach (var item in revList)
            //{
            //    Console.WriteLine(item);
            //}
            //int t = 0;
        }
    }
//}
