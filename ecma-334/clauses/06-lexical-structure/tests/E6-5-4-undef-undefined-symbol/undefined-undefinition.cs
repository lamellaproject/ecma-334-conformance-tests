/*
Rules: E6-5-4-undef-undefined-symbol
Authority: ECMA-334 7th ed 6.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #undef ABSENT
Into: #define ABSENT
*/
#undef ABSENT
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#if ABSENT
        int amount = 0;
#else
        int amount = 13;
#endif
        Check(amount == 13, "undefining-undefined-symbol-is-permitted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
