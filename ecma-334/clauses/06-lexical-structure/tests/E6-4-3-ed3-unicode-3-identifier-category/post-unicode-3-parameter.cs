/*
Rules: E6-4-3-ed3-unicode-3-identifier-category; E5-ed3-character-conformance-authorities
Authority: ECMA-334 3rd ed 9.4.2
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E6-4-3-ed3-unicode-3-identifier-category/post-unicode-3-parameter.cs.part
Mutate: int \u0221
Into: int item
*/
// ECMA-334 3rd ed 9.4.2, p. 70 (PDF p. 90).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Read(int \u0221) { return 37; }
    static int Main()
    {
        Check(Read(19) == 37, "parameter-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
