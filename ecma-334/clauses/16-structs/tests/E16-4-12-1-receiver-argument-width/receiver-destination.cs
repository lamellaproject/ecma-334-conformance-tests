/*
Rules: E16-4-12-1-receiver-argument-width
Authority: ECMA-334 7th ed 16.4.12.1
Version: 7.3
Expected: reject
Mutate: Entry target = default(Entry);
Into: Entry target = new Entry(source);
*/
using System;
ref struct Entry
{
    public Span<int> Data;
    public Entry(Span<int> data) { Data = data; }
    public void Store(Span<int> data) { Data = data; }
}
class Program
{
    static void Main()
    {
        Span<int> source = stackalloc int[1]; Entry target = default(Entry);
        target.Store(source);
    }
}
