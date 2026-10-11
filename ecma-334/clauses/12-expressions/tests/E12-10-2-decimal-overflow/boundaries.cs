/*
Rules: E12-10-2-decimal-overflow; E12-10-2-decimal-rounding-zero
Authority: ECMA-334 7th ed 12.10.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: decimal r = large * two;
Into: decimal r = large / two;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        decimal large = decimal.MaxValue, two = 2M, tiny = 0.0000000000000000000000000001M, tenth = 0.1M;
        bool overflow = false;
        try { decimal r = large * two; } catch (OverflowException) { overflow = true; } catch (Exception) { }
        Check(overflow, "positive-overflow"); overflow = false;
        try { decimal r = -large * two; } catch (OverflowException) { overflow = true; } catch (Exception) { }
        Check(overflow, "negative-overflow");
        Check(tiny != 0M && tenth != 0M && tiny * tenth == 0M, "rounded-to-zero");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
