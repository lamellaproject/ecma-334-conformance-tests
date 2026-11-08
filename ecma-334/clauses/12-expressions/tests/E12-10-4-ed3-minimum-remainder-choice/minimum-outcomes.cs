/*
Rules: E12-10-4-ed3-minimum-remainder-choice
Authority: ECMA-334 3rd ed 14.7.3
Version: ISO-2
Expected: run
Stdout: OK 8
Mutate: unchecked(a % b)
Into: unchecked(a + b)
*/
// ECMA-334 3rd ed 14.7.3, p. 198 (PDF p. 218).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static void IntCase(bool mode)
    {
        int a = int.MinValue, b = -1, quotient = 0;
        bool divisionThrows = false;
        try { quotient = mode ? checked(a / b) : unchecked(a / b); }
        catch (ArithmeticException) { divisionThrows = true; }
        Check(divisionThrows || (!mode && quotient == a), "int-division-control");
        try
        {
            int remainder = mode ? checked(a % b) : unchecked(a % b);
            Check(remainder == 0, "int-remainder-result");
        }
        catch (ArithmeticException) { Check(divisionThrows, "int-remainder-exception"); }
    }
    static void LongCase(bool mode)
    {
        long left = long.MinValue, right = -1L, quotient = 0L;
        bool divisionThrows = false;
        try { quotient = mode ? checked(left / right) : unchecked(left / right); }
        catch (ArithmeticException) { divisionThrows = true; }
        Check(divisionThrows || (!mode && quotient == left), "long-division-control");
        try
        {
            long remainder = mode ? checked(left % right) : unchecked(left % right);
            Check(remainder == 0L, "long-remainder-result");
        }
        catch (ArithmeticException) { Check(divisionThrows, "long-remainder-exception"); }
    }
    static int Main()
    {
        IntCase(false);
        IntCase(true);
        LongCase(false);
        LongCase(true);
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
