/*
Rules: E15-6-9-partial-match-method-modifiers
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unsafe static partial void Fill(ref int touched)
Into: unsafe partial void Fill(ref int touched)
*/
using System;
partial class Program
{
    static unsafe partial void Fill(ref int declared);
    unsafe static partial void Fill(ref int touched) { touched = 73; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 0;
        Fill(ref value);
        Check(value == 73, "partial-declaration-modifiers-match-in-either-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
