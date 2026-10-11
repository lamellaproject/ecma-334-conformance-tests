/*
Rules: E13-9-5-generic-interface-collection-type; E13-9-5-generic-interface-enumerator-type; E13-9-5-generic-interface-iteration-type; E13-9-5-getenumerator-lookup-fallback; E13-9-5-collection-expression-conversion
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Version-Witness: version-witnesses/most-specific-interface-b27abf61d9.cs.part
Mutate: foreach (var item in new Source())
Into: foreach (var item in (IEnumerable<object>)new Source())
*/
using System;
using System.Collections;
using System.Collections.Generic;
class Program
{
    static int checks, failures, gets;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Length(string value) { return value.Length; }
    static int Length(object value) { return -1; }
    class Source : IEnumerable<object>, IEnumerable<string>
    {
        IEnumerator<string> IEnumerable<string>.GetEnumerator() { gets++; return new Cursor(); }
        IEnumerator<object> IEnumerable<object>.GetEnumerator() { throw new Exception(); }
        IEnumerator IEnumerable.GetEnumerator() { throw new Exception(); }
    }
    class Cursor : IEnumerator<string>
    {
        int position;
        public string Current { get { return "word"; } }
        object IEnumerator.Current { get { throw new Exception(); } }
        public bool MoveNext() { return ++position == 1; }
        public void Reset() { throw new Exception(); }
        public void Dispose() { }
    }
    static void Main()
    {
        int length = 0;
        foreach (var item in new Source()) { length += Length(item); }
        Check(length == 4, "string-current-and-string-iteration-type");
        Check(gets == 1, "unique-most-specific-interface-selected");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
