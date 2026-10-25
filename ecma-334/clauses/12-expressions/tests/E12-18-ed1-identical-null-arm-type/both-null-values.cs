/*
Rules: E12-18-ed1-identical-null-arm-type; E6-4-5-7-ed1-null-literal-has-type
Authority: ECMA-334 1st ed 14.12
Version: ISO-1
Expected: run
Stdout: OK 2
Diagnostic: none
Version-Witness: tests/E12-18-ed1-identical-null-arm-type/both-null-values-witness.cs.part
Mutate: return side ? null : null;
Into: return side ? new object() : null;
*/
// ECMA-334 1st ed 9.4.4.6, p. 61 (PDF p. 75), line 49 gives each null literal the null
// type. ECMA-334 1st ed 14.12, p. 173 (PDF p. 187), lines 1-3 selects equal operand types.
// ECMA-334 1st ed 13.1.4, p. 114 (PDF p. 128), line 31 converts that type to any reference
// type. Thus the old result can be returned as object. The 7th edition's 6.4.5.7 gives
// null no type and12.18 refuses two untyped arms. No later feature is required by this old
// derivation. The witness explicitly types one null arm.
using System;
class Entry
{
    static int checks;
    static int failures;
    static object Choose(bool side)
    {
        return side ? null : null;
    }
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    public static int Main()
    {
        Check(Choose(true) == null, "true-null-arm");
        Check(Choose(false) == null, "false-null-arm");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
