/*
Rules: E10-3-2-ed1-floating-decimal-special-overflow; E8-3-8-ed1-no-nonfinite-decimal-values
Authority: ECMA-334 1st ed 13.2.1
Version: ISO-1
Expected: run
Stdout: OK 6
Diagnostic: none
Mutate: Consume((decimal)input);
Into: Consume(0m);
*/
// ECMA-334 1st ed 13.2.1, p. 117 (PDF p. 131), lines 12-13 requires exceptions, consistent
// with11.1.6's finite decimal set. The 7th edition's 10.3.2 admits supported special
// values.
using System;
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition)
        {
            failures++;
            Console.WriteLine("FAIL " + name);
        }
    }
    static void Consume(decimal value) { }
    static bool Overflows(double input)
    {
        try { Consume((decimal)input); return false; }
        catch (OverflowException) { return true; }
    }
    static bool Overflows(float value)
    {
        try { Consume((decimal)value); return false; }
        catch (OverflowException) { return true; }
    }
    public static int Main()
    {
        Check(Overflows(double.NaN), "double-nan");
        Check(Overflows(double.PositiveInfinity), "double-positive-infinity");
        Check(Overflows(double.NegativeInfinity), "double-negative-infinity");
        Check(Overflows(1.0e40), "double-finite-overflow");
        Check(Overflows(float.NaN), "float-nan");
        Check(Overflows(float.NegativeInfinity), "float-infinity");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
