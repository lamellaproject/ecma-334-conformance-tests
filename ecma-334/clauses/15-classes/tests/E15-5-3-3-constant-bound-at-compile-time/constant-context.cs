/*
Rules: E15-5-3-3-constant-bound-at-compile-time
Authority: ECMA-334 7th ed 15.5.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const int Code = 199;
Into: public static readonly int Code = 199;
*/
using System;
class Limits { public const int Code = 199; }
class Program
{
    const int BoundValue = Limits.Code + 3;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(BoundValue == 202, "referenced-constant-value-known-at-compilation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
