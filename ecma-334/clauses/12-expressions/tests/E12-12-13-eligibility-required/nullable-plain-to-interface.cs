/*
Rules: E12-12-13-eligibility-required
Authority: ECMA-334 7th ed 12.12.13
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E12-12-13-eligibility-required/nullable-plain-to-interface.cs.part
Mutate: source as IDisposable
Into: (object)source as IDisposable
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
        Plain? source = new Plain();
        IDisposable result = source as IDisposable;
        Check(result == null, "unrelated-reference-after-object-repair");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
