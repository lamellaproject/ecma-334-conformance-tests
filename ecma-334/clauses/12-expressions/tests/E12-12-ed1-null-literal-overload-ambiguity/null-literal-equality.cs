/*
Rules: E12-12-ed1-null-literal-overload-ambiguity
Authority: ECMA-334 1st ed 14.9
Version: ISO-1
Expected: reject
Version-Witness: tests/E12-12-ed1-null-literal-overload-ambiguity/null-literal-equality.witness.cs.part
Mutate: null == null
Into: (object)null == null
*/
// ECMA-334 1st ed 14.9, p. 165 (PDF p. 179), lines 6-8. An equality or inequality between
// two untyped null literals undergoes ordinary operator overload resolution.
using System;
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool result, string label)
    {
        checks++;
        if (!result)
        {
            failures++;
            Console.WriteLine("FAIL " + label);
        }
    }
    static int Main()
    {
        Check((null == null) == true, "typed-null-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
