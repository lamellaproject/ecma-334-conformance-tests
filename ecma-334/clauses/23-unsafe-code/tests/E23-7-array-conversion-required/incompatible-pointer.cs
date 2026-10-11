/*
Rules: E23-7-array-conversion-required
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: fixed (char* pointer = items)
Into: fixed (int* pointer = items)
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int[] items = { 13 };
        fixed (char* pointer = items) { }
    }
}
