/*
Rules: E6-3-3-grammar-new-line-character-5
Authority: ECMA-334 7th ed 6.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Source-Diagnostic: [{"case_id":"ps-single-line","contains":"physical-ps","file":"physical","line":"physical","severity":"warning","source":"#warning physical-ps"}]
Mutate: \xE2\x80\xA9
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
        // line comment         amount = 47;
#warning physical-ps
        Check(amount == 47, "ps-ends-comment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
