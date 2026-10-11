/*
Rules: E10-7-1-arity
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: reject
Mutate: (int x, int y) => x + y
Into: (int x) => x
Csc: CS1593
*/
using System;
class Program
{
    static void Main()
    {
        Func<int, int> converted = (int x, int y) => x + y;
    }
}
