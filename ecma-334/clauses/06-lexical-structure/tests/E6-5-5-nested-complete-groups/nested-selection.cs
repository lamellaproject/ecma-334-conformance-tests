/*
Rules: E6-5-5-nested-complete-groups
Authority: ECMA-334 7th ed 6.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #if false // inner
Into: #if true // inner
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#if true
#if false // inner
        int amount = 0;
#else
        int amount = 18;
#endif
#else
        int amount = 1;
#endif
        Check(amount == 18, "nested-group-controls-inner-source");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
