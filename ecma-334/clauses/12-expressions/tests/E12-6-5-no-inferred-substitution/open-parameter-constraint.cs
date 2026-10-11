/*
Rules: E12-6-5-no-inferred-substitution; E12-6-5-elide-open-types; E12-6-5-limited-check
Authority: ECMA-334 7th ed 12.6.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Pick(3, value);
Into: Pick("label", value);
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Pick<T>(T first, int second) where T : class { calls++; }
    static void Main()
    {
        dynamic value = 8;
        bool rejected = false;
        try { Pick(3, value); }
        catch (Exception) { rejected = true; }
        Check(rejected, "constraint-is-deferred-with-unsubstituted-open-parameter");
        Check(calls == 0, "runtime-constraint-failure-does-not-enter-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
