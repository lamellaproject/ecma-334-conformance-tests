/*
Rules: E6-3-3-grammar-new-line-character-3
Authority: ECMA-334 7th ed 6.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Source-Diagnostic: [{"case_id":"nel-single-line","contains":"physical-nel","file":"physical","line":"physical","severity":"warning","source":"#warning physical-nel"}]
Mutate: \xC2\x85
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
        // line comment        amount = 41;
#warning physical-nel
        Check(amount == 41, "nel-ends-comment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
