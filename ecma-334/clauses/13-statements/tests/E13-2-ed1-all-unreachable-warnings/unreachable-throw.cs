/*
Rules: E13-2-ed1-all-unreachable-warnings
Authority: ECMA-334 1st ed 15.1
Version: ISO-1
Expected: run
Stdout: OK 0
Diagnostic: warning
Version-Witness: tests/E13-2-ed1-all-unreachable-warnings/unreachable-throw.witness.cs.part
Mutate: throw new InvalidOperationException();
Into: // omitted
*/
// ECMA-334 1st ed 15.1, p. 180 (PDF p. 194), lines 3-4. Every statement found unreachable
// requires a warning, including a throw statement, empty block or empty statement.
using System;
class Entry
{
    static void Inspect()
    {
        return;
        throw new InvalidOperationException();
    }
    static int Main()
    {
        Inspect();
        Console.WriteLine("OK 0");
        return 0;
    }
}
