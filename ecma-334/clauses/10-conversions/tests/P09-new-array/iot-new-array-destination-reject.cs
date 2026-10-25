/*
Rules: P09-new-array
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: int[] specimen = new();
Into: Sample specimen = new();
*/
using System;

// Target-typed new specification L76: arrays require array-creation syntax.
class Sample { }
class Program
{
    static void Main()
    {
        int[] specimen = new();
        Console.WriteLine(Object.ReferenceEquals(specimen, null));
    }
}
