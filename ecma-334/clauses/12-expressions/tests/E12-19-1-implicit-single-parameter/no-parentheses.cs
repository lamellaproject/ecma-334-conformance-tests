/*
Rules: E12-19-1-implicit-single-parameter; E12-19-1-implicit-parameter-form; E12-19-1-lambda-inferred-parameters; E12-19-1-inferred-parameter-types; E12-22-lambda-form
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: value => IsShort(value) ? value + 1L : -1L
Into: (long value) => IsShort(value) ? value + 1L : -1L
*/
using System;
delegate long Widen(short value);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool IsShort<T>(T value) { return typeof(T) == typeof(short); }
    static void Main()
    {
        Widen function = value => IsShort(value) ? value + 1L : -1L;
        Check(function(13) == 14L, "single-inferred-parameter-without-parentheses");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
