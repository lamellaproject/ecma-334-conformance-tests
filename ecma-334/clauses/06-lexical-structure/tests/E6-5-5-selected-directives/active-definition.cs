/*
Rules: E6-5-5-selected-directives
Authority: ECMA-334 7th ed 6.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #if true // definitions
Into: #if false // definitions
*/
#if true // definitions
#define ACTIVE
#else
#define INACTIVE
#endif
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#if ACTIVE && !INACTIVE
        int amount = 21;
#else
        int amount = 0;
#endif
        Check(amount == 21, "selected-directive-has-prescribed-effect");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
