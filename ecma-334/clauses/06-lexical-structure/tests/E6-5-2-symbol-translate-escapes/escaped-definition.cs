/*
Rules: E6-5-2-symbol-translate-escapes; E6-5-2-symbol-equivalence
Authority: ECMA-334 7th ed 6.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: \u006e
Into: \u006d
*/
#define Sig\u006eal
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#if Signal
        int amount = 21;
#else
        int amount = 0;
#endif
        Check(amount == 21, "escaped-symbol-is-unescaped-symbol");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
