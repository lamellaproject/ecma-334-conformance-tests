/*
Rules: E10-2-8-ed3-library-generic-invariance
Authority: ECMA-334 3rd ed 13.1.4
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E10-2-8-ed3-library-generic-invariance/enumerable-argument-change.cs.part
Mutate: System.Collections.Generic.IEnumerable<object> view = source;
Into: System.Collections.Generic.IEnumerable<string> view = source;
*/
// ECMA-334 3rd ed 13.1.4, p. 134 (PDF p. 154).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static System.Collections.Generic.IEnumerable<string> Read() { yield return "alder"; }
    static int Main()
    {
        System.Collections.Generic.IEnumerable<string> source = Read();
        System.Collections.Generic.IEnumerable<object> view = source;
        int seen = 0;
        foreach (object value in view) { if ((string)value == "alder") seen++; }
        Check(seen == 1, "generic-enumerable-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
