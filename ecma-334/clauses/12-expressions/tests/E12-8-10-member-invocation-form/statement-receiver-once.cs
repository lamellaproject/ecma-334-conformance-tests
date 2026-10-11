/*
Rules: E12-8-10-member-invocation-form; E12-8-10-statement-context; E12-8-10-no-value-classification; E12-8-10-statement-null; E12-8-10-statement-present; E12-8-10-statement-receiver-once
Authority: ECMA-334 7th ed 12.8.10
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Fetch(true)?.Touch(Argument());
Into: Fetch(false)?.Touch(Argument());
*/
using System;
class Cell { public void Touch(int value) { Program.trace += "M"; Program.total += value; } }
class Program
{
    public static string trace = "";
    public static int total;
    static int checks, failures;
    static Cell Fetch(bool present) { trace += "R"; return present ? new Cell() : null; }
    static int Argument() { trace += "A"; return 11; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Fetch(true)?.Touch(Argument());
        Check(trace == "RAM" && total == 11, "nonnull-statement-invokes-receiver-once");
        trace = "";
        Fetch(false)?.Touch(Argument());
        Check(trace == "R" && total == 11, "null-statement-skips-arguments-and-call");
        Cell receiver = null;
        receiver?.Touch(19);
        Check(total == 11, "void-conditional-call-is-valid-statement");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
