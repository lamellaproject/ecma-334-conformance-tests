/*
Rules: E13-10-5-return-end-unreachable
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return 43;
Into: int ignored = 43;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Value() { return 43; }
    static void Main()
    {
        Check(Value() == 43, "return-end-does-not-fall-through");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
