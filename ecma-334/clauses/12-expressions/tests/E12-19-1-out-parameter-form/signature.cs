/*
Rules: E12-19-1-out-parameter-form; E12-19-1-explicit-parameter-form; E12-19-3-declared-parameter-access
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (out int value) =>
Into: (ref int value) =>
*/
using System;
delegate void Set(out int value);
class Program
{
    static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Set function = (out int value) => { trace += "S"; value = 23; };
        int item;
        function(out item);
        Check(item == 23, "out-parameter-assigns-caller-before-return");
        Check(trace == "S", "out-body-executes-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
