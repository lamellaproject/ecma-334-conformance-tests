/*
Rules: E23-5-2-foreach-variable-readonly
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: reject
Mutate: current = null;
Into: int* copy = null;
Csc: CS1656
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int*[] items = new int*[1];
        foreach (int* current in items)
        {
            current = null;
        }
    }
}
