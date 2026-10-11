/*
Rules: E12-19-1-anonymous-method-form; E12-19-1-forms-same-behavior; E12-19-1-delegate-conversion; E12-19-1-delegate-result; E12-19-7-conversion-result; E12-19-1-body-block
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: delegate(int value) { trace += "A"; return value * 3; }
Into: delegate(int value) { return value * 3; }
*/
using System;
delegate int Scale(int value);
class Program
{
    static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Scale first = delegate(int value) { trace += "A"; return value * 3; };
        Scale second = (int value) => { trace += "L"; return value * 3; };
        Check(trace == "", "conversion-does-not-invoke-inline-method");
        int a = first(7), b = second(7);
        Check(a == 21 && b == 21, "both-forms-reference-defined-method");
        Check(trace == "AL", "equivalent-body-effects-on-invocation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
