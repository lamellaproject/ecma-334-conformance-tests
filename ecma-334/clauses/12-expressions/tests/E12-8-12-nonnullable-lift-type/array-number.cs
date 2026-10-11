/*
Rules: E12-8-12-nonnullable-lift-type; E12-8-12-nonnullable-target-type; E12-8-12-nonnullable-lift-null; E12-8-12-nonnullable-lift-present; E12-8-12-receiver-once
Authority: ECMA-334 7th ed 12.8.12
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Fetch(true)?[Index()]
Into: Fetch(false)?[Index()]
*/
using System;
class Program
{
    static int checks, failures;
    static string trace = "";
    static int[] Fetch(bool present) { trace += "R"; return present ? new int[] { 3, 53 } : null; }
    static int Index() { trace += "I"; return 1; }
    static int Kind(int value) { return 1; }
    static int Kind(int? value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var present = Fetch(true)?[Index()];
        Check(Kind(present) == 2 && present == 53, "array-element-value-type-lifted");
        Check(trace == "RI", "array-receiver-and-index-once");
        trace = "";
        var absent = Fetch(false)?[Index()];
        Check(Kind(absent) == 2 && !absent.HasValue, "absent-array-element-result-null");
        Check(trace == "R", "absent-array-skips-index");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
