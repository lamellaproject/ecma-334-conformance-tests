/*
Rules: P12-collection-element-invalid
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: byte[] values = [candidate];
Into: byte[] values = [(byte)candidate];
*/
using System;
class Program
{
    static void Main()
    {
        int candidate = 1000;
        byte[] values = [candidate];
        Console.WriteLine(values.Length);
    }
}
