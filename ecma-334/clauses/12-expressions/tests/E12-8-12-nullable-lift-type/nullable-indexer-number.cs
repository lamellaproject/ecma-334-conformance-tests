/*
Rules: E12-8-12-nullable-lift-type; E12-8-12-nullable-target-type; E12-8-12-nullable-lift-null; E12-8-12-nullable-lift-present; E12-8-12-receiver-once; E12-8-12-syntax
Authority: ECMA-334 7th ed 12.8.12
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Fetch(true) ? [Index()]
Into: Fetch(false) ? [Index()]
*/
using System;
struct Cell { public int this[int index] { get { Program.trace += "G"; return index + 41; } } }
class Program
{
    public static string trace = "";
    static int checks, failures;
    static Cell? Fetch(bool present) { trace += "R"; return present ? new Cell() : (Cell?)null; }
    static int Index() { trace += "I"; return 2; }
    static int Kind(int value) { return 1; }
    static int Kind(int? value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var present = Fetch(true) ? [Index()];
        Check(Kind(present) == 2 && present == 43, "nullable-indexer-value-result-lifted");
        Check(trace == "RIG", "nullable-indexer-receiver-once-before-index-and-getter");
        trace = "";
        var absent = Fetch(false)?[Index()];
        Check(Kind(absent) == 2 && !absent.HasValue, "absent-nullable-indexer-result");
        Check(trace == "R", "absent-nullable-indexer-skips-index-and-getter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
