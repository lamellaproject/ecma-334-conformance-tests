/*
Rules: E13-9-5-enumerator-return-type-required
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: public void GetEnumerator() { }
Into: public Cursor GetEnumerator() { return new Cursor(); }
*/
using System.Collections;
class Program
{
    class Source : IEnumerable
    {
        public void GetEnumerator() { }
        IEnumerator IEnumerable.GetEnumerator() { return new int[0].GetEnumerator(); }
    }
    class Cursor
    {
        public int Current { get { return 0; } }
        public bool MoveNext() { return false; }
    }
    static void Main() { foreach (int item in new Source()) { } }
}
