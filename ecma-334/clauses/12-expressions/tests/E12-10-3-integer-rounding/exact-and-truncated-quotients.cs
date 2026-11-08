/*
Rules: E12-10-3-integer-rounding
Authority: ECMA-334 7th ed 12.10.3
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: return left / right;
Into: return left / (right + 1);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Divide(int left, int right) { return left / right; }
    static int Main()
    {
        Check(Divide(24, 6) == 4, "positive-exact");
        Check(Divide(-24, 6) == -4, "negative-exact");
        Check(Divide(25, 6) == 4, "positive-truncated");
        Check(Divide(-25, 6) == -4, "negative-truncated");
        Check(Divide(0, 5) == 0, "zero-exact");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
