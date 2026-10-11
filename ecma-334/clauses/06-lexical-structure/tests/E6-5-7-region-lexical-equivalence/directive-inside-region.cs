/*
Rules: E6-5-7-region-lexical-equivalence
Authority: ECMA-334 7th ed 6.5.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #region
Into: #if false
*/
#region
#define WITHIN
#endregion
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#if WITHIN
        int amount = 14;
#else
        int amount = 0;
#endif
        Check(amount == 14, "region-body-is-lexically-active");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
