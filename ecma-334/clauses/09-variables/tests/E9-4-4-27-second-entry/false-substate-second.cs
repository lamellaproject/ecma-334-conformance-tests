/*
Rules: E9-4-4-27-second-entry
Authority: ECMA-334 7th ed 9.4.4.27
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: gate || (cell = 13) < 0
Into: gate && (cell = 13) < 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Read(bool gate)
    {
        int cell;
        // 9.4.4.27, p. 106: conditional-or enters its second operand after false.
        // The committee correction is variables.md, 9.4.4.27 at dotnet/csharpstandard
        // commit 6460eafbf957c24565c0ba099f6077e8c701e3c9.
        return (gate || (cell = 13) < 0) || cell == 13;
    }
    static void Main()
    {
        Check(Read(false), "or-second-reads-false-substate");
        Check(Read(true), "or-second-skipped-on-first-true");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
