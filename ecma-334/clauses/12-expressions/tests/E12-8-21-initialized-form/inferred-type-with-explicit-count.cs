/*
Rules: E12-8-21-initialized-form; E12-8-21-inferred-item-type
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: run
Stdout: OK 2
Version-Witness: version-witnesses/inferred-type-with-explicit-count-0514957617.cs.part
Mutate: stackalloc[2] { 17, 23 }
Into: default(Span<int>)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Span<int> values = stackalloc[2] { 17, 23 };
        Check(values.Length == 2, "explicit-count-with-inferred-item-type");
        Check(values.Length == 2 && values[0] == 17 && values[1] == 23, "inferred-int-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
