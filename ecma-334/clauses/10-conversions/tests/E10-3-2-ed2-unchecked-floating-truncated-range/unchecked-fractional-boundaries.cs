/*
Rules: E10-3-2-ed2-unchecked-floating-truncated-range
Authority: ECMA-334 2nd ed 13.2.1
Version: ISO-1
Expected: run
Stdout: OK 4
Mutate: unchecked((byte)operand)
Into: unchecked((byte)(operand / 2.0))
*/
using System;
class UncheckedFloatingRange
{
    static bool Wide(double operand, byte expected)
    {
        try { return unchecked((byte)operand) == expected; }
        catch (System.ArithmeticException) { return false; }
    }
    static bool Narrow(float value, byte expected)
    {
        try { return unchecked((byte)value) == expected; }
        catch (System.ArithmeticException) { return false; }
    }
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
    static int Main()
    {
        Check(Wide(-0.625, 0), "double-truncated-lower");
        Check(Wide(255.625, 255), "double-truncated-upper");
        Check(Narrow(-0.375F, 0), "float-truncated-lower");
        Check(Narrow(255.375F, 255), "float-truncated-upper");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
