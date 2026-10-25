/*
Rules: P12-collection-no-target
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: var values = [31];
Into: int[] values = [31];
*/
using System;
class Program
{
    static void Main()
    {
        var values = [31];
        Console.WriteLine(values.Length);
    }
}
