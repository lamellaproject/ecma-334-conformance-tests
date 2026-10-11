/*
Rules: E12-12-1-null-literals-no-resolution; E12-12-1-null-literals-equal; E12-12-1-null-literals-unequal
Authority: ECMA-334 7th ed 12.12.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: const bool same = null == null;
Into: const bool same = null != null;
*/
using System;
class Program
{
    const bool same = null == null;
    const bool different = null != null;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(same, "constant-null-equality"); Check(!different, "constant-null-inequality");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
