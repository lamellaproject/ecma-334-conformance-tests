/*
Rules: E12-19-4-overload-resolution
Authority: ECMA-334 7th ed 12.19.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: () => 59
Into: () => 59L
*/
using System;
delegate int IntResult();
delegate long LongResult();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static string Choose(IntResult function) { return function() == 59 ? "int" : "wrong"; }
    static string Choose(LongResult function) { return function() == 59L ? "long" : "wrong"; }
    static void Main()
    {
        Check(Choose(() => 59) == "int", "lambda-result-selects-better-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
