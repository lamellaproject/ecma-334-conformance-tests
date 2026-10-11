/*
Rules: E13-9-2-while-break-permitted
Authority: ECMA-334 7th ed 13.9.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: break;
Into: continue;
*/
using System;
class Program
{
    static int checks, failures, conditions;
    static string trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Gate() { trace += "C"; conditions++; return conditions <= 2; }
    static void Main()
    {
        while (Gate()) { trace += "B"; break; }
        trace += "E";
        Check(trace == "CBE", "break-transfers-to-while-end");
        Check(conditions == 1, "break-does-not-reevaluate-condition");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
