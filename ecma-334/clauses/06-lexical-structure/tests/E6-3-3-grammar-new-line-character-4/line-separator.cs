/*
Rules: E6-3-3-grammar-new-line-character-4
Authority: ECMA-334 7th ed 6.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Source-Diagnostic: [{"case_id":"ls-single-line","contains":"physical-ls","file":"physical","line":"physical","severity":"warning","source":"#warning physical-ls"}]
Mutate: \xE2\x80\xA8
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
        // line comment         amount = 43;
#warning physical-ls
        Check(amount == 43, "ls-ends-comment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
