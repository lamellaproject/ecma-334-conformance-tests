/*
Rules: E8-4-5-ed4-nonnullable-boxing-constraint
Authority: ECMA-334 4th ed 25.7.1
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E8-4-5-ed4-nonnullable-boxing-constraint/nullable-object-bound.cs.part
Mutate: Use<int?, object>();
Into: Use<int, object>();
*/
// ECMA-334 4th ed 25.7.1, p. 410 (PDF p. 432).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static void Use<T, U>() where T : U
    {
        Check(true, "satisfied-type-parameter-constraint");
    }
    static int Main()
    {
        Use<int?, object>();
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
