/*
Rules: E12-6-4-2-omitted-in-conversion
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Pick(value)
Into: Pick(in value)
*/
using System;
class Program
{
    static int checks, failures;
    static long Pick(in long x) { return x; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 4;
        Check(Pick(value) == 4L, "unmodified-input-argument-may-use-implicit-numeric-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
