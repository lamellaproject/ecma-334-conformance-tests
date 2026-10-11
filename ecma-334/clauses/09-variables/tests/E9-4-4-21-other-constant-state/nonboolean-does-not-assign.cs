/*
Rules: E9-4-4-21-other-constant-state
Authority: ECMA-334 7th ed 9.4.4.21
Version: 7.3
Expected: reject
Mutate: int constant = 4 * 8;
Into: int constant = cell = 4 * 8;
Csc: CS0165
*/
using System;
class Program
{
    static void Main()
    {
        int cell;
        int constant = 4 * 8;
        Console.WriteLine(constant + cell);
    }
}
