/*
Rules: E6-5-5-skipped-directive-no-effects; E6-5-5-skipped-nested-sections
Authority: ECMA-334 7th ed 6.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #if false // skipped outer
Into: #if true // skipped outer
*/
#define KEPT
#if false // skipped outer
#define BLOCKED
#undef KEPT
#error this diagnostic must be skipped
#if true
#define NESTED
#warning this warning must be skipped
#endif
#endif
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#if KEPT && !BLOCKED && !NESTED
        int amount = 31;
#else
        int amount = 0;
#endif
        Check(amount == 31, "skipped-directives-do-not-change-symbols");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
