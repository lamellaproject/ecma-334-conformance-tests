/*
Rules: E13-10-6-throw-end-unreachable
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: throw new Exception();
Into: int ignored = 1;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Value() { throw new Exception(); }
    static void Main()
    {
        bool caught = false;
        try { int value = Value(); }
        catch (Exception) { caught = true; }
        Check(caught, "throw-end-does-not-fall-through");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
