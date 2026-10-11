/*
Rules: E6-4-3-grammar-combining-character-1
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: \xE0\xA4\x83
Into: +
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int vः = 61;
        Check(v\u0903 == 61, "mc-identifier-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
