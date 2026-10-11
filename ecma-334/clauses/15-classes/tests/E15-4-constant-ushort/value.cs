/*
Rules: E15-4-constant-ushort
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const ushort Code = 63001;
Into: public const ushort Code = 63000;
*/
using System;
class Limits { public const ushort Code = 63001; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(ushort value) { return 1; }
    static int Kind(int value) { return 2; }
    static void Main()
    {
        Check(Kind(Limits.Code) == 1, "ushort-constant-type");
        Check(Limits.Code == 63001, "ushort-constant-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
