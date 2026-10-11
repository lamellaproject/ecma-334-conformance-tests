/*
Rules: E12-8-10-function-body-context; E12-8-10-method-body-context; E12-8-10-no-value-classification; E12-8-10-void-body-null; E12-8-10-void-body-present; E12-8-10-void-body-receiver-once
Authority: ECMA-334 7th ed 12.8.10
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: void Call(bool present) => Fetch(present)?.Touch();
Into: void Call(bool present) => Fetch(false)?.Touch();
*/
using System;
class Cell { public void Touch() { Program.trace += "M"; } }
class Program
{
    public static string trace = "";
    static int checks, failures;
    static Cell Fetch(bool present) { trace += "R"; return present ? new Cell() : null; }
    static void Call(bool present) => Fetch(present)?.Touch();
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Call(true);
        Check(trace == "RM", "void-method-body-present-receiver-once");
        trace = ""; Call(false);
        Check(trace == "R", "void-method-body-null");
        Action<bool> lambda = present => Fetch(present)?.Touch();
        trace = ""; lambda(true);
        Check(trace == "RM", "void-lambda-body-present-receiver-once");
        trace = ""; lambda(false);
        Check(trace == "R", "void-lambda-body-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
