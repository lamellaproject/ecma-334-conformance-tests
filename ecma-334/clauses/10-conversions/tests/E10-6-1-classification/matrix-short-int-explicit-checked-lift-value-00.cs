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
            short? input = (short)(-32768);
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==-32768, "nullable-short-int-explicit-checked-lift-0");
        }
        {
            short? input = (short)(32767);
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==32767, "nullable-short-int-explicit-checked-lift-1");
        }
        {
            short? input = (short)(0);
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==0, "nullable-short-int-explicit-checked-lift-2");
        }
        {
            short? input = (short)(1);
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==1, "nullable-short-int-explicit-checked-lift-3");
        }
        {
            short? input = (short)(-1);
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==-1, "nullable-short-int-explicit-checked-lift-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
