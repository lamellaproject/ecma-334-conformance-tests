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
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-double-sbyte-explicit-unchecked-lift-2");
        }
        {
            double? input = -0.0d;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-double-sbyte-explicit-unchecked-lift-3");
        }
        {
            double? input = 1.0d;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(1), "nullable-double-sbyte-explicit-unchecked-lift-4");
        }
        {
            double? input = -1.0d;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-1), "nullable-double-sbyte-explicit-unchecked-lift-5");
        }
        {
            double? input = 0.75d;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-double-sbyte-explicit-unchecked-lift-6");
        }
        {
            double? input = -0.75d;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-double-sbyte-explicit-unchecked-lift-7");
        }
        {
            double? input = -128.0d;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-128), "nullable-double-sbyte-explicit-unchecked-lift-12");
        }
        {
            double? input = -127.0d;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-127), "nullable-double-sbyte-explicit-unchecked-lift-13");
        }
        {
            double? input = 126.0d;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(126), "nullable-double-sbyte-explicit-unchecked-lift-14");
        }
        {
            double? input = 127.0d;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(127), "nullable-double-sbyte-explicit-unchecked-lift-15");
        }
        {
            double? input = -128.75d;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-128), "nullable-double-sbyte-explicit-unchecked-lift-17");
        }
        {
            double? input = 127.75d;
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(127), "nullable-double-sbyte-explicit-unchecked-lift-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
