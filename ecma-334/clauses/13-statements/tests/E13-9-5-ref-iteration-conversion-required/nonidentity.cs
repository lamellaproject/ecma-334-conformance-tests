/*
Rules: E13-9-5-ref-iteration-conversion-required
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: foreach (ref long item in new Source())
Into: foreach (ref int item in new Source())
*/
class Program
{
    class Source { public Cursor GetEnumerator() { return new Cursor(); } }
    class Cursor
    {
        int value;
        public ref int Current { get { return ref value; } }
        public bool MoveNext() { return false; }
    }
    static void Main() { foreach (ref long item in new Source()) { } }
}
