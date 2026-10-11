/*
Rules: E12-8-10-element-invocation-form; E12-8-10-statement-null; E12-8-10-statement-present; E12-8-10-statement-receiver-once
Authority: ECMA-334 7th ed 12.8.10
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Fetch(true)?[Index()](Argument());
Into: Fetch(false)?[Index()](Argument());
*/
using System;
class Program
{
    static int checks, failures;
    static string trace = "";
    static int total;
    static void Touch(int value) { trace += "M"; total += value; }
    static Action<int>[] Fetch(bool present) { trace += "R"; return present ? new Action<int>[] { Touch } : null; }
    static int Index() { trace += "I"; return 0; }
    static int Argument() { trace += "A"; return 13; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Fetch(true)?[Index()](Argument());
        Check(trace == "RIAM" && total == 13, "conditional-element-then-delegate-invocation");
        trace = "";
        Fetch(false)?[Index()](Argument());
        Check(trace == "R" && total == 13, "null-array-skips-index-arguments-and-delegate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
