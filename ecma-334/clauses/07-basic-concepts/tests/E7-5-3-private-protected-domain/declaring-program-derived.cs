/*
Rules: E7-5-3-private-protected-domain; E7-5-2-private-protected-modifiers; E7-5-2-class-member-access-kinds
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: private protected int value = 83;
Into: private int value = 83;
*/
using System;
class Root
{
    private protected int value = 83;
    public int Own() { return value; }
}
class Branch : Root { public int Read() { return value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Root().Own() == 83, "private-protected-within-containing-type");
        Check(new Branch().Read() == 83, "private-protected-within-same-program-derived-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
