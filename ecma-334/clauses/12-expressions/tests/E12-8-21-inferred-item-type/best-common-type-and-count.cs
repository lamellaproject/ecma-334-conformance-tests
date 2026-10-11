/*
Rules: E12-8-21-inferred-item-type; E12-8-21-inferred-length; E12-8-21-initialized-form; E12-8-21-span-result
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: stackalloc[] { 4, 9L, 13 }
Into: stackalloc[] { 4, 9.0, 13 }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Span<long> values = stackalloc[] { 4, 9L, 13 };
        Check(values.Length == 3, "fully-inferred-count");
        Check(values[0] == 4L && values[2] == 13L, "int-elements-converted-to-common-long");
        Check(values[1] == 9L, "long-element-retained");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
