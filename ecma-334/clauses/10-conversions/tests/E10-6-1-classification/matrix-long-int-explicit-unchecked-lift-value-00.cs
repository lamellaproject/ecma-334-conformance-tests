/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 11
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
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==0, "nullable-long-int-explicit-unchecked-lift-0");
        }
        {
            long? input = 9223372036854775807L;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==-1, "nullable-long-int-explicit-unchecked-lift-1");
        }
        {
            long? input = 0L;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==0, "nullable-long-int-explicit-unchecked-lift-2");
        }
        {
            long? input = 1L;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==1, "nullable-long-int-explicit-unchecked-lift-3");
        }
        {
            long? input = -1L;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==-1, "nullable-long-int-explicit-unchecked-lift-4");
        }
        {
            long? input = -2147483649L;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==2147483647, "nullable-long-int-explicit-unchecked-lift-5");
        }
        {
            long? input = -2147483648L;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==-2147483648, "nullable-long-int-explicit-unchecked-lift-6");
        }
        {
            long? input = -2147483647L;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==-2147483647, "nullable-long-int-explicit-unchecked-lift-7");
        }
        {
            long? input = 2147483646L;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==2147483646, "nullable-long-int-explicit-unchecked-lift-8");
        }
        {
            long? input = 2147483647L;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==2147483647, "nullable-long-int-explicit-unchecked-lift-9");
        }
        {
            long? input = 2147483648L;
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==-2147483648, "nullable-long-int-explicit-unchecked-lift-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
