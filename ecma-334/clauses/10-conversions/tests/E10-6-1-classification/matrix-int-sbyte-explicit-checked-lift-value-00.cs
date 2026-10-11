/*
Rules: E10-6-1-classification; E10-6-1-nonnull
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
            int? input = 0;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-int-sbyte-explicit-checked-lift-2");
        }
        {
            int? input = 1;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(1), "nullable-int-sbyte-explicit-checked-lift-3");
        }
        {
            int? input = -1;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-1), "nullable-int-sbyte-explicit-checked-lift-4");
        }
        {
            int? input = -128;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-128), "nullable-int-sbyte-explicit-checked-lift-6");
        }
        {
            int? input = -127;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-127), "nullable-int-sbyte-explicit-checked-lift-7");
        }
        {
            int? input = 126;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(126), "nullable-int-sbyte-explicit-checked-lift-8");
        }
        {
            int? input = 127;
            sbyte? result = checked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(127), "nullable-int-sbyte-explicit-checked-lift-9");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
