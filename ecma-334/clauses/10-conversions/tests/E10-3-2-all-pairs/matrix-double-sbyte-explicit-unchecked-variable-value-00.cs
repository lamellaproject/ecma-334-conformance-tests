/*
Rules: E10-3-2-all-pairs; E10-3-2-double
Authority: ECMA-334 7th ed 10.3.2
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
            double input = 0.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "double-sbyte-explicit-unchecked-variable-2");
        }
        {
            double input = -0.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "double-sbyte-explicit-unchecked-variable-3");
        }
        {
            double input = 1.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "double-sbyte-explicit-unchecked-variable-4");
        }
        {
            double input = -1.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "double-sbyte-explicit-unchecked-variable-5");
        }
        {
            double input = 0.75d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "double-sbyte-explicit-unchecked-variable-6");
        }
        {
            double input = -0.75d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "double-sbyte-explicit-unchecked-variable-7");
        }
        {
            double input = -128.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "double-sbyte-explicit-unchecked-variable-12");
        }
        {
            double input = -127.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-127), "double-sbyte-explicit-unchecked-variable-13");
        }
        {
            double input = 126.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "double-sbyte-explicit-unchecked-variable-14");
        }
        {
            double input = 127.0d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "double-sbyte-explicit-unchecked-variable-15");
        }
        {
            double input = -128.75d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "double-sbyte-explicit-unchecked-variable-17");
        }
        {
            double input = 127.75d;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "double-sbyte-explicit-unchecked-variable-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
