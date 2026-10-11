/*
Rules: E12-6-4-4-prefer-value-mode; E12-6-4-4-mode-only-overload; E12-6-4-3-prefer-passing-mode
Authority: ECMA-334 7th ed 12.6.4.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Pick(value)
Into: Pick(in value)
*/
using System;
class Program
{
    static int checks, failures;
    static int Pick(int x) { return 1; }
    static int Pick(in int x) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 3;
        Check(Pick(value) == 1, "unmodified-variable-prefers-value-passing");
        Check(Pick(value + 2) == 1, "unmodified-expression-prefers-value-passing");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
