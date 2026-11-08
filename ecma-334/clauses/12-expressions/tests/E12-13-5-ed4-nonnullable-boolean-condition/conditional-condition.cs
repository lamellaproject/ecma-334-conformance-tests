/*
Rules: E12-13-5-ed4-nonnullable-boolean-condition
Authority: ECMA-334 4th ed 14.17
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-13-5-ed4-nonnullable-boolean-condition/conditional-condition.cs.part
Mutate: int result = condition ? 3 : 5;
Into: int result = condition == true ? 3 : 5;
*/
// ECMA-334 4th ed 14.17, p. 222 (PDF p. 244).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        bool? condition = false;
        int result = condition ? 3 : 5;
        Check(result == 5, "conditional-condition-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
