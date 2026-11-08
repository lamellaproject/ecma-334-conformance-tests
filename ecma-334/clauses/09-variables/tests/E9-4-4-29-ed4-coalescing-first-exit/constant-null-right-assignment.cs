/*
Rules: E9-4-4-29-ed4-coalescing-first-exit
Authority: ECMA-334 4th ed 12.3.3.29
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E9-4-4-29-ed4-coalescing-first-exit/constant-null-right-assignment.cs.part
Mutate: int value;
Into: int value = 0;
*/
// ECMA-334 4th ed 12.3.3.29, p. 133 (PDF p. 155).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static string Assign(out int value)
    {
        value = 59;
        return "cedar";
    }
    static int Main()
    {
        int value;
        string result = default(string) ?? Assign(out value);
        Check(value == 59 && result == "cedar", "right-operand-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
