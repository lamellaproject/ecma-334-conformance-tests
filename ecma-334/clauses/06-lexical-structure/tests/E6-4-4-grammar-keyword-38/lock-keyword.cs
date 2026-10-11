/*
Rules: E6-4-4-grammar-keyword-38
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: lock (gate)
Into: hold (gate)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object gate = new object();
        int value = 0;
        lock (gate) { value = 61; }
        Check(value == 61, "lock-statement");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
