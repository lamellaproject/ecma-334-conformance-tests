/*
Rules: E15-2-4-2-ed1-immediate-class-dependency
Authority: ECMA-334 1st ed 17.1.2.1
Version: ISO-1
Expected: run
Stdout: OK 1
Version-Witness: tests/E15-2-4-2-ed1-immediate-class-dependency/struct-dependency-barrier.witness.cs.part
Mutate: public struct Band
Into: public class Band
*/
// ECMA-334 1st ed 17.1.2.1, p. 213 (PDF p. 227), lines 19-22. The class-dependency
// relation adds an enclosing edge only for an immediately enclosing class.
using System;
class Spindle : Spindle.Band.Pin
{
    public struct Band
    {
        public class Pin { }
    }
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
        Spindle value = new Spindle();
        Check(value != null, "struct-barrier-inheritance");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
