/*
Rules: E12-18-ed1-identical-null-arm-type; E6-4-5-7-ed1-null-literal-has-type
Authority: ECMA-334 1st ed 14.12
Version: ISO-1
Expected: run
Stdout: OK 2
Version-Witness: version-witnesses/E12-18-ed1-identical-null-arm-type/null-arm-reference-result.cs.part
Mutate: index == 0 ? null : null
Into: index == 0 ? new object() : null
*/
// ECMA-334 1st ed 14.12, p. 173 (PDF p. 187).
using System;
class NullArms
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        for (int index = 0; index < 2; index++)
        {
            object result = index == 0 ? null : null;
            Check((object)result == (object)null, "null-result");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
