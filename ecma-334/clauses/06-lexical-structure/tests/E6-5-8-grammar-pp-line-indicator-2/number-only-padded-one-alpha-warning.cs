/*
Rules: E6-5-8-grammar-pp-line-indicator-2; E6-5-8-reported-line-number; E6-5-8-grammar-pp-line-1; E6-5-1-grammar-pp-kind-3; E6-5-8-grammar-pp-compilation-unit-name-1; E6-5-8-grammar-pp-compilation-unit-name-character-1; E6-5-1-grammar-pp-kind-4; E6-5-6-grammar-pp-message-1; E6-5-6-grammar-pp-diagnostic-2; E6-5-6-warning-diagnostic
Authority: ECMA-334 7th ed 6.5.8
Version: 7.3
Expected: run
Stdout: OK 0
Source-Diagnostic: [{"case_id":"number-only-padded-one-alpha-warning","source":"#warning diagnostic-number-only-padded-one-alpha-warning","severity":"warning","file":"alpha.origin","line":1,"contains":"diagnostic-number-only-padded-one-alpha-warning"}]
Generated: clauses/06-lexical-structure/generators/line-locations.py
*/
#line 1 "alpha.origin"
#line 0001
#warning diagnostic-number-only-padded-one-alpha-warning
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
