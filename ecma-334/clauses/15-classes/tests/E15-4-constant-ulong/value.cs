/*
Rules: E15-4-constant-ulong
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const ulong Code = 0xfedcba9876543210UL;
Into: public const ulong Code = 0xfedcba9876543211UL;
*/
using System;
class Limits { public const ulong Code = 0xfedcba9876543210UL; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(ulong value) { return 1; }
    static int Kind(decimal value) { return 2; }
    static void Main()
    {
        Check(Kind(Limits.Code) == 1, "ulong-constant-type");
        Check(Limits.Code == 0xfedcba9876543210UL, "ulong-constant-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
