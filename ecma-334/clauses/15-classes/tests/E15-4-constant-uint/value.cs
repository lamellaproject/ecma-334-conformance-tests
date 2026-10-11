/*
Rules: E15-4-constant-uint
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const uint Code = 0xf1234567u;
Into: public const uint Code = 0xf1234566u;
*/
using System;
class Limits { public const uint Code = 0xf1234567u; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(uint value) { return 1; }
    static int Kind(long value) { return 2; }
    static void Main()
    {
        Check(Kind(Limits.Code) == 1, "uint-constant-type");
        Check(Limits.Code == 0xf1234567u, "uint-constant-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
