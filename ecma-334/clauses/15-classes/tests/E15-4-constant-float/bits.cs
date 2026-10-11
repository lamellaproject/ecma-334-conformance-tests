/*
Rules: E15-4-constant-float
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const float Fraction = 0.15625f;
Into: public const float Fraction = 0.1875f;
*/
using System;
class Limits { public const float Fraction = 0.15625f; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(float value) { return 1; }
    static int Kind(double value) { return 2; }
    // The pinned target uses IEEE single precision; inspect the exact constant representation.
    unsafe static int Bits(float value) { return *(int*)&value; }
    static void Main()
    {
        Check(Kind(Limits.Fraction) == 1, "float-constant-type");
        Check(Bits(Limits.Fraction) == 0x3e200000, "float-constant-bits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
