/*
Rules: E13-9-4-for-break-permitted
Authority: ECMA-334 7th ed 13.9.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: break;
Into: continue;
*/
using System;
class Program
{
    static int checks, failures, conditions, iterations;
    static string trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Initialize() { trace += "I"; }
    static bool Gate() { trace += "C"; conditions++; return conditions <= 2; }
    static void Step() { trace += "S"; iterations++; }
    static void Main()
    {
        for (Initialize(); Gate(); Step()) { trace += "B"; break; }
        trace += "E";
        Check(trace == "ICBE", "break-goes-directly-to-for-end");
        Check(conditions == 1 && iterations == 0, "break-skips-iterator-and-next-condition");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
