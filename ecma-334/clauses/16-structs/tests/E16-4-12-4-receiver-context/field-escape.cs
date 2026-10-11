/*
Rules: E16-4-12-4-receiver-context
Authority: ECMA-334 7th ed 16.4.12.4
Version: 7.3
Expected: reject
Mutate: return item.Data;
Into: return new int[1];
*/
using System;
ref struct Entry { public Span<int> Data; public Entry(Span<int> data) { Data = data; } }
class Program
{
    static Span<int> Escape()
    {
        Span<int> storage = stackalloc int[1]; Entry item = new Entry(storage);
        return item.Data;
    }
    static void Main() { }
}
