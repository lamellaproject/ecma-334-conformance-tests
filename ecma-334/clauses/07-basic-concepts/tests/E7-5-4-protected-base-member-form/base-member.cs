/*
Rules: E7-5-4-protected-base-member-form
Authority: ECMA-334 7th ed 7.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected int Read() { return 109; }
Into: private int Read() { return 109; }
*/
using System;
class Root { protected int Read() { return 109; } }
class Branch : Root { public int Forward() { return base.Read(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Branch().Forward() == 109, "protected-base-member-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
