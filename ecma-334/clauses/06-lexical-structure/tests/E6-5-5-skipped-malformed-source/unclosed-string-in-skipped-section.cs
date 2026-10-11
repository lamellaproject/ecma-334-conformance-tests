/*
Rules: E6-5-5-skipped-malformed-source; E6-5-5-skipped-no-program-tokens; E6-3-1-directive-skipping
Authority: ECMA-334 7th ed 6.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #if false
Into: #if true
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int amount = 13;
#if false
        amount = "unterminated { $ class impossible
#endif
        Check(amount == 13, "skipped-source-produces-no-program-tokens");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
