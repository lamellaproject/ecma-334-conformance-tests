/*
Rules: E16-4-12-1-out-argument-width
Authority: ECMA-334 7th ed 16.4.12.1
Version: 7.3
Expected: reject
Mutate: Span<int> target = default(Span<int>);
Into: Span<int> target = stackalloc int[1];
*/
using System;
class Program
{
    static void Store(out Span<int> target, Span<int> source) { target = source; }
    static void Main()
    {
        Span<int> target = default(Span<int>); Span<int> source = stackalloc int[1];
        Store(out target, source);
    }
}
