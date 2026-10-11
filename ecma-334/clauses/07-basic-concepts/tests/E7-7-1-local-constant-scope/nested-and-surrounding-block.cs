/*
Rules: E7-7-1-local-constant-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: const int value = 163;
Into: const int renamed = 163;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const int value = 163;
        { Check(value == 163, "constant-visible-in-nested-block"); }
        Check(value == 163, "constant-visible-after-nested-block");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
