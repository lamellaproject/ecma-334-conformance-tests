/*
Rules: E13-9-5-readonly-ref-iteration; E13-9-5-readonly-iteration-assignment-error
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: item = 2;
Into: copy = 2;
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
    static void Main()
    {
        int copy = 0;
        foreach (ref readonly int item in new Source()) { item = 2; }
    }
}
