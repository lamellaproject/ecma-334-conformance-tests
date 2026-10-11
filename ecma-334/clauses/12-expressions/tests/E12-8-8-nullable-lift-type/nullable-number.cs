/*
Rules: E12-8-8-nullable-lift-type; E12-8-8-nullable-target-type; E12-8-8-nullable-lift-null; E12-8-8-nullable-lift-present; E12-8-8-receiver-once
Authority: ECMA-334 7th ed 12.8.8
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Fetch(true)?.Number
Into: Fetch(false)?.Number
*/
using System;
struct Cell { public int Number { get { Program.reads++; return 37; } } }
class Program
{
    public static int reads;
    static int calls;
    static int checks, failures;
    static Cell? Fetch(bool present) { calls++; return present ? new Cell() : (Cell?)null; }
    static int Kind(int value) { return 1; }
    static int Kind(int? value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var present = Fetch(true)?.Number;
        Check(Kind(present) == 2 && present == 37, "nullable-receiver-lifts-value-result");
        Check(calls == 1 && reads == 1, "present-receiver-once");
        var absent = Fetch(false)?.Number;
        Check(Kind(absent) == 2 && !absent.HasValue, "nullable-receiver-null-result");
        Check(calls == 2 && reads == 1, "null-receiver-once-skips-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
