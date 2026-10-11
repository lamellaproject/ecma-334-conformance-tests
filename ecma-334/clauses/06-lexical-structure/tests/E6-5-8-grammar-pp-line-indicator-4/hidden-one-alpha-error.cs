/*
Rules: E6-5-8-grammar-pp-line-indicator-4; E6-5-8-grammar-pp-line-1; E6-5-1-grammar-pp-kind-3; E6-5-8-grammar-pp-compilation-unit-name-1; E6-5-8-grammar-pp-compilation-unit-name-character-1; E6-5-8-hidden-error-line; E6-5-1-grammar-pp-kind-4; E6-5-6-grammar-pp-message-1; E6-5-6-grammar-pp-diagnostic-1; E6-5-6-error-diagnostic
Authority: ECMA-334 7th ed 6.5.8
Version: 7.3
Expected: reject
Source-Diagnostic: [{"case_id":"hidden-one-alpha-error","source":"#error diagnostic-hidden-one-alpha-error","severity":"error","file":"alpha.origin","line":2,"contains":"diagnostic-hidden-one-alpha-error"}]
Generated: clauses/06-lexical-structure/generators/line-locations.py
*/
#line 1 "alpha.origin"
#line hidden
#error diagnostic-hidden-one-alpha-error
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
