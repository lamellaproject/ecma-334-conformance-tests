/*
Rules: E12-12-13-eligibility-required
Authority: ECMA-334 7th ed 12.12.13
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E12-12-13-eligibility-required/nullable-keyword-to-string.cs.part
Mutate: source as string
Into: (object)source as string
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    struct Plain { }
    static int Main()
    {
        int? source = 27;
        string result = source as string;
        Check(result == null, "unrelated-reference-after-object-repair");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
