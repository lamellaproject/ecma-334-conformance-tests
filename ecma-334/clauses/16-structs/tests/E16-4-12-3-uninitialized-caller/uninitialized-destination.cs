/*
Rules: E16-4-12-3-uninitialized-caller
Authority: ECMA-334 7th ed 16.4.12.3
Version: 7.3
Expected: reject
Mutate: Span<int> target;
Into: Span<int> target = stackalloc int[1];
*/
using System;
class Program
{
    static void Main()
    {
        Span<int> target; Span<int> source = stackalloc int[1];
        target = source;
    }
}
