/*
Rules: E23-4-fixed-local-variable
Authority: ECMA-334 7th ed 23.4
Version: 7.3
Expected: reject
Mutate: Action use = () => Console.WriteLine(value);
Into: Action use = () => Console.WriteLine(0);
Csc: CS1686
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int value = 8;
        Action use = () => Console.WriteLine(value);
        int* p = &value;
    }
}
