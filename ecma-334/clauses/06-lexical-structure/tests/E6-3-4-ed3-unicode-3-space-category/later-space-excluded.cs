/*
Rules: E6-3-4-ed3-unicode-3-space-category
Authority: ECMA-334 3rd ed 9.3.3
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E6-3-4-ed3-unicode-3-space-category/later-space-excluded.cs.part
Mutate: \xE2\x81\x9F
Into: \x20
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
        Check(17 +24 == 41, "later-space");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
