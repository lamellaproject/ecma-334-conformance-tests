/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 6
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
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==0, "nullable-ulong-int-explicit-unchecked-wrap-0");
        }
        {
            ulong input = 18446744073709551615UL;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==-1, "nullable-ulong-int-explicit-unchecked-wrap-1");
        }
        {
            ulong input = 1UL;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==1, "nullable-ulong-int-explicit-unchecked-wrap-2");
        }
        {
            ulong input = 2147483646UL;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==2147483646, "nullable-ulong-int-explicit-unchecked-wrap-3");
        }
        {
            ulong input = 2147483647UL;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==2147483647, "nullable-ulong-int-explicit-unchecked-wrap-4");
        }
        {
            ulong input = 2147483648UL;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==-2147483648, "nullable-ulong-int-explicit-unchecked-wrap-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
