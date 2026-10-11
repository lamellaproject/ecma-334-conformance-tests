/*
Rules: E9-4-4-22-simple-expression-transfer
Authority: ECMA-334 7th ed 9.4.4.22
Version: 7.3
Expected: reject
Mutate: string name = nameof(cell);
Into: string name = nameof(cell); cell = 14;
Csc: CS0165
*/
using System;
class Program
{
    static void Main()
    {
        int cell;
        string name = nameof(cell);
        Console.WriteLine(name + cell);
    }
}
