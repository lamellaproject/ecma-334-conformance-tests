/*
Rules: E6-5-8-grammar-pp-compilation-unit-name-character-1; E6-5-8-reported-line-number; E6-5-8-reported-source-name
Authority: ECMA-334 7th ed 6.5.8
Version: 7.3
Expected: run
Stdout: OK 0
Source-Diagnostic: [{"case_id":"hash-filename","source":"#warning filename-marker","severity":"warning","file":"canopy#unit.cs","line":67,"contains":"filename-marker"}]
Mutate: #line 67 "canopy#unit.cs"
Into: #line 67 "canopy"unit.cs"
*/
#line 67 "canopy#unit.cs"
#warning filename-marker
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
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
