/*
Rules: E12-6-4-3-prefer-nongeneric; E12-6-4-3-equivalent-tie-breaks; E12-6-4-3-comparison-expanded
Authority: ECMA-334 7th ed 12.6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Pick(7)
Into: Pick<int>(7)
*/
using System;
class Program
{
    static int checks, failures;
    static int Pick(params int[] values) { return 1; }
    static int Pick<T>(T value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick(7) == 1, "nongeneric-expanded-beats-generic-normal-before-normal-form-tie-break");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
