/*
Rules: E15-4-constant-enum
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const Phase Current = Phase.Ready;
Into: public const Phase Current = Phase.Idle;
*/
using System;
enum Phase : short { Idle = 0, Ready = 23 }
class Limits { public const Phase Current = Phase.Ready; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(Phase value) { return 1; }
    static int Kind(short value) { return 2; }
    static void Main()
    {
        Check(Kind(Limits.Current) == 1, "enum-constant-type");
        Check((short)Limits.Current == 23, "enum-constant-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
