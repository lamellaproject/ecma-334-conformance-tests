/*
Rules: E6-5-5-first-true-section; E6-5-5-at-most-one-section; E6-5-5-section-controller; E6-5-5-selected-tokens; E6-5-5-grammar-pp-conditional-1; E6-5-5-grammar-pp-conditional-2; E6-5-5-grammar-pp-conditional-3; E6-5-5-grammar-pp-conditional-4; E6-5-5-grammar-pp-if-section-1; E6-5-5-grammar-pp-elif-section-1; E6-5-5-grammar-pp-else-section-1; E6-5-5-grammar-pp-endif-1
Authority: ECMA-334 7th ed 6.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #elif true // chosen
Into: #elif false // chosen
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
#elif true // chosen
        int amount = 11;
#elif true
        int amount = 23;
#else
        int amount = 31;
#endif
        Check(amount == 11, "only-first-true-section-selected");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
