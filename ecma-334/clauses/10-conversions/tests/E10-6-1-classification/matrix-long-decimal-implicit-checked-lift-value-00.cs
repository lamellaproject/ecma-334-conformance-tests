/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 5
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
            long? input = long.MinValue;
            decimal? result = checked(input);
            Check(result.HasValue && result.Value==-9223372036854775808m, "nullable-long-decimal-implicit-checked-lift-0");
        }
        {
            long? input = 9223372036854775807L;
            decimal? result = checked(input);
            Check(result.HasValue && result.Value==9223372036854775807m, "nullable-long-decimal-implicit-checked-lift-1");
        }
        {
            long? input = 0L;
            decimal? result = checked(input);
            Check(result.HasValue && result.Value==0m, "nullable-long-decimal-implicit-checked-lift-2");
        }
        {
            long? input = 1L;
            decimal? result = checked(input);
            Check(result.HasValue && result.Value==1m, "nullable-long-decimal-implicit-checked-lift-3");
        }
        {
            long? input = -1L;
            decimal? result = checked(input);
            Check(result.HasValue && result.Value==-1m, "nullable-long-decimal-implicit-checked-lift-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
