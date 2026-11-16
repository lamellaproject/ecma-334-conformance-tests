/*
Rules: P15-collection15-other
Authority: csc 5.12.0-1.26529.118 (C# 15.0)
Version: 15.0
Expected: reject
Mutate: int[] value=[with(),653];
Into: int[] value=default(int[]);
*/
using System;


class Program
{
    static void Main()
    {
        int[] value=[with(),653];
    }
}
