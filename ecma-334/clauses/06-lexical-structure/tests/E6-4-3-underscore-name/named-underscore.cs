/*
Rules: E6-4-3-underscore-name
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int _ = 17;
Into: int lost = 17;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int _ = 17;
        int chosen = _;
        Check(chosen == 17, "underscore-is-a-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
