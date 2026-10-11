/*
Rules: E12-19-1-anonymous-method-omitted-compatibility; E12-19-3-omitted-signature-parameter-conversion
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: delegate { trace += "R"; }
Into: delegate(int value) { trace += "R"; }
*/
using System;
delegate void Ignore(ref int value);
class Program
{
    static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Ignore function = delegate { trace += "R"; };
        int item = 37;
        function(ref item);
        Check(trace == "R", "omitted-signature-allows-ref-target-parameter");
        Check(item == 37, "body-does-not-access-omitted-ref-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
