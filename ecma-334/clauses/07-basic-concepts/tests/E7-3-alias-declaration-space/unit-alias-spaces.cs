/*
Rules: E7-3-alias-declaration-space; E7-3-using-alias-declaration
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"program":{"units":[{"defines":["FIRST_UNIT"],"source":"self"},{"defines":["SECOND_UNIT"],"source":"self"}]}}
Mutate: using Slot = System.String;
Into: using Slot = System.Int32;
*/
using System;
#if FIRST_UNIT
using Slot = System.Int32;
class First { public static Slot Read() { return 31; } }
#elif SECOND_UNIT
using Slot = System.String;
class Second { public static Slot Read() { return "leaf"; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(First.Read() == 31, "first-unit-alias");
        Check(Second.Read() == "leaf", "second-unit-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
