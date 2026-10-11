/*
Rules: E12-17-infer-out-type; E12-17-declares-local; E12-17-form; E12-17-var-form; E12-17-out-argument; E12-17-implicit-classification; E12-17-implicit-no-type; E12-17-named-declaration-space
Authority: ECMA-334 7th ed 12.17
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: out var number
Into: out var _
*/
using System;
class Program
{
    static void Fill(out int value) { value = 41; }
    static int Kind(int value) { return 1; } static int Kind(long value) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Fill(out var number); Check(number == 41 && Kind(number) == 1, "out-variable-inferred-type-and-enclosing-scope");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
