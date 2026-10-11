/*
Rules: E23-7-no-local-assignment; E23-7-local-readonly
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: pointer = null;
Into: int* copy = null;
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int[] items = { 11 };
        fixed (int* pointer = items) { pointer = null; }
    }
}
