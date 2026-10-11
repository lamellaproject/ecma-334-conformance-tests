/*
Rules: E15-4-constant-expression-use
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: public const int Code = 191;
Into: public static readonly int Code = 191;
*/
using System;
class Limits { public const int Code = 191; }
class MarkAttribute : Attribute { public MarkAttribute(int code) { } }
[Mark(Limits.Code)]
class Marked { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        // Compile-time acceptance of the attribute argument is the observable result.
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
