/*
Rules: E6-5-8-ed2-line-indicator-forms
Authority: ECMA-334 2nd ed 9.5.7
Version: ISO-1
Expected: reject
Version-Witness: version-witnesses/E6-5-8-ed2-line-indicator-forms/hidden-indicator.cs.part
Mutate: #line hidden
Into: #line default
*/
// ECMA-334 2nd ed 9.5.7, p. 68 (PDF p. 84).
using System;
#line hidden
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
        int value = 23;
        Check(value == 23, "ordinary-source");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
