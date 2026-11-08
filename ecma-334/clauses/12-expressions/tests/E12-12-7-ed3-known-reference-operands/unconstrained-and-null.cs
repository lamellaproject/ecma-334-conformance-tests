/*
Rules: E12-12-7-ed3-known-reference-operands
Authority: ECMA-334 3rd ed 14.9.6
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-12-7-ed3-known-reference-operands/unconstrained-and-null.cs.part
Mutate: value == null
Into: (object)value == (object)null
*/
// ECMA-334 3rd ed 14.9.6, p. 207 (PDF p. 227).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static bool Missing<T>(T value) { return value == null; }
    static int Main()
    {
        Check(!Missing(47), "nonnull-generic-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
