/*
Rules: E6-5-2-symbol-compilation-unit-scope; E6-1-compilation-units
Authority: ECMA-334 7th ed 6.5.2
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"program":{"units":[{"source":"self"},{"source":"tests/E6-5-2-symbol-compilation-unit-scope/other.cs.part"}]}}
Mutate: #define LOCAL
Into: #undef LOCAL
*/
#define LOCAL
#undef EXTERNAL
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#if LOCAL && !EXTERNAL
        int amount = 1;
#else
        int amount = 0;
#endif
        Check(amount == 1, "primary-symbols-are-local");
        Check(OtherUnit.Number == 14, "companion-symbols-are-local");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
