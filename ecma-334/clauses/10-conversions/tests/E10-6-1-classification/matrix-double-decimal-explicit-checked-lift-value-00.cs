/*
Rules: E10-6-1-classification; E10-6-1-nonnull
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
            double? input = 0.0d;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==0m, "nullable-double-decimal-explicit-checked-lift-2");
        }
        {
            double? input = -0.0d;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==-0m, "nullable-double-decimal-explicit-checked-lift-3");
        }
        {
            double? input = 1.0d;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==1m, "nullable-double-decimal-explicit-checked-lift-4");
        }
        {
            double? input = -1.0d;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==-1m, "nullable-double-decimal-explicit-checked-lift-5");
        }
        {
            double? input = 0.75d;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==0.75m, "nullable-double-decimal-explicit-checked-lift-6");
        }
        {
            double? input = -0.75d;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==-0.75m, "nullable-double-decimal-explicit-checked-lift-7");
        }
        {
            double? input = 1.0000000000000001e-30d;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==0m, "nullable-double-decimal-explicit-checked-lift-11");
        }
        {
            double? input = -1.0000000000000001e-30d;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==-0m, "nullable-double-decimal-explicit-checked-lift-12");
        }
        {
            double? input = 0.10000000000000001d;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==0.1000000000000000055511151231m, "nullable-double-decimal-explicit-checked-lift-13");
        }
        {
            double? input = -0.10000000000000001d;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==-0.1000000000000000055511151231m, "nullable-double-decimal-explicit-checked-lift-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
