/*
Rules: E12-10-3-decimal-zero-divisor; E12-10-3-decimal-overflow; E12-10-3-decimal-rounding-zero
Authority: ECMA-334 7th ed 12.10.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: one / zero
Into: one / one
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        decimal one = 1M, zero = 0M, large = decimal.MaxValue, tenth = 0.1M;
        bool caught = false;
        try { decimal r = one / zero; } catch (DivideByZeroException) { caught = true; } catch (Exception) { }
        Check(caught, "zero-divisor-type"); caught = false;
        try { decimal r = large / tenth; } catch (OverflowException) { caught = true; } catch (Exception) { }
        Check(caught, "quotient-overflow-type");
        decimal tiny = 0.0000000000000000000000000001M, ten = 10M;
        Check(tiny != 0M && tiny / ten == 0M, "rounded-nonzero-dividend");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
