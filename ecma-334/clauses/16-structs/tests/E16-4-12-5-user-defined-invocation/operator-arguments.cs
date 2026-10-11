/*
Rules: E16-4-12-5-user-defined-invocation
Authority: ECMA-334 7th ed 16.4.12.5
Version: 7.3
Expected: reject
Mutate: return wide + narrow;
Into: return wide;
*/
using System;
ref struct Entry
{
    public Span<int> Data;
    public Entry(Span<int> data) { Data = data; }
    public static Entry operator +(Entry left, Entry right) { return left; }
}
class Program
{
    static Entry Escape()
    {
        Entry wide = new Entry(new int[1]);
        Span<int> storage = stackalloc int[1]; Entry narrow = new Entry(storage);
        return wide + narrow;
    }
    static void Main() { }
}
