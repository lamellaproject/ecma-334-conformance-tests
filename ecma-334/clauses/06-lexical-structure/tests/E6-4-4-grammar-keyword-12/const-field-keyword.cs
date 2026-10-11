/*
Rules: E6-4-4-grammar-keyword-12
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: const int Value = 61;
Into: readonly int Value = 61;
*/
using System;
class Counter { public const int Value = 61; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Counter.Value == 61, "constant-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
