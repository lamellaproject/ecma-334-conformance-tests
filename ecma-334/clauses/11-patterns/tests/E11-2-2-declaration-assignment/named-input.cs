/*
Rules: E11-2-2-declaration-assignment; E11-2-2-declaration-local; E11-2-2-grammar-declaration-pattern-1; E11-2-2-grammar-simple-designation-1; E11-2-2-grammar-single-variable-designation-1; E11-2-1-grammar-pattern-1; E11-1-is-context; E11-1-is-input
Authority: ECMA-334 7th ed 11.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Next() is int amount
Into: Next() is long amount
*/
using System;
class Program
{
    static int checks, failures;
    static int calls;
    static object Next() { calls++; return 29; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = -1;
        if (Next() is int amount) result = amount;
        Check(result == 29, "assigned-input");
        Check(calls == 1, "input-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
