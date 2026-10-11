/*
Rules: E15-6-9-partial-unimplemented-no-definite-assignment-effect
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: static partial void Record(int declared);
Into: static partial void Record(int declared); static partial void Record(int used) { }
Csc: CS0165
*/
using System;
partial class Program
{
    static partial void Record(int declared);
    static void Main()
    {
        int value;
        Record(value = 61);
        Console.WriteLine(value);
    }
}
