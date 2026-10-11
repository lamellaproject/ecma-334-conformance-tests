/*
Rules: E6-3-2-grammar-new-line-2
Authority: ECMA-334 7th ed 6.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Source-Diagnostic: [{"case_id":"crlf-single-line","contains":"physical-crlf","file":"physical","line":"physical","severity":"warning","source":"#warning physical-crlf"}]
Mutate: \x0D\x0A
Into:  
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int amount = 0;
        // line comment
        amount = 31;
#warning physical-crlf
        Check(amount == 31, "crlf-ends-comment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
