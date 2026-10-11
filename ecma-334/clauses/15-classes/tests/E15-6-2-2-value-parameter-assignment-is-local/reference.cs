/*
Rules: E15-6-2-2-value-parameter-assignment-is-local; E15-6-2-2-value-parameter-initial-value
Authority: ECMA-334 7th ed 15.6.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: value = new Box();
Into: value = prior;
*/
using System;
class Box { public int Number; }
class Program
{
    static Box Replace(Box value) { Box prior = value; value = new Box(); value.Number = 29; return prior; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box original = new Box();
        original.Number = 13;
        Box prior = Replace(original);
        Check(prior == original, "reference-value-parameter-reassignment-preserves-caller-binding");
        Check(original.Number == 13, "new-local-parameter-reference-refers-to-other-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
