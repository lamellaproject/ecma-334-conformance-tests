/*
Rules: E15-4-cross-program-constants
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const int Mask = System.Int32.MaxValue & 127;
Into: public const int Mask = System.Int32.MinValue & 127;
*/
using System;
class Limits { public const int Mask = System.Int32.MaxValue & 127; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Limits.Mask == 127, "constant-initialized-from-referenced-program");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
