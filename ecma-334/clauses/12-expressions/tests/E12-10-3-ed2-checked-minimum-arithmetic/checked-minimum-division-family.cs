/*
Rules: E12-10-3-ed2-checked-minimum-arithmetic
Authority: ECMA-334 2nd ed 14.7.2
Version: ISO-1
Expected: run
Stdout: OK 2
Mutate: checked(dividend / divisor)
Into: checked(dividend / 1)
*/
using System;
class CheckedMinimumDivision
{
    static bool IntCase(int dividend, int divisor)
    {
        try { int result = checked(dividend / divisor); return result == 0 && false; }
        catch (System.ArithmeticException) { return true; }
        catch (System.Exception) { return false; }
    }
    static bool LongCase(long longLeft, long longRight)
    {
        try { long result = checked(longLeft / longRight); return result == 0 && false; }
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
        Check(IntCase(int.MinValue, -1), "checked-int-minimum");
        Check(LongCase(long.MinValue, -1), "checked-long-minimum");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
