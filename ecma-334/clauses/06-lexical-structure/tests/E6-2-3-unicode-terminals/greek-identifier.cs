/*
Rules: E6-2-3-unicode-terminals
Authority: ECMA-334 7th ed 6.2.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: \xCE\xA9
Into: X
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int Ω = 23;
        Check(\u03A9 == 23, "unicode-identifier-token");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
