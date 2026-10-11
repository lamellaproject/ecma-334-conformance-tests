/*
Rules: E13-9-3-do-break-permitted
Authority: ECMA-334 7th ed 13.9.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: break;
Into: continue;
*/
using System;
class Program
{
    static int checks, failures;
    static string trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Gate() { trace += "C"; return false; }
    static void Main()
    {
        do { trace += "B"; break; } while (Gate());
        trace += "E";
        Check(trace == "BE", "break-reaches-do-end-without-condition");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
