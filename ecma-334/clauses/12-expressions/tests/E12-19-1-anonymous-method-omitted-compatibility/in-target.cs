/*
Rules: E12-19-1-anonymous-method-omitted-compatibility; E12-19-3-omitted-signature-parameter-conversion
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: delegate { trace += "I"; }
Into: delegate(int value) { trace += "I"; }
*/
using System;
delegate void Ignore(in int value);
class Program
{
    static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Ignore function = delegate { trace += "I"; };
        int item = 41;
        function(in item);
        Check(trace == "I", "omitted-signature-allows-in-target-parameter");
        Check(item == 41, "body-does-not-access-omitted-in-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
