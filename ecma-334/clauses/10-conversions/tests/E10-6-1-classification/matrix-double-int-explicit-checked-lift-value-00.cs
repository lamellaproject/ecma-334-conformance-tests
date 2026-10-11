/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 12
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
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==0, "nullable-double-int-explicit-checked-lift-2");
        }
        {
            double? input = -0.0d;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==0, "nullable-double-int-explicit-checked-lift-3");
        }
        {
            double? input = 1.0d;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==1, "nullable-double-int-explicit-checked-lift-4");
        }
        {
            double? input = -1.0d;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==-1, "nullable-double-int-explicit-checked-lift-5");
        }
        {
            double? input = 0.75d;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==0, "nullable-double-int-explicit-checked-lift-6");
        }
        {
            double? input = -0.75d;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==0, "nullable-double-int-explicit-checked-lift-7");
        }
        {
            double? input = -2147483648.0d;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==-2147483648, "nullable-double-int-explicit-checked-lift-12");
        }
        {
            double? input = -2147483647.0d;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==-2147483647, "nullable-double-int-explicit-checked-lift-13");
        }
        {
            double? input = 2147483646.0d;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==2147483646, "nullable-double-int-explicit-checked-lift-14");
        }
        {
            double? input = 2147483647.0d;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==2147483647, "nullable-double-int-explicit-checked-lift-15");
        }
        {
            double? input = -2147483648.75d;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==-2147483648, "nullable-double-int-explicit-checked-lift-17");
        }
        {
            double? input = 2147483647.75d;
            int? result = checked((int?)input);
            Check(result.HasValue && result.Value==2147483647, "nullable-double-int-explicit-checked-lift-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
