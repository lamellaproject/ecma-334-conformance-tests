/*
Rules: E12-15-left-type-result; E12-15-left-type-nonnull; E12-15-left-type-null; E12-15-type-preference
Authority: ECMA-334 7th ed 12.15
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Left(7) ?? Right(null)
Into: Right(null)
*/
using System;
class Program
{
    static string trace = "";
    static int? Left(int? n) { trace += "L"; return n; }
    static int? Right(int? n) { trace += "R"; return n; }
    static int Kind(int? n) { return 1; } static int Kind(object n) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var a = Left(7) ?? Right(null); Check(a == 7 && Kind(a) == 1 && trace == "L", "nullable-left-result");
        trace = ""; var b = Left(null) ?? Right(29); Check(b == 29 && Kind(b) == 1 && trace == "LR", "nullable-right-value");
        trace = ""; var c = Left(null) ?? Right(null); Check(c == null && Kind(c) == 1 && trace == "LR", "both-null-nullable-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
