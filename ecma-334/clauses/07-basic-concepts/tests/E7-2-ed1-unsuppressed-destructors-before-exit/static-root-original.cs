/*
Rules: E7-2-ed1-unsuppressed-destructors-before-exit
Authority: ECMA-334 1st ed 10.2
Version: ISO-1
Expected: run
Stdout: OK 1
Diagnostic: none
Version-Witness: tests/E7-2-ed1-unsuppressed-destructors-before-exit/static-root-original.witness.cs.part
Mutate: static bool suppress = false;
Into: static bool suppress = true;
*/
using System;
// ECMA-334 1st ed 10.2, p. 70 (PDF p. 84), lines 6-8. Before an application's termination,
// invoke the destructors of its objects not yet garbage collected unless their cleanup has
// been suppressed.
class ExitToken
{
    public int Value;

    public ExitToken(int value)
    {
        Value = value;
    }

    ~ExitToken()
    {
        ExitAudit.Check(Value == 41, "shutdown-root-state");
        ExitAudit.Report();
    }
}

class ExitAudit
{
    static ExitToken root;
    static bool suppress = false;
    static int checks, failures;

    public static void Check(bool ok, string id)
    {
        checks++;
        if (!ok)
        {
            failures++;
            System.Console.WriteLine("FAIL " + id);
        }
    }

    public static void Report()
    {
        if (failures == 0)
            Console.WriteLine("OK " + checks);
    }

    static int Main()
    {
        root = new ExitToken(41);
        if (root.Value != 41)
            return 1;
        if (suppress)
            System.GC.SuppressFinalize(root);
        return 0;
    }
}
