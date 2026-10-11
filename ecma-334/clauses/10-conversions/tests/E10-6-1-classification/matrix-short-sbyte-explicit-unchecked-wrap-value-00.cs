/*
Rules: E10-6-1-classification; E10-6-1-wrap
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
            short input = (short)(-32768);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-short-sbyte-explicit-unchecked-wrap-0");
        }
        {
            short input = (short)(32767);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-1), "nullable-short-sbyte-explicit-unchecked-wrap-1");
        }
        {
            short input = (short)(0);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(0), "nullable-short-sbyte-explicit-unchecked-wrap-2");
        }
        {
            short input = (short)(1);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(1), "nullable-short-sbyte-explicit-unchecked-wrap-3");
        }
        {
            short input = (short)(-1);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-1), "nullable-short-sbyte-explicit-unchecked-wrap-4");
        }
        {
            short input = (short)(-129);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(127), "nullable-short-sbyte-explicit-unchecked-wrap-5");
        }
        {
            short input = (short)(-128);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-128), "nullable-short-sbyte-explicit-unchecked-wrap-6");
        }
        {
            short input = (short)(-127);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-127), "nullable-short-sbyte-explicit-unchecked-wrap-7");
        }
        {
            short input = (short)(126);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(126), "nullable-short-sbyte-explicit-unchecked-wrap-8");
        }
        {
            short input = (short)(127);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(127), "nullable-short-sbyte-explicit-unchecked-wrap-9");
        }
        {
            short input = (short)(128);
            sbyte? result = unchecked((sbyte?)input);
            Check(result.HasValue && result.Value==(sbyte)(-128), "nullable-short-sbyte-explicit-unchecked-wrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
