/*
Rules: E12-13-5-ed4-nonnullable-boolean-condition
Authority: ECMA-334 4th ed 14.17
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-13-5-ed4-nonnullable-boolean-condition/do-condition.cs.part
Mutate: do { result++; } while (condition);
Into: do { result++; } while (condition == true);
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
        int result = 0;
        do { result++; } while (condition);
        Check(result == 1, "do-condition-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
