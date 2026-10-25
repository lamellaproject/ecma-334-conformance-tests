/*
Rules: E12-10-4-ed1-integer-remainder-no-overflow
Authority: ECMA-334 1st ed 14.7.3
Version: ISO-1
Expected: run
Stdout: OK 8
Version-Witness: tests/E12-10-4-ed1-integer-remainder-no-overflow/minimum-remainder-contexts.witness.cs.part
Mutate: int result = useChecked ? checked(left % right) : unchecked(left % right);
Into: int result = useChecked ? checked(left + right) : unchecked(left + right);
*/
// ECMA-334 1st ed 14.7.3, p. 159 (PDF p. 173), lines 21-22. The int and long remainder of
// the minimum value by minus one is zero without overflow in both checked and unchecked
// contexts.
using System;
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
    static bool MatchesInt(int left, int right, int expected, bool useChecked)
    {
        try
        {
            int result = useChecked ? checked(left % right) : unchecked(left % right);
            return result == expected;
        }
        catch (ArithmeticException) { return false; }
    }
    static bool MatchesLong(long left, long right, long expected, bool useChecked)
    {
        try
        {
            long result = useChecked ? checked(left % right) : unchecked(left % right);
            return result == expected;
        }
        catch (ArithmeticException) { return false; }
    }
    static int Main()
    {
        Check(MatchesInt(Int32.MinValue, -1, 0, true), "int-checked");
        Check(MatchesInt(Int32.MinValue, -1, 0, false), "int-unchecked");
        Check(MatchesLong(Int64.MinValue, -1, 0, true), "long-checked");
        Check(MatchesLong(Int64.MinValue, -1, 0, false), "long-unchecked");
        Check(MatchesInt(17, 5, 2, true), "int-checked-control");
        Check(MatchesInt(17, 5, 2, false), "int-unchecked-control");
        Check(MatchesLong(17, 5, 2, true), "long-checked-control");
        Check(MatchesLong(17, 5, 2, false), "long-unchecked-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
