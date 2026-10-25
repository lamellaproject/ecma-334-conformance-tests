/*
Rules: P12-collection-multidimensional
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: int[,] values = [41];
Into: int[] values = [41];
*/
using System;
class Program
{
    static void Main()
    {
        int[,] values = [41];
        Console.WriteLine(values.Length);
    }
}
