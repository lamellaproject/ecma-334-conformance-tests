/*
Rules: E12-9-3-lifted
Authority: ECMA-334 7th ed 12.9.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: -value
Into: +value
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        long? value = 6; long? missing = null;
        Check(-value == -6, "nonnull"); Check(-missing == null, "null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
