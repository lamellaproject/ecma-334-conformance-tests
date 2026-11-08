/*
Rules: E12-12-12-ed3-is-no-nullable-wrapping
Authority: ECMA-334 3rd ed 14.9.10
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E12-12-12-ed3-is-no-nullable-wrapping/underlying-is-nullable.cs.part
Mutate: seed is int?
Into: seed is int
*/
// ECMA-334 3rd ed 14.9.10, p. 210 (PDF p. 230).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        int seed = 67;
        Check(!(seed is int?), "no-nullable-wrapping");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
