/*
Rules: P09-top-level-ignored-main
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Diagnostic: warning
Mutate: static void Main()
Into: static void Spare()
*/
using System;
using static Audit;

// top-level-statements.md L89/90; alpha-v13 basic concepts 7.1.5.
Audit.State = 17;
Audit.Check(Audit.State == 17, "top-level-body-runs");
Audit.Check(Audit.MainCalls == 0, "conventional-main-is-ignored");
if (failures == 0) Console.WriteLine("OK " + checks);
return failures == 0 ? 0 : 1;

class OtherEntry
{
    static void Main() { Audit.MainCalls++; }
}
static class Audit
{
    public static int checks, failures, State, MainCalls;
    public static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
}
