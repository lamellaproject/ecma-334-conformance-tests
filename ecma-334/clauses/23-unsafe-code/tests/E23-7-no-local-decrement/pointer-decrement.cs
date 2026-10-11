/*
Rules: E23-7-no-local-decrement; E23-7-local-readonly
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: pointer--;
Into: int* copy = pointer - 1;
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int[] items = { 11, 19 };
        fixed (int* pointer = &items[1]) { pointer--; }
    }
}
