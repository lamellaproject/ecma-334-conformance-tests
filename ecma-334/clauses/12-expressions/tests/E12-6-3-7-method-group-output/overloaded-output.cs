/*
Rules: E12-6-3-7-method-group-output; E12-6-3-4-input-types; E12-6-3-5-output-types
Authority: ECMA-334 7th ed 12.6.3.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Apply(5, Grow)
Into: Apply("x", Grow)
*/
using System;
class Program
{
    static int checks, failures;
    static long Grow(int value) { return value + 12L; }
    static string Grow(string value) { return value; }
    static U Apply<T, U>(T value, Func<T, U> function) { return function(value); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        long result = Apply(5, Grow);
        Check(result == 17L, "fixed-input-selects-method-group-return-before-output-inference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
