/*
Rules: E12-8-9-2-inferred-type-arguments; E12-8-9-2-inferred-applicable; E12-8-9-2-generic-overload-substitution
Authority: ECMA-334 7th ed 12.8.9.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Choose(31)
Into: Choose((object)31)
*/
using System;
class Program
{
    static int checks, failures;
    static int Choose<T>(T value) { return 1; }
    static int Choose(object value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Choose(31) == 1, "inferred-int-parameter-compared-after-substitution");
        Check(Choose<object>(31) == 1, "explicit-object-parameter-is-applicable-by-boxing");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
