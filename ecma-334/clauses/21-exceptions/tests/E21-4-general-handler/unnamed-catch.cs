/*
Rules: E21-4-general-handler
Authority: ECMA-334 7th ed 21.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: catch { caught = true; }
Into: catch (InvalidOperationException) { caught = true; }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool caught = false;
        try { throw new Exception(); }
        catch { caught = true; }
        Check(caught, "general-catch-handles-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
