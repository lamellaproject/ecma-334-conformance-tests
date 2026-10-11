/*
Rules: E8-3-7-forced-precision
Authority: ECMA-334 7th ed 8.3.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (float)wide
Into: wide
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double wide = 16777217.0d;
        double rounded = (float)wide;
        Check(rounded == 16777216.0d, "cast-forces-single-precision");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
