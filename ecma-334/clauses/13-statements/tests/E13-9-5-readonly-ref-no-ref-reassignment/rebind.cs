/*
Rules: E13-9-5-readonly-ref-no-ref-reassignment
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: item = ref other;
Into: other = item;
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
        int other = 3;
        foreach (ref readonly int item in new Source()) { item = ref other; }
    }
}
