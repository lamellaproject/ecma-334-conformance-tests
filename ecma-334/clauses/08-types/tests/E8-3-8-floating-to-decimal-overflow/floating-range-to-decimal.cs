/*
Rules: E8-3-8-floating-to-decimal-overflow; E8-3-8-decimal-possibly-smaller-range
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: double huge = 1e100d;
Into: double huge = 1d;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double huge = 1e100d; bool correct = false;
        try { decimal value = (decimal)huge; correct = (double)value > 1e99d; }
        catch (OverflowException) { correct = true; }
        catch (Exception) { }
        // A representation with sufficient range may retain the value; a narrower one may overflow.
        Check(correct, "allowed-decimal-range-outcomes");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
