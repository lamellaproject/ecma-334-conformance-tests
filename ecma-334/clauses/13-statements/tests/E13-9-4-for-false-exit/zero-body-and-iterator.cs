/*
Rules: E13-9-4-for-false-exit
Authority: ECMA-334 7th ed 13.9.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: for (Initialize(); gate; Step())
Into: for (Initialize(); !gate; Step())
*/
using System;
class Program
{
    static int checks, failures, iterations;
    static bool gate;
    static string trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Initialize() { trace += "I"; }
    static void Step() { trace += "S"; iterations++; gate = true; }
    static void Main()
    {
        int bodies = 0;
        for (Initialize(); gate; Step()) { trace += "B"; bodies++; }
        trace += "E";
        Check(trace == "IE", "initializer-then-false-condition-then-end");
        Check(bodies == 0 && iterations == 0, "false-condition-skips-body-and-iterator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
