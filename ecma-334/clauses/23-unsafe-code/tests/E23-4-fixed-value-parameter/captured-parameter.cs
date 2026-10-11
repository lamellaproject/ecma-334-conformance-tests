/*
Rules: E23-4-fixed-value-parameter
Authority: ECMA-334 7th ed 23.4
Version: 7.3
Expected: reject
Mutate: Action use = () => Console.WriteLine(value);
Into: Action use = () => Console.WriteLine(0);
Csc: CS1686
*/
using System;
unsafe class Program
{
    static void Read(int value)
    {
        Action use = () => Console.WriteLine(value);
        int* p = &value;
    }
    static void Main()
    {
        Read(8);
    }
}
