/*
Rules: E7-5-3-protected-domain; E7-5-2-protected-modifier; E7-5-2-class-member-access-kinds; E7-5-4-protected-unqualified-form; E7-7-1-class-member-derived-scope
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: protected int value = 89;
Into: private int value = 89;
*/
using System;
#if LIBRARY
public class Root
{
    protected int value = 89;
    public int Own() { return value; }
}
#else
class Branch : Root { public int Read() { return value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Root().Own() == 89, "protected-member-within-containing-type");
        Check(new Branch().Read() == 89, "protected-member-unqualified-in-external-derived-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
