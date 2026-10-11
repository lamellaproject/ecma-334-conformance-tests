/*
Rules: E6-4-4-grammar-keyword-59
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static int Value = 61;
Into: int Value = 61;
*/
using System;
class Counter { public static int Value = 61; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Counter.Value == 61, "static-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
