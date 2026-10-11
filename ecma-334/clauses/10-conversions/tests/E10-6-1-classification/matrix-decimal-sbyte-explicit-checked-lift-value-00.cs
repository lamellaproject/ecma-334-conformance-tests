/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 13
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
            decimal? input = 0m;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-decimal-sbyte-explicit-checked-lift-2");
        }
        {
            decimal? input = 1m;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(1), "nullable-decimal-sbyte-explicit-checked-lift-3");
        }
        {
            decimal? input = -1m;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-1), "nullable-decimal-sbyte-explicit-checked-lift-4");
        }
        {
            decimal? input = 0.1m;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-decimal-sbyte-explicit-checked-lift-5");
        }
        {
            decimal? input = -0.1m;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-decimal-sbyte-explicit-checked-lift-6");
        }
        {
            decimal? input = 1E-28m;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-decimal-sbyte-explicit-checked-lift-7");
        }
        {
            decimal? input = -1E-28m;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-decimal-sbyte-explicit-checked-lift-8");
        }
        {
            decimal? input = -128m;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-128), "nullable-decimal-sbyte-explicit-checked-lift-10");
        }
        {
            decimal? input = -127m;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-127), "nullable-decimal-sbyte-explicit-checked-lift-11");
        }
        {
            decimal? input = 126m;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(126), "nullable-decimal-sbyte-explicit-checked-lift-12");
        }
        {
            decimal? input = 127m;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(127), "nullable-decimal-sbyte-explicit-checked-lift-13");
        }
        {
            decimal? input = -128.75m;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-128), "nullable-decimal-sbyte-explicit-checked-lift-15");
        }
        {
            decimal? input = 127.75m;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(127), "nullable-decimal-sbyte-explicit-checked-lift-16");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
