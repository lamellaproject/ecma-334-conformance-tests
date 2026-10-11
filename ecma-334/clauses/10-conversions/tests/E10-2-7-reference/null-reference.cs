/*
Rules: E10-2-7-reference; E10-2-7-null-result
Authority: ECMA-334 7th ed 10.2.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: object result = null;
Into: object result = new object();
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object result = null;
        Check(result == null, "null-reference/value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
