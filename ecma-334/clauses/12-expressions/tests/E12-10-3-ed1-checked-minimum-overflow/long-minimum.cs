/*
Rules: E12-10-3-ed1-checked-minimum-overflow
Authority: ECMA-334 1st ed 14.7.2
Version: ISO-1
Expected: run
Stdout: OK 1
Mutate: checked(dividend / divisor)
Into: checked(dividend / 1L)
*/
using System;

// 14.7.2, printed p. 158 (PDF p. 172), lines 23-24 requires
// OverflowException for checked minimum-long division by minus one.
class Program
{
    static int checks;
    static int failures;

    static long Divide(long dividend, long divisor)
    {
        return checked(dividend / divisor);
    }

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
        bool overflow = false;
        try
        {
            Divide(long.MinValue, -1L);
        }
        catch (OverflowException)
        {
            overflow = true;
        }
        catch (Exception)
        {
            overflow = false;
        }
        Check(overflow, "checked-minimum-long-overflow-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
