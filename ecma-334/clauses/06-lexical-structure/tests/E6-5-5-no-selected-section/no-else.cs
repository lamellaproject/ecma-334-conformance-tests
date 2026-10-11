/*
Rules: E6-5-5-no-selected-section
Authority: ECMA-334 7th ed 6.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #if false
Into: #if true
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int amount = 14;
#if false
        amount = 99;
#endif
        Check(amount == 14, "no-section-selected-without-else");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
