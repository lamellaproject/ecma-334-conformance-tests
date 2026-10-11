/*
Rules: E13-1-embedded-try
Authority: ECMA-334 7th ed 13.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: throw new Exception();
Into: ;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool caught = false;
        if (true) try { throw new Exception(); } catch (Exception) { caught = true; }
        Check(caught, "embedded-try-handler");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
