/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 10
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        {
            decimal input = 0m;
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==0UL, "nullable-decimal-ulong-explicit-checked-wrap-2");
        }
        {
            decimal input = 1m;
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==1UL, "nullable-decimal-ulong-explicit-checked-wrap-3");
        }
        {
            decimal input = 0.1m;
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==0UL, "nullable-decimal-ulong-explicit-checked-wrap-5");
        }
        {
            decimal input = -0.1m;
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==0UL, "nullable-decimal-ulong-explicit-checked-wrap-6");
        }
        {
            decimal input = 1E-28m;
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==0UL, "nullable-decimal-ulong-explicit-checked-wrap-7");
        }
        {
            decimal input = -1E-28m;
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==0UL, "nullable-decimal-ulong-explicit-checked-wrap-8");
        }
        {
            decimal input = 18446744073709551614m;
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==18446744073709551614UL, "nullable-decimal-ulong-explicit-checked-wrap-9");
        }
        {
            decimal input = 18446744073709551615m;
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==18446744073709551615UL, "nullable-decimal-ulong-explicit-checked-wrap-10");
        }
        {
            decimal input = -0.75m;
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==0UL, "nullable-decimal-ulong-explicit-checked-wrap-12");
        }
        {
            decimal input = 18446744073709551615.75m;
            ulong? result = checked((ulong?)input);
            Check(result.HasValue && result.Value==18446744073709551615UL, "nullable-decimal-ulong-explicit-checked-wrap-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
