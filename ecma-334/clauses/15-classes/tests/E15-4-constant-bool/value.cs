/*
Rules: E15-4-constant-bool
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const bool Ready = true;
Into: public const bool Ready = false;
*/
using System;
class Limits { public const bool Ready = true; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(Kind(Limits.Ready) == 1, "bool-constant-type");
        Check(Limits.Ready, "bool-constant-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
