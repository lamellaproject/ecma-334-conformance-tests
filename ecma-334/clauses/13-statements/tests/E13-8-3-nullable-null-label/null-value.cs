/*
Rules: E13-8-3-nullable-null-label
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: case null:
Into: case 7:
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Choose(int? selector)
    {
        switch (selector) { case null: return 4; case 3: return 6; default: return 9; }
    }
    static void Main()
    {
        Check(Choose(null) == 4, "nullable-null-case-selected");
        Check(Choose(3) == 6, "nullable-value-case-selected");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
