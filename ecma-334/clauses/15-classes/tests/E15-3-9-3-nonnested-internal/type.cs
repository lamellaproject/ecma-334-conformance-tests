/*
Rules: E15-3-9-3-nonnested-internal
Authority: ECMA-334 7th ed 15.3.9.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal class Token
Into: private class Token
*/
using System;
internal class Token { public int Read() { return 263; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Token().Read() == 263, "internal-nonnested-type-accessible-within-assembly");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
