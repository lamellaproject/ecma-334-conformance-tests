/*
Rules: E12-6-3-1-failed-candidate-excluded; E12-6-3-1-failure-not-error; E12-6-3-12-fixing-failure
Authority: ECMA-334 7th ed 12.6.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Pick(8, "owl")
Into: Pick(8, 9)
*/
using System;
class Program
{
    static int checks, failures;
    static int Pick<T>(T first, T second) { return 1; }
    static int Pick(object first, object second) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick(8, "owl") == 2, "unfixable-generic-candidate-does-not-poison-valid-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
