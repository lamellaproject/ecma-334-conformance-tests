/*
Rules: E10-3-2-ed3-floating-decimal-finite-overflow
Authority: ECMA-334 3rd ed 13.2.1
Version: ISO-2
Expected: run
Stdout: OK 4
Mutate: converted = checked((decimal)source);
Into: converted = 0m;
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
    static bool DoubleThrows(double source, bool check)
    {
        try
        {
            decimal converted;
            if (check) converted = checked((decimal)source);
            else converted = unchecked((decimal)source);
            return false;
        }
        catch (OverflowException) { return true; }
    }
    static bool FloatThrows(float input, bool check)
    {
        try
        {
            decimal converted;
            if (check) converted = checked((decimal)input);
            else converted = unchecked((decimal)input);
            return false;
        }
        catch (OverflowException) { return true; }
    }
    static int Main()
    {
        bool doubleCase = false, floatCase = false;
        // A decimal range wider than the floating range supplies no such input.
        try { doubleCase = (double)decimal.MaxValue < double.MaxValue; }
        catch (OverflowException) { }
        try { floatCase = (float)decimal.MaxValue < float.MaxValue; }
        catch (OverflowException) { }
        Check(!doubleCase || (DoubleThrows(double.MaxValue, true) && DoubleThrows(double.MaxValue, false)), "finite-positive-double");
        Check(!doubleCase || (DoubleThrows(-double.MaxValue, true) && DoubleThrows(-double.MaxValue, false)), "finite-negative-double");
        Check(!floatCase || (FloatThrows(float.MaxValue, true) && FloatThrows(float.MaxValue, false)), "finite-positive-float");
        Check(!floatCase || (FloatThrows(-float.MaxValue, true) && FloatThrows(-float.MaxValue, false)), "finite-negative-float");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
