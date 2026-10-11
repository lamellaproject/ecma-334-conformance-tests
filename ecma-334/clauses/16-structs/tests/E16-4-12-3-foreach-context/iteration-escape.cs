/*
Rules: E16-4-12-3-foreach-context
Authority: ECMA-334 7th ed 16.4.12.3
Version: 7.3
Expected: reject
Mutate: Span<int> storage = stackalloc int[1];
Into: Span<int> storage = new int[1];
*/
using System;
ref struct Sequence
{
    Span<int> data;
    public Sequence(Span<int> value) { data = value; }
    public Cursor GetEnumerator() { return new Cursor(data); }
}
ref struct Cursor
{
    Span<int> data;
    int position;
    public Cursor(Span<int> value) { data = value; position = 0; }
    public bool MoveNext() { return position++ == 0; }
    public Span<int> Current { get { return data; } }
}
class Program
{
    static Span<int> Escape()
    {
        Span<int> storage = stackalloc int[1];
        Sequence sequence = new Sequence(storage);
        foreach (Span<int> item in sequence) { return item; }
        return default(Span<int>);
    }
    static void Main() { }
}
