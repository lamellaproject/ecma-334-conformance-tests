/*
Rules: E13-9-5-disposal-variable-hidden
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: object copy = d;
Into: object copy = item;
*/
using System;
class Program
{
    struct Cursor : IDisposable
    {
        public int Current { get { return 1; } }
        public bool MoveNext() { return false; }
        public void Dispose() { }
    }
    class Source { public Cursor GetEnumerator() { return new Cursor(); } }
    static void Main()
    {
        foreach (int item in new Source()) { object copy = d; }
    }
}
