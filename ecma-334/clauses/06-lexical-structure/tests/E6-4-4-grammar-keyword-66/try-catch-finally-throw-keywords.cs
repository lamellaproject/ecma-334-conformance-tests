/*
Rules: E6-4-4-grammar-keyword-66; E6-4-4-grammar-keyword-8; E6-4-4-grammar-keyword-25; E6-4-4-grammar-keyword-64
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: throw new Exception();
Into: new Exception();
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int caught = 0, cleanup = 0;
        try { throw new Exception(); }
        catch (Exception) { caught = 1; }
        finally { cleanup = 1; }
        Check(caught == 1 && cleanup == 1, "try-catch-finally-throw");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
