/*
Rules: E15-4-constant-sbyte
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const sbyte Code = -117;
Into: public const sbyte Code = -116;
*/
using System;
class Limits { public const sbyte Code = -117; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(sbyte value) { return 1; }
    static int Kind(int value) { return 2; }
    static void Main()
    {
        Check(Kind(Limits.Code) == 1, "sbyte-constant-type");
        Check(Limits.Code == -117, "sbyte-constant-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
