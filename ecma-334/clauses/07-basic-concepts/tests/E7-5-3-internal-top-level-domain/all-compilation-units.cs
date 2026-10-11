/*
Rules: E7-5-3-internal-top-level-domain; E7-5-3-program-text-definition; E7-5-2-internal-modifier
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: run
Stdout: OK 1
Fixture: {"program":{"units":[{"defines":["FIRST_UNIT"],"source":"self"},{"defines":["SECOND_UNIT"],"source":"self"}]}}
Mutate: internal class AssemblyItem
Into: private class AssemblyItem
*/
using System;
#if FIRST_UNIT
internal class AssemblyItem { public static int Read() { return 47; } }
#elif SECOND_UNIT
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(AssemblyItem.Read() == 47, "internal-type-from-another-compilation-unit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
