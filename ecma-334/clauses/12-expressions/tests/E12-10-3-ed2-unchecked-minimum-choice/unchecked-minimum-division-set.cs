/*
Rules: E12-10-3-ed2-unchecked-minimum-choice
Authority: ECMA-334 2nd ed 14.7.2
Version: ISO-1
Expected: run
Stdout: OK 2
Mutate: unchecked(dividend / divisor)
Into: unchecked(dividend / 2)
*/
using System;
class UncheckedMinimumDivision
{
    static bool IntCase(int dividend, int divisor)
    {
        try { return unchecked(dividend / divisor) == dividend; }
        catch (System.ArithmeticException) { return true; }
        catch (System.Exception) { return false; }
    }
    static bool LongCase(long longLeft, long longRight)
    {
        try { return unchecked(longLeft / longRight) == longLeft; }
        catch (System.ArithmeticException) { return true; }
        catch (System.Exception) { return false; }
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
        Check(IntCase(int.MinValue, -1), "unchecked-int-minimum");
        Check(LongCase(long.MinValue, -1), "unchecked-long-minimum");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
