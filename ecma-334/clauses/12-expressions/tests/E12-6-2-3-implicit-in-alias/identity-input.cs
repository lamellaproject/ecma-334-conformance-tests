/*
Rules: E12-6-2-3-implicit-in-alias; E12-6-2-1-expression-mode
Authority: ECMA-334 7th ed 12.6.2.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Observe(field, Change())
Into: Observe(field + 0, Change())
*/
using System;
class Program
{
    static int checks, failures, field = 11;
    static int Change() { field = 29; return 0; }
    static int Observe(in int value, int unused) { return value; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Observe(field, Change());
        Check(result == 29, "identity-variable-input-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
