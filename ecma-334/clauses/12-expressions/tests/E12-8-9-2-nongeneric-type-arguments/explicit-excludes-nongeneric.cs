/*
Rules: E12-8-9-2-nongeneric-type-arguments; E12-8-9-2-explicit-arity; E12-8-9-2-explicit-applicable
Authority: ECMA-334 7th ed 12.8.9.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Choose<int>(5)
Into: Choose(5)
*/
using System;
class Program
{
    static int checks, failures;
    static int Choose(int value) { return 1; }
    static int Choose<T>(object value) { return 2; }
    static int Choose<T, U>(int value) { return 3; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Choose<int>(5) == 2, "explicit-type-list-excludes-nongeneric-and-wrong-arity-candidates");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
