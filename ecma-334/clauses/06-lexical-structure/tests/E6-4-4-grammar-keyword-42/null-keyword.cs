/*
Rules: E6-4-4-grammar-keyword-42
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: object absent = null;
Into: object absent = new object();
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object absent = null;
        Check(absent == null, "null-keyword");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
