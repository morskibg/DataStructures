using System;

public class ArrayList<T>
{
    public T[] arr;
    private int currArrIdx;
    private int currArrLength;

    public ArrayList()
    {
        this.arr = new T[2];
        this.currArrLength = 2;
        this.currArrIdx = 0;
    }

    public int Count
    {
        get
        {
            return this.currArrIdx;
        }
        private set
        {

        }
    }
    private bool IsIdxInRange(int idx)
    {
        if(idx >= 0 && idx < this.Count)
        {
            return true;
        }
        return false;
    }
    public T this[int index]
    {
        get
        {
            if (IsIdxInRange(index))
            {
                return this.arr[index];
            }
            throw new IndexOutOfRangeException();
        }

        set
        {
            if (IsIdxInRange(index))
            {
                 this.arr[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            
        }
    }

    public void Add(T item)
    {
       if(this.Count  == this.currArrLength)
        {
            this.ResizeArr();           
        }
        this.arr[currArrIdx] = item;
        ++currArrIdx;
    }
    private void ResizeArr()
    {
        T[] resizedArr = new T[2 * this.currArrIdx];
        for(int i = 0; i < this.Count; ++i)
        {
            resizedArr[i] = this.arr[i];
        }
        this.currArrLength *= 2;
        this.arr = resizedArr;
    }
    public T RemoveAt(int index)
    {
        if (IsIdxInRange(index))
        {
            T itemToReturn = this.arr[index];
           for(int i = index; i < this.Count - 1; ++i)
            {
                this.arr[i] = this.arr[i + 1];
            }
           --this.currArrIdx;
            return itemToReturn;
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }
}
