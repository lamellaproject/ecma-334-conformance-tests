/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 7
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
            long input = 0L;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-long-sbyte-explicit-checked-wrap-2");
        }
        {
            long input = 1L;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(1), "nullable-long-sbyte-explicit-checked-wrap-3");
        }
        {
            long input = -1L;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-1), "nullable-long-sbyte-explicit-checked-wrap-4");
        }
        {
            long input = -128L;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-128), "nullable-long-sbyte-explicit-checked-wrap-6");
        }
        {
            long input = -127L;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-127), "nullable-long-sbyte-explicit-checked-wrap-7");
        }
        {
            long input = 126L;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(126), "nullable-long-sbyte-explicit-checked-wrap-8");
        }
        {
            long input = 127L;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(127), "nullable-long-sbyte-explicit-checked-wrap-9");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
