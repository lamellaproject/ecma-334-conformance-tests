/*
Rules: E10-6-1-classification; E10-6-1-unwrap
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
            short? input = (short)(0);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "nullable-short-sbyte-explicit-checked-unwrap-2");
        }
        {
            short? input = (short)(1);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(1), "nullable-short-sbyte-explicit-checked-unwrap-3");
        }
        {
            short? input = (short)(-1);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-1), "nullable-short-sbyte-explicit-checked-unwrap-4");
        }
        {
            short? input = (short)(-128);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-128), "nullable-short-sbyte-explicit-checked-unwrap-6");
        }
        {
            short? input = (short)(-127);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-127), "nullable-short-sbyte-explicit-checked-unwrap-7");
        }
        {
            short? input = (short)(126);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(126), "nullable-short-sbyte-explicit-checked-unwrap-8");
        }
        {
            short? input = (short)(127);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(127), "nullable-short-sbyte-explicit-checked-unwrap-9");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
