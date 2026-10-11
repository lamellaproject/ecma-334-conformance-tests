/*
Rules: E12-10-4-decimal-zero-divisor; E12-10-4-decimal-arithmetic-exceptions
Authority: ECMA-334 7th ed 12.10.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: x % zero
Into: x % one
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        decimal x = decimal.MaxValue, zero = 0M, one = 1M, tenth = 0.1M; bool caught = false;
        try { decimal r = x % zero; } catch (DivideByZeroException) { caught = true; } catch (Exception) { }
        Check(caught, "zero-divisor-type"); bool allowed = false;
        // The corresponding quotient overflows: either this exact remainder or an arithmetic exception is allowed.
        try { decimal r = x % tenth; allowed = r == 0M; } catch (ArithmeticException) { allowed = true; } catch (Exception) { }
        Check(allowed, "implementation-defined-arithmetic-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
