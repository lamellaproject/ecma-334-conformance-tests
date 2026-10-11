/*
Rules: E9-4-4-23-first-subexpression-entry
Authority: ECMA-334 7th ed 9.4.4.23
Version: 7.3
Expected: reject
Mutate: int sum = cell + (cell = 14);
Into: int sum = (cell = 14) + cell;
Csc: CS0165
*/
using System;
class Program
{
    static void Main()
    {
        int cell;
        int sum = cell + (cell = 14);
        Console.WriteLine(sum);
    }
}
