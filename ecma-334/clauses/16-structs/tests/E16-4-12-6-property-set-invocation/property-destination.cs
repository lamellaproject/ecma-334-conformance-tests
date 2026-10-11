/*
Rules: E16-4-12-6-property-set-invocation
Authority: ECMA-334 7th ed 16.4.12.6
Version: 7.3
Expected: reject
Mutate: Entry target = default(Entry);
Into: Entry target = new Entry(storage);
*/
using System;
ref struct Entry
{
    public Span<int> Data;
    public Entry(Span<int> data) { Data = data; }
    public Span<int> Value { get { return Data; } set { Data = value; } }
}
class Program
{
    static void Main()
    {
        Span<int> storage = stackalloc int[1]; Entry target = default(Entry);
        target.Value = storage;
    }
}
