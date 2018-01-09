using System;

public class Program
{
    public static void Main(string[] args)
    {
        ArrayList<int> myArr = new ArrayList<int>();
        myArr.Add(5);
        myArr.Add(6);
        myArr.Add(7);
        myArr.Add(8);
        myArr.Add(9);
        myArr.RemoveAt(2);
        for (int i = 0; i < myArr.Count; ++i)
        {
            Console.WriteLine(myArr[i]);
        }
    }
}
