/*
Rules: E16-4-12-8-constructor-as-method
Authority: ECMA-334 7th ed 16.4.12.8
Version: 7.3
Expected: reject
Mutate: return new Entry(storage);
Into: return new Entry(default(Span<int>));
*/
using System;
ref struct Entry { public Span<int> Data; public Entry(Span<int> data) { Data = data; } }
class Program
{
    static Entry Escape()
    {
        Span<int> storage = stackalloc int[1];
        return new Entry(storage);
    }
    static void Main() { }
}
