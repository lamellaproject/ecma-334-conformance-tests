/*
Rules: E12-6-2-1-in-mode; E12-6-2-1-grammar-in
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Observe(in field, Change())
Into: Observe(in other, Change())
*/
using System;
class Program
{
    static int checks, failures, field = 11, other = 5;
    static int Change() { field = 29; return 0; }
    static int Observe(in int value, int unused) { return value; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Observe(in field, Change());
        Check(result == 29, "explicit-input-reference-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
