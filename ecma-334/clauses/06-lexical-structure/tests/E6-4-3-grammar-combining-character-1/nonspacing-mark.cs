/*
Rules: E6-4-3-grammar-combining-character-1
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: \xCC\x81
Into: +
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int v́ = 59;
        Check(v\u0301 == 59, "mn-identifier-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
