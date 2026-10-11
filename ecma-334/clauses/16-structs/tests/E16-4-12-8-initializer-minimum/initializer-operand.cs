/*
Rules: E16-4-12-8-initializer-minimum
Authority: ECMA-334 7th ed 16.4.12.8
Version: 7.3
Expected: reject
Mutate: Data = storage
Into: Data = default(Span<int>)
*/
using System;
ref struct Entry { public Span<int> Data; }
class Program
{
    static Entry Escape()
    {
        Span<int> storage = stackalloc int[1];
        return new Entry { Data = storage };
    }
    static void Main() { }
}
