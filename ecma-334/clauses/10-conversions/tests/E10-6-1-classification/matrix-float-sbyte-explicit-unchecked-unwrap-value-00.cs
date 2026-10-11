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
            float? input = 0.0f;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "nullable-float-sbyte-explicit-unchecked-unwrap-2");
        }
        {
            float? input = -0.0f;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "nullable-float-sbyte-explicit-unchecked-unwrap-3");
        }
        {
            float? input = 1.0f;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "nullable-float-sbyte-explicit-unchecked-unwrap-4");
        }
        {
            float? input = -1.0f;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "nullable-float-sbyte-explicit-unchecked-unwrap-5");
        }
        {
            float? input = 0.75f;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "nullable-float-sbyte-explicit-unchecked-unwrap-6");
        }
        {
            float? input = -0.75f;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "nullable-float-sbyte-explicit-unchecked-unwrap-7");
        }
        {
            float? input = -128.0f;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "nullable-float-sbyte-explicit-unchecked-unwrap-12");
        }
        {
            float? input = -127.0f;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-127), "nullable-float-sbyte-explicit-unchecked-unwrap-13");
        }
        {
            float? input = 126.0f;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "nullable-float-sbyte-explicit-unchecked-unwrap-14");
        }
        {
            float? input = 127.0f;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "nullable-float-sbyte-explicit-unchecked-unwrap-15");
        }
        {
            float? input = -128.75f;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "nullable-float-sbyte-explicit-unchecked-unwrap-17");
        }
        {
            float? input = 127.75f;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "nullable-float-sbyte-explicit-unchecked-unwrap-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
