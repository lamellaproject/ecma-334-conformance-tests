/*
Rules: E15-4-readonly-alternative
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public static readonly Offset Origin = new Offset(82);
Into: public const Offset Origin = new Offset(82);
*/
using System;
struct Offset { public int Value; public Offset(int value) { Value = value; } }
class Limits { public static readonly Offset Origin = new Offset(82); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Limits.Origin.Value == 82, "readonly-value-of-nonconstant-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
