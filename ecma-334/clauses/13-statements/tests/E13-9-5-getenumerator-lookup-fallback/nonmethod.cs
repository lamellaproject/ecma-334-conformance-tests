/*
Rules: E13-9-5-getenumerator-lookup-fallback; E13-9-5-nongeneric-interface-collection-type; E13-9-5-nongeneric-interface-enumerator-type; E13-9-5-nongeneric-interface-iteration-type; E13-9-5-collection-expression-conversion
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int GetEnumerator = 0;
Into: public IEnumerator GetEnumerator() { return new int[] { 20 }.GetEnumerator(); }
*/
using System;
using System.Collections;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Select(object value) { return 1; }
    static int Select(int value) { return 2; }
    class Source : IEnumerable
    {
        public int GetEnumerator = 0;
        IEnumerator IEnumerable.GetEnumerator() { calls++; return new int[] { 19 }.GetEnumerator(); }
    }
    static void Main()
    {
        int total = 0, type = 0;
        foreach (var item in new Source()) { total += (int)item; type = Select(item); }
        Check(total == 19 && calls == 1, "nonmethod-falls-back-to-interface");
        Check(type == 1, "nongeneric-iteration-type-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
