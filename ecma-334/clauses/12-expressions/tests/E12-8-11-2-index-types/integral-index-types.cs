/*
Rules: E12-8-11-2-index-types
Authority: ECMA-334 7th ed 12.8.11.2
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: values[unsignedLong]
Into: values[0UL]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = new int[] { 3, 31 };
        int signed = 1; uint unsigned = 1; long signedLong = 1; ulong unsignedLong = 1; short small = 1;
        Check(values[signed] == 31, "int-index");
        Check(values[unsigned] == 31, "uint-index");
        Check(values[signedLong] == 31, "long-index");
        Check(values[unsignedLong] == 31, "ulong-index");
        Check(values[small] == 31, "implicitly-converted-short-index");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
