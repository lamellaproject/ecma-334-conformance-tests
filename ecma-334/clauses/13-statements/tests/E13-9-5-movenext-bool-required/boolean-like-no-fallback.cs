/*
Rules: E13-9-5-movenext-bool-required
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: public Truth MoveNext() { return new Truth(); }
Into: public bool MoveNext() { return false; }
*/
using System.Collections;
class Program
{
    struct Truth
    {
        public static implicit operator bool(Truth value) { return false; }
        public static bool operator true(Truth value) { return false; }
        public static bool operator false(Truth value) { return true; }
    }
    class Source : IEnumerable
    {
        public Cursor GetEnumerator() { return new Cursor(); }
        IEnumerator IEnumerable.GetEnumerator() { return new int[0].GetEnumerator(); }
    }
    class Cursor
    {
        public int Current { get { return 0; } }
        public Truth MoveNext() { return new Truth(); }
    }
    static void Main() { foreach (int item in new Source()) { } }
}
