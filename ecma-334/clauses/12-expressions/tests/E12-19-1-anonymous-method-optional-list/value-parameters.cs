/*
Rules: E12-19-1-anonymous-method-optional-list; E12-19-1-anonymous-method-omitted-compatibility; E12-19-3-omitted-signature-parameter-conversion
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: delegate { trace += "D"; return 29; }
Into: delegate() { trace += "D"; return 29; }
*/
using System;
delegate int Ignore(int first, string second);
class Program
{
    static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Argument() { trace += "P"; return 11; }
    static void Main()
    {
        Ignore function = delegate { trace += "D"; return 29; };
        Check(function(Argument(), "argument") == 29, "omitted-list-converts-to-parameterized-delegate");
        Check(trace == "PD", "arguments-evaluate-before-parameterless-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
