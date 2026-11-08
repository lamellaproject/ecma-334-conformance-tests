/*
Rules: E6-3-4-ed4-unicode-4-space-category
Authority: ECMA-334 4th ed 9.3.3
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E6-3-4-ed4-unicode-4-space-category/medium-mathematical-space.cs.part
Mutate: \xE2\x81\x9F
Into: \xCD\xB8
*/
// ECMA-334 4th ed 9.3.3, p. 69 (PDF p. 91).
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
        int value = 19 + 4;
        Check(value == 23, "space-separated-addition");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
