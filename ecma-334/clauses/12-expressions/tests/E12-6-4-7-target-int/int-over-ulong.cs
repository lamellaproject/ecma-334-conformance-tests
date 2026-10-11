/*
Rules: E12-6-4-7-target-int; E12-6-4-5-better-target
Authority: ECMA-334 7th ed 12.6.4.7
Version: 7.3
Expected: run
Stdout: OK 1
Generated: clauses/12-expressions/generators/signed-targets.py
*/
using System;
struct Source
{
    public static implicit operator int(Source x) { return 1; }
    public static implicit operator ulong(Source x) { return 1; }
}
class Program
{
    static int checks, failures;
    static int Pick(int x) { return 1; }
    static int Pick(ulong x) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick(new Source()) == 1, "int-over-ulong");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
