/*
Rules: E13-9-5-ambiguous-generic-interface-error
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: foreach (var item in new Source())
Into: foreach (var item in (IEnumerable<int>)new Source())
*/
using System.Collections;
using System.Collections.Generic;
class Program
{
    class Source : IEnumerable<int>, IEnumerable<string>
    {
        IEnumerator<int> IEnumerable<int>.GetEnumerator() { return null; }
        IEnumerator<string> IEnumerable<string>.GetEnumerator() { return null; }
        IEnumerator IEnumerable.GetEnumerator() { return null; }
    }
    static void Main() { foreach (var item in new Source()) { } }
}
