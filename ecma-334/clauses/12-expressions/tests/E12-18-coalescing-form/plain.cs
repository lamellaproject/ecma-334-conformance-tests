/*
Rules: E12-18-coalescing-form
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: First() ?? Second()
Into: Second() ?? First()
*/
using System;
class Program
{
    static string trace = "";
    static string present = "present";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static string First() { trace += "F"; return present; }
    static string Second() { trace += "S"; return "fallback"; }
    static void Main()
    {
        var value = First() ?? Second();
        Check(trace == "F", "conditional-without-question-token");
        Check(object.ReferenceEquals(value, present), "coalescing-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
