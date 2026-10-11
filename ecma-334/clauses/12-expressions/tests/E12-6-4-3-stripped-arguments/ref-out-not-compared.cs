/*
Rules: E12-6-4-3-stripped-arguments; E12-6-4-3-comparison-ref-out
Authority: ECMA-334 7th ed 12.6.4.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Pick(out var result, 7)
Into: Pick(out var result, 7L)
*/
using System;
class Program
{
    static int checks, failures;
    static int Pick(out int result, long x) { result = 11; return 1; }
    static int Pick(out long result, int x) { result = 19L; return 2; }
    static int RefPick(ref int location, long x) { return 3; }
    static int RefPick(ref int location, int x) { return 4; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int selected = Pick(out var result, 7);
        Check(selected == 2 && result == 19L, "out-var-does-not-rank-output-parameter-types");
        int value = 0;
        Check(RefPick(ref value, 7) == 4, "ref-argument-is-removed-and-value-conversion-ranks-members");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
