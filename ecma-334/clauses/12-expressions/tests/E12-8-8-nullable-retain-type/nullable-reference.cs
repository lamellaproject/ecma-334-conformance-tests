/*
Rules: E12-8-8-nullable-retain-type; E12-8-8-nullable-retain-null; E12-8-8-nullable-retain-present; E12-8-8-receiver-once
Authority: ECMA-334 7th ed 12.8.8
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Fetch(true)?.Text
Into: Fetch(false)?.Text
*/
using System;
struct Cell { public string Text { get { Program.reads++; return "cedar"; } } }
class Program
{
    public static int reads;
    static int calls;
    static int checks, failures;
    static Cell? Fetch(bool present) { calls++; return present ? new Cell() : (Cell?)null; }
    static int Kind(string value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var present = Fetch(true)?.Text;
        Check(Kind(present) == 1 && present == "cedar", "reference-result-type-retained");
        Check(calls == 1 && reads == 1, "present-nullable-receiver-once");
        var absent = Fetch(false)?.Text;
        Check(Kind(absent) == 1 && absent == null, "reference-result-null");
        Check(calls == 2 && reads == 1, "absent-nullable-receiver-skips-getter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
