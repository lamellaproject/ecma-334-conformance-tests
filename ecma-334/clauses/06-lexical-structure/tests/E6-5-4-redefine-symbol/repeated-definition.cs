/*
Rules: E6-5-4-redefine-symbol
Authority: ECMA-334 7th ed 6.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #define REPEATED // repeated
Into: #undef REPEATED // repeated
*/
#define REPEATED
#define REPEATED // repeated
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#if REPEATED
        int amount = 12;
#else
        int amount = 0;
#endif
        Check(amount == 12, "redefinition-is-permitted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
