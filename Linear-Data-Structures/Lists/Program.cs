﻿using System;

public class Program
{
    public static void Main(string[] args)
    {
        ArrayList<int> myArr = new ArrayList<int>();
        myArr.Add(5);
        myArr[0] = myArr[0] + 1;
        myArr.RemoveAt(100);
    }
}
