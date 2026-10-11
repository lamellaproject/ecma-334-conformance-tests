/*
Rules: E12-8-17-type-parameter-result; E12-8-17-type-parameter-operand
Authority: ECMA-334 7th ed 12.8.17
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static Type Bound<T>() { return typeof(T); }
Into: static Type Bound<T>() { return typeof(object); }
*/
using System;
class Program
{
    static Type Bound<T>() { return typeof(T); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Bound<int>() == typeof(int), "typeof-bound-value-type");
        Check(Bound<string>() == typeof(string), "typeof-bound-reference-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
