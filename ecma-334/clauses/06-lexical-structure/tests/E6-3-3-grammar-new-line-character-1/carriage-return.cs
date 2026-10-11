/*
Rules: E6-3-3-grammar-new-line-character-1
Authority: ECMA-334 7th ed 6.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Source-Diagnostic: [{"case_id":"cr-single-line","contains":"physical-cr","file":"physical","line":"physical","severity":"warning","source":"#warning physical-cr"}]
Mutate: \x0D
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
        // line comment        amount = 37;
#warning physical-cr
        Check(amount == 37, "cr-ends-comment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
