/*
Rules: E10-3-2-all-pairs; E10-3-2-int
Authority: ECMA-334 7th ed 10.3.2
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
            int input = -2147483648;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "int-sbyte-explicit-unchecked-variable-0");
        }
        {
            int input = 2147483647;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "int-sbyte-explicit-unchecked-variable-1");
        }
        {
            int input = 0;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "int-sbyte-explicit-unchecked-variable-2");
        }
        {
            int input = 1;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "int-sbyte-explicit-unchecked-variable-3");
        }
        {
            int input = -1;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "int-sbyte-explicit-unchecked-variable-4");
        }
        {
            int input = -129;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "int-sbyte-explicit-unchecked-variable-5");
        }
        {
            int input = -128;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "int-sbyte-explicit-unchecked-variable-6");
        }
        {
            int input = -127;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-127), "int-sbyte-explicit-unchecked-variable-7");
        }
        {
            int input = 126;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "int-sbyte-explicit-unchecked-variable-8");
        }
        {
            int input = 127;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "int-sbyte-explicit-unchecked-variable-9");
        }
        {
            int input = 128;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "int-sbyte-explicit-unchecked-variable-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
