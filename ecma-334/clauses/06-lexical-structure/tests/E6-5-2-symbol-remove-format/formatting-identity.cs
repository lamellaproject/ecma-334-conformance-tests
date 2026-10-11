/*
Rules: E6-5-2-symbol-remove-format; E6-5-2-symbol-equivalence
Authority: ECMA-334 7th ed 6.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: \u200c
Into: \u0041
*/
#define For\u200cmat
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#if Format
        int amount = 22;
#else
        int amount = 0;
#endif
        Check(amount == 22, "symbol-formatting-character-removed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
