/*
Rules: E13-9-5-writable-ref-iteration
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: foreach (ref int item in new Source())
Into: foreach (ref readonly int item in new Source())
*/
class Program
{
    class Source { public Cursor GetEnumerator() { return new Cursor(); } }
    class Cursor
    {
        int value;
        public ref readonly int Current { get { return ref value; } }
        public bool MoveNext() { return false; }
    }
    static void Main() { foreach (ref int item in new Source()) { } }
}
