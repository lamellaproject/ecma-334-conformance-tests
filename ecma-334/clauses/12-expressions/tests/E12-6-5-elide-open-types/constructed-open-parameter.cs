/*
Rules: E12-6-5-elide-open-types; E12-6-5-no-inferred-substitution; E12-6-5-limited-check
Authority: ECMA-334 7th ed 12.6.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Pick(3, value);
Into: Pick(new Box<string>(), value);
*/
using System;
class Box<T> { }
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Pick<T>(Box<T> first, int second) { calls++; }
    static void Main()
    {
        dynamic value = 8;
        bool rejected = false;
        try { Pick(3, value); }
        catch (Exception) { rejected = true; }
        Check(rejected, "open-constructed-parameter-is-elided-at-compile-time");
        Check(calls == 0, "runtime-inference-failure-does-not-enter-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
