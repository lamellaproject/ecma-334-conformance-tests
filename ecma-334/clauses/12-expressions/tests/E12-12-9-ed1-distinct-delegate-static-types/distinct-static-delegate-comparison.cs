/*
Rules: E12-12-9-ed1-distinct-delegate-static-types
Authority: ECMA-334 1st ed 14.9.8
Version: ISO-1
Expected: run
Stdout: OK 0
Version-Witness: tests/E12-12-9-ed1-distinct-delegate-static-types/distinct-static-delegate-comparison.witness.cs.part
Mutate: Observe(first == second);
Into: Observe(first < second);
*/
// ECMA-334 1st ed 14.9.8, p. 168 (PDF p. 182), lines 45-48. Equality and inequality are
// available between distinct concrete delegate types with the same signature through their
// implicit conversions to System.Delegate.
using System;
delegate void Left();
delegate void Right();
class Entry
{
    static void Read() { }
    static void Observe(bool value) { }
    static int Main()
    {
        Left first = new Left(Read);
        Right second = new Right(Read);
        // Only compilation is asserted; neither comparison value is an oracle.
        Observe(first == second);
        Observe(first != second);
        Console.WriteLine("OK 0");
        return 0;
    }
}
