/*
Rules: E16-4-10-ed1-default-construction-trigger
Authority: ECMA-334 1st ed 18.2
Version: ISO-1
Expected: run
Stdout: OK 2
Version-Witness: tests/E16-4-10-ed1-default-construction-trigger/default-construction-static-trigger.witness.cs.part
Mutate: Value value = new Value();
Into: Value value; value.Number = 0;
*/
// ECMA-334 1st ed 18.2, p. 272 (PDF p. 286), lines 23-24. The class static-constructor
// triggers apply to structs without a default-construction exception.
using System;
class Signals { public static int Count; }
struct Value
{
    public int Number;
    static Value() { Signals.Count++; }
    public static void Touch() { }
}
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool result, string label)
    {
        checks++;
        if (!result)
        {
            failures++;
            Console.WriteLine("FAIL " + label);
        }
    }
    static int Main()
    {
        int before = Signals.Count;
        Value value = new Value();
        Check(Signals.Count == before + 1, "default-construction-trigger");
        Check(value.Number == 0, "default-field-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
