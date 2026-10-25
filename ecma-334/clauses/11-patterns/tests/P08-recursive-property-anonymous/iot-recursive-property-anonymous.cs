/*
Rules: P08-recursive-property-anonymous
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Mutate: Code: 67
Into: Code: 68
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        var envelope = new { Code = 67, Detail = new { Text = "reed" } };
        Check(envelope is { Code: 67, Detail: { Text: "reed" } }, "anonymous-nested-members");
        Check(!(envelope is { Detail: { Text: "stone" } }), "anonymous-mismatch");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
