/*
Rules: E15-4-constant-double
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const double Fraction = 0.03125d;
Into: public const double Fraction = 0.0625d;
*/
using System;
class Limits { public const double Fraction = 0.03125d; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(double value) { return 1; }
    static int Kind(decimal value) { return 2; }
    // The pinned target uses IEEE double precision; inspect the exact constant representation.
    unsafe static long Bits(double value) { return *(long*)&value; }
    static void Main()
    {
        Check(Kind(Limits.Fraction) == 1, "double-constant-type");
        Check(Bits(Limits.Fraction) == 0x3fa0000000000000L, "double-constant-bits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
