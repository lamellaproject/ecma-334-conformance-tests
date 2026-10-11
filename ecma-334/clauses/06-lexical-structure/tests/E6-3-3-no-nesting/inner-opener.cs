/*
Rules: E6-3-3-no-nesting; E6-3-3-delimited-openers-ordinary
Authority: ECMA-334 7th ed 6.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: /* outer /* inner
Into: / outer /* inner
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int amount = /* outer /* inner */ 14;
        Check(amount == 14, "first-terminator-closes-comment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
