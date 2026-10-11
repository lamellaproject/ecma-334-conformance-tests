/*
Rules: E12-8-8-nonnullable-retain-type; E12-8-8-nonnullable-retain-null; E12-8-8-nonnullable-retain-present; E12-8-8-receiver-once
Authority: ECMA-334 7th ed 12.8.8
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Fetch(true)?.Text
Into: Fetch(false)?.Text
*/
using System;
class Cell { public string Text { get { Program.reads++; return "maple"; } } }
class Program
{
    public static int reads;
    static int calls;
    static int checks, failures;
    static Cell Fetch(bool present) { calls++; return present ? new Cell() : null; }
    static int Kind(string value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var present = Fetch(true)?.Text;
        Check(Kind(present) == 1 && present == "maple", "reference-result-type-retained");
        Check(calls == 1 && reads == 1, "present-reference-evaluated-once");
        var absent = Fetch(false)?.Text;
        Check(Kind(absent) == 1 && absent == null, "reference-result-null");
        Check(calls == 2 && reads == 1, "absent-reference-evaluated-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
