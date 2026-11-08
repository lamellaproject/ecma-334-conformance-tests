/*
Rules: E22-5-3-2-ed3-conditional-output-parameter
Authority: ECMA-334 3rd ed 24.4.2.1
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E22-5-3-2-ed3-conditional-output-parameter/defined-output-call.cs.part
Mutate: Fill(out item)
Into: Fill(item)
*/
// ECMA-334 3rd ed 24.4.2.1, p. 376 (PDF p. 396).
#define CALLS
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    [System.Diagnostics.Conditional("CALLS")]
    static void Fill(out int slot) { slot = 37; }
    static int Main()
    {
        int item = 0;
        Fill(out item);
        Check(item == 37, "output");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
