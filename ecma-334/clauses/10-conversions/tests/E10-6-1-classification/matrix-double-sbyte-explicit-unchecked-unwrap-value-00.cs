/*
Rules: E10-6-1-classification; E10-6-1-unwrap
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
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "nullable-double-sbyte-explicit-unchecked-unwrap-2");
        }
        {
            double? input = -0.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "nullable-double-sbyte-explicit-unchecked-unwrap-3");
        }
        {
            double? input = 1.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "nullable-double-sbyte-explicit-unchecked-unwrap-4");
        }
        {
            double? input = -1.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "nullable-double-sbyte-explicit-unchecked-unwrap-5");
        }
        {
            double? input = 0.75d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "nullable-double-sbyte-explicit-unchecked-unwrap-6");
        }
        {
            double? input = -0.75d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "nullable-double-sbyte-explicit-unchecked-unwrap-7");
        }
        {
            double? input = -128.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "nullable-double-sbyte-explicit-unchecked-unwrap-12");
        }
        {
            double? input = -127.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-127), "nullable-double-sbyte-explicit-unchecked-unwrap-13");
        }
        {
            double? input = 126.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "nullable-double-sbyte-explicit-unchecked-unwrap-14");
        }
        {
            double? input = 127.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "nullable-double-sbyte-explicit-unchecked-unwrap-15");
        }
        {
            double? input = -128.75d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "nullable-double-sbyte-explicit-unchecked-unwrap-17");
        }
        {
            double? input = 127.75d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "nullable-double-sbyte-explicit-unchecked-unwrap-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
