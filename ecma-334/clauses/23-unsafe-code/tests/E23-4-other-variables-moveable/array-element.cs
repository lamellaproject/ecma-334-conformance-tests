/*
Rules: E23-4-other-variables-moveable
Authority: ECMA-334 7th ed 23.4
Version: 7.3
Expected: reject
Mutate: int* p = &items[0];
Into: fixed (int* p = &items[0]) { }
Csc: CS0212
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int[] items = new int[1];
        int* p = &items[0];
    }
}
