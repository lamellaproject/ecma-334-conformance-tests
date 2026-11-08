/*
Rules: E6-5-8-ed3-canonical-default-line-indicator
Authority: ECMA-334 3rd ed 9.5.7
Version: ISO-2
Expected: run
Stdout: OK 1
Diagnostic: warning
Source-Diagnostic: [{"case_id":"restored-origin","source":"    #warning restored-origin-marker","severity":"warning","file":"physical","line":"physical","contains":"restored-origin-marker"}]
Version-Witness: version-witnesses/E6-5-8-ed3-canonical-default-line-indicator/escaped-default-restores-origin.cs.part
Mutate: #line d\u0065fault
Into: #line 29 "mapped-name.cs"
*/
// ECMA-334 3rd ed 9.5.7, p. 84 (PDF p. 104).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    #line 613 "mapped-name.cs"
    #line d\u0065fault
    #warning restored-origin-marker
    static int Main()
    {
        Check(19 + 28 == 47, "program-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
