/*
Rules: E12-12-12-ed4-nullable-is-wrapping
Authority: ECMA-334 4th ed 14.9.10
Version: ISO-2
Expected: run
Stdout: OK 2
Version-Witness: version-witnesses/E12-12-12-ed4-nullable-is-wrapping/underlying-is-nullable.cs.part
Mutate: Check(value is int?, "underlying-wrapping-is");
Into: Check(value is long?, "underlying-wrapping-is");
*/
// ECMA-334 4th ed 14.9.10, p. 211 (PDF p. 233).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int value = 31;
        int? empty = null;
        Check(value is int?, "underlying-wrapping-is");
        Check(!(empty is object), "empty-nullable-is-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
