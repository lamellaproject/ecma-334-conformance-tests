/*
Rules: E16-4-12-5-unary-context
Authority: ECMA-334 7th ed 16.4.12.5
Version: 7.3
Expected: reject
Mutate: return +item;
Into: return +default(Entry);
*/
using System;
ref struct Entry
{
    public Span<int> Data;
    public Entry(Span<int> data) { Data = data; }
    public static Entry operator +(Entry item) { return item; }
}
class Program
{
    static Entry Escape()
    {
        Span<int> storage = stackalloc int[1]; Entry item = new Entry(storage);
        return +item;
    }
    static void Main() { }
}
