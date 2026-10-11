/*
Rules: E13-9-5-current-public-required
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: private int Current
Into: public int Current
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
        private int Current { get { return 0; } }
        public bool MoveNext() { return false; }
    }
    static void Main() { foreach (int item in new Source()) { } }
}
