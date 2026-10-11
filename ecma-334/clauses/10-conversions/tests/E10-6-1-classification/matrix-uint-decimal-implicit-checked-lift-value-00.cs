/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 3
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
            uint? input = 0U;
            decimal? result = checked(input);
            Check(result.HasValue && result.Value==0m, "nullable-uint-decimal-implicit-checked-lift-0");
        }
        {
            uint? input = 4294967295U;
            decimal? result = checked(input);
            Check(result.HasValue && result.Value==4294967295m, "nullable-uint-decimal-implicit-checked-lift-1");
        }
        {
            uint? input = 1U;
            decimal? result = checked(input);
            Check(result.HasValue && result.Value==1m, "nullable-uint-decimal-implicit-checked-lift-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
