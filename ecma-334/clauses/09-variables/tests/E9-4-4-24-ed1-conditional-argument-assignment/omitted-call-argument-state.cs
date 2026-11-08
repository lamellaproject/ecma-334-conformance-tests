/*
Rules: E9-4-4-24-ed1-conditional-argument-assignment
Authority: ECMA-334 1st ed 12.3.3.21
Version: ISO-1
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E9-4-4-24-ed1-conditional-argument-assignment/omitted-call-argument-state.cs.part
Mutate: Omitted(local = 73);
Into: Omitted(73);
*/
#define DOLOG
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    [System.Diagnostics.Conditional("ARGSET")]
    static void Omitted(int value) { }
    [System.Diagnostics.Conditional("DOLOG")]
    static void Included(int value) { }
    // This body checks assignment at compilation; it is not invoked.
    static int AssignmentState()
    {
        int local;
        Omitted(local = 73);
        return local;
    }
    static int Main()
    {
        int control;
        Included(control = 73);
        Check(control == 73, "defined-symbol-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
