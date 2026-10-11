/*
Rules: E15-4-constant-reference
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const Packet Empty = null;
Into: public const Packet Other = null;
*/
using System;
class Packet { }
class Limits { public const Packet Empty = null; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet value = Limits.Empty;
        Check(value == null, "class-constant-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
