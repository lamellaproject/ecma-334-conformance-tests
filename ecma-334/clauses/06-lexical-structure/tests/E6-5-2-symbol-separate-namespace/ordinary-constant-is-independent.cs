/*
Rules: E6-5-2-symbol-separate-namespace
Authority: ECMA-334 7th ed 6.5.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: #define TOKEN
Into: #undef TOKEN
*/
#define TOKEN
using System;
class Program
{
    const bool TOKEN = false;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#if TOKEN
        int amount = 18;
#else
        int amount = 0;
#endif
        Check(amount == 18, "preprocessor-symbol-is-true");
        Check(TOKEN == false, "program-constant-is-false");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
