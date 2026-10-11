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
            sbyte input = (sbyte)(-128);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-128), "nullable-sbyte-sbyte-explicit-unchecked-wrap-0");
        }
        {
            sbyte input = (sbyte)(127);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(127), "nullable-sbyte-sbyte-explicit-unchecked-wrap-1");
        }
        {
            sbyte input = (sbyte)(0);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-sbyte-sbyte-explicit-unchecked-wrap-2");
        }
        {
            sbyte input = (sbyte)(1);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(1), "nullable-sbyte-sbyte-explicit-unchecked-wrap-3");
        }
        {
            sbyte input = (sbyte)(-1);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-1), "nullable-sbyte-sbyte-explicit-unchecked-wrap-4");
        }
        {
            sbyte input = (sbyte)(-127);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-127), "nullable-sbyte-sbyte-explicit-unchecked-wrap-5");
        }
        {
            sbyte input = (sbyte)(126);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(126), "nullable-sbyte-sbyte-explicit-unchecked-wrap-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
