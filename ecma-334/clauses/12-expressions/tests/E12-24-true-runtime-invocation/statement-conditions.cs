/*
Rules: E12-24-true-runtime-invocation; E12-24-if-condition; E12-24-while-condition; E12-24-do-condition; E12-24-for-condition; E12-24-bool-result
Authority: ECMA-334 7th ed 12.24
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: while (NextWhile())
Into: while (new Flag(false))
*/
using System;
struct Flag
{
    bool value;
    public Flag(bool value) { this.value = value; }
    public static bool operator true(Flag flag) { Program.trace += "T"; return flag.value; }
    public static bool operator false(Flag flag) { Program.trace += "F"; return !flag.value; }
}
class Program
{
    public static string trace = "";
    static int whileCalls, forCalls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Flag NextWhile() { return new Flag(whileCalls++ == 0); }
    static Flag NextFor() { return new Flag(forCalls++ == 0); }
    static void Main()
    {
        int count = 0;
        if (new Flag(true)) count++;
        Check(count == 1 && trace == "T", "if-applies-true-operator");
        trace = ""; count = 0;
        while (NextWhile()) { count++; trace += "B"; }
        Check(count == 1 && whileCalls == 2 && trace == "TBT", "while-rechecks-true-operator");
        trace = ""; count = 0;
        do { count++; trace += "B"; } while (new Flag(false));
        Check(count == 1 && trace == "BT", "do-applies-condition-after-body");
        trace = ""; count = 0;
        for (; NextFor(); ) { count++; trace += "B"; }
        Check(count == 1 && forCalls == 2 && trace == "TBT", "for-applies-true-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
