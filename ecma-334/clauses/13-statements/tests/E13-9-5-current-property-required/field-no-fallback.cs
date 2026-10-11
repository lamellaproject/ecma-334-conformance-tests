/*
Rules: E13-9-5-current-property-required
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: public int Current = 0;
Into: public int Current { get { return 0; } }
*/
using System.Collections;
class Program
{
    class Source : IEnumerable
    {
        public Cursor GetEnumerator() { return new Cursor(); }
        IEnumerator IEnumerable.GetEnumerator() { return new int[0].GetEnumerator(); }
    }
    class Cursor
    {
        public int Current = 0;
        public bool MoveNext() { return false; }
    }
    static void Main() { foreach (int item in new Source()) { } }
}
