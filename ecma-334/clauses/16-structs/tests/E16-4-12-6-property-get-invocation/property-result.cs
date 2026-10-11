/*
Rules: E16-4-12-6-property-get-invocation
Authority: ECMA-334 7th ed 16.4.12.6
Version: 7.3
Expected: reject
Mutate: return item.Value;
Into: return new int[1];
*/
using System;
ref struct Entry
{
    public Span<int> Data;
    public Entry(Span<int> data) { Data = data; }
    public Span<int> Value { get { return Data; } }
}
class Program
{
    static Span<int> Escape()
    {
        Span<int> storage = stackalloc int[1]; Entry item = new Entry(storage);
        return item.Value;
    }
    static void Main() { }
}
