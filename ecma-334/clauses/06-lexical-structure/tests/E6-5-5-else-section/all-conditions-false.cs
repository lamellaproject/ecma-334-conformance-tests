/*
Rules: E6-5-5-else-section
Authority: ECMA-334 7th ed 6.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #elif false
Into: #elif true
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#if false
        int amount = 0;
#elif false
        int amount = 1;
#else
        int amount = 17;
#endif
        Check(amount == 17, "else-selected-when-all-false");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
