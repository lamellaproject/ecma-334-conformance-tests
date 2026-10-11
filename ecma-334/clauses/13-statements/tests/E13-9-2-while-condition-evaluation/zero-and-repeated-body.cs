/*
Rules: E13-9-2-while-condition-evaluation; E13-9-2-while-repeat; E13-9-2-while-false-exit
Authority: ECMA-334 7th ed 13.9.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: while (Gate()) trace += "B";
Into: do trace += "B"; while (Gate());
*/
using System;
class Program
{
    static int checks, failures, conditions, limit = 2;
    static string trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Gate() { trace += "C"; conditions++; return conditions <= limit; }
    static void Main()
    {
        while (Gate()) trace += "B";
        trace += "E";
        Check(trace == "CBCBCE", "normal-body-repeats-through-condition");
        trace = ""; conditions = 0; limit = 0;
        while (Gate()) { trace += "X"; }
        trace += "E";
        Check(trace == "CE", "initial-false-condition-skips-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
