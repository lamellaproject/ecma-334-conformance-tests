/*
Rules: E13-8-3-guard-bool-conversion-required; E13-8-3-guard-additional-condition
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static implicit operator bool
Into: public static explicit operator bool
*/
using System;
struct Truth
{
    public static implicit operator bool(Truth value) { Program.conversions++; return true; }
}
class Program
{
    public static int conversions;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int selector = 1, observed = 0;
        switch (selector) { case 1 when new Truth(): observed = 7; break; }
        Check(observed == 7, "implicitly-converted-guard-selects-case");
        Check(conversions == 1, "guard-conversion-executed-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
