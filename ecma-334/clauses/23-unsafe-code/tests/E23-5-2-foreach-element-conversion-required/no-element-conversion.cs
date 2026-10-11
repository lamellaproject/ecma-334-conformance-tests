/*
Rules: E23-5-2-foreach-element-conversion-required
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: reject
Mutate: foreach (bool current in items)
Into: foreach (int* current in items)
Csc: CS0030
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int*[] items = new int*[1];
        foreach (bool current in items) { }
    }
}
