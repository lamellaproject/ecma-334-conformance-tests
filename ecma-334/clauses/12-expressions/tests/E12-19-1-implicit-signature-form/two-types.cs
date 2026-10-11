/*
Rules: E12-19-1-implicit-signature-form; E12-19-1-implicit-parentheses; E12-19-1-implicit-parameter-list; E12-19-1-implicit-parameter-form; E12-19-1-lambda-inferred-parameters; E12-19-1-inferred-parameter-types; E12-19-1-body-expression
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (first, second) =>
Into: first =>
*/
using System;
delegate int Combine(short first, byte second);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Correct<A, B>(A first, B second)
    { Check(typeof(A) == typeof(short) && typeof(B) == typeof(byte), "delegate-supplies-parameter-types"); return true; }
    static void Main()
    {
        Combine function = (first, second) => Correct(first, second) ? first * 10 + second : -1;
        Check(function(5, 9) == 59, "inferred-comma-separated-parameters");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
