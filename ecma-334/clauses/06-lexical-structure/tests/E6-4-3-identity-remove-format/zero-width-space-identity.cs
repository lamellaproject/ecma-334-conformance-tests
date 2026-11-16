/*
Rules: E6-4-3-identity-remove-format; E6-4-3-grammar-formatting-character-2; E6-4-3-identifier-equivalence
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int read\u200Bout = 89;
Into: int read\u0062out = 89;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static void Main()
    {
        int read\u200Bout = 89;
        Check(readout == 89, "formatting-character-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
