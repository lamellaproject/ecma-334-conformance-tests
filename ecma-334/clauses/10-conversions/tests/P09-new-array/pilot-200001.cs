/*
Rules: P09-new-array
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: int[] x=new(3);
Into: int[] x=default(int[]);
*/
using System;


class Program
{
    static void Main()
    {
        int[] x=new(3);
    }
}
