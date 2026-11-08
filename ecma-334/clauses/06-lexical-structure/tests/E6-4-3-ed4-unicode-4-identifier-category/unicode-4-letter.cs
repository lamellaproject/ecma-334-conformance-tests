/*
Rules: E6-4-3-ed4-unicode-4-identifier-category
Authority: ECMA-334 4th ed 9.4.2
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E6-4-3-ed4-unicode-4-identifier-category/unicode-4-letter.cs.part
Mutate: return \u0221;
Into: return 0;
*/
// ECMA-334 4th ed 9.4.2, p. 70 (PDF p. 92).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Read(int \u0221) { return \u0221; }
    static int Main()
    {
        Check(Read(47) == 47, "unicode-letter-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
