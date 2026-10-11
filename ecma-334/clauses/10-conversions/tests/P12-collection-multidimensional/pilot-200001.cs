/*
Rules: P12-collection-multidimensional
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: int[,] values
Into: int[] values
*/
using System;


class Program
{
    static void Main()
    {
        int[,] values=[13,17];
    }
}
