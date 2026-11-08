/*
Rules: E6-3-4-ed3-unicode-3-space-category
Authority: ECMA-334 3rd ed 9.3.3
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E6-3-4-ed3-unicode-3-space-category/zero-width-space.cs.part
Mutate: \xE2\x80\x8B
Into: \xE2\x81\x9F
*/
// ECMA-334 3rd ed 9.3.3, p. 69 (PDF p. 89).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        Check(17​+24 == 41, "unicode3-space");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
