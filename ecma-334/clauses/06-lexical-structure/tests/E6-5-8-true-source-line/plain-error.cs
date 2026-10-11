/*
Rules: E6-5-8-true-source-line; E6-5-8-true-source-name; E6-5-1-grammar-pp-kind-4; E6-5-6-grammar-pp-message-1; E6-5-6-grammar-pp-diagnostic-1; E6-5-6-error-diagnostic
Authority: ECMA-334 7th ed 6.5.8
Version: 7.3
Expected: reject
Source-Diagnostic: [{"case_id":"plain-error","source":"#error diagnostic-plain-error","severity":"error","file":"physical","line":"physical","contains":"diagnostic-plain-error"}]
Generated: clauses/06-lexical-structure/generators/line-locations.py
*/
// No preceding line directive.
#error diagnostic-plain-error
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
