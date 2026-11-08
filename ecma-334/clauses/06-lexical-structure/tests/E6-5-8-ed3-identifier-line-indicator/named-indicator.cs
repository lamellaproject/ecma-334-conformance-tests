/*
Rules: E6-5-8-ed3-identifier-line-indicator
Authority: ECMA-334 3rd ed 9.5.7
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E6-5-8-ed3-identifier-line-indicator/named-indicator.cs.part
Mutate: #line Cedar
Into: #line "Cedar"
*/
// ECMA-334 3rd ed 9.5.7, p. 83 (PDF p. 103).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    #line Cedar
    static int Main()
    {
        Check(17 + 26 == 43, "program-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
