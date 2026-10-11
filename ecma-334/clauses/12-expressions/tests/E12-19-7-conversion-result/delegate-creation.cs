/*
Rules: E12-19-7-conversion-result; E12-19-1-delegate-conversion; E12-19-1-delegate-result
Authority: ECMA-334 7th ed 12.19.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Transform((int value) => { trace += "L"; return value + 73; })
Into: new Transform((int value) => value + 73)
*/
using System;
delegate int Transform(int value);
class Program
{
    static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Transform function = new Transform((int value) => { trace += "L"; return value + 73; });
        Check(trace == "", "delegate-creation-converts-without-invoking");
        Check(function(7) == 80 && trace == "L", "created-delegate-references-anonymous-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
