/*
Rules: E6-4-4-grammar-keyword-23
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: extern int Foreign()
Into: external int Foreign()
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    // Only the declaration is tested; the external function is never invoked.
    static extern int Foreign();
    static void Main()
    {
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
