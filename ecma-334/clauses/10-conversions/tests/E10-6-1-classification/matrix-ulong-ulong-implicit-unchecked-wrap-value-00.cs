/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 4
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
            ulong input = 0UL;
            ulong? result = unchecked(input);
            Check(result.HasValue && result.Value==0UL, "nullable-ulong-ulong-implicit-unchecked-wrap-0");
        }
        {
            ulong input = 18446744073709551615UL;
            ulong? result = unchecked(input);
            Check(result.HasValue && result.Value==18446744073709551615UL, "nullable-ulong-ulong-implicit-unchecked-wrap-1");
        }
        {
            ulong input = 1UL;
            ulong? result = unchecked(input);
            Check(result.HasValue && result.Value==1UL, "nullable-ulong-ulong-implicit-unchecked-wrap-2");
        }
        {
            ulong input = 18446744073709551614UL;
            ulong? result = unchecked(input);
            Check(result.HasValue && result.Value==18446744073709551614UL, "nullable-ulong-ulong-implicit-unchecked-wrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
