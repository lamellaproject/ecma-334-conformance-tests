/*
Rules: E12-19-1-explicit-signature-form; E12-19-1-explicit-parentheses; E12-19-1-explicit-parameter-list; E12-19-1-explicit-parameter-form; E12-19-1-lambda-explicit-parameters; E12-19-1-explicit-parameter-types; E12-19-1-lambda-form; E12-19-1-body-block; E12-19-1-inline-method; E12-19-2-signature-names; E12-19-2-signature-types; E12-19-2-parameter-scope; E12-19-3-declared-parameter-access
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (int first, long second) =>
Into: (long first, int second) =>
*/
using System;
delegate long Combine(int first, long second);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool HasType<T>(T value, Type type) { return typeof(T) == type; }
    static void Main()
    {
        Combine function = (int first, long second) =>
        {
            Check(HasType(first, typeof(int)) && HasType(second, typeof(long)), "explicit-parameter-types-in-order");
            long local = first * 10L + second;
            return local;
        };
        Check(function(3, 7L) == 37L, "explicit-parameter-names-in-body-scope");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
