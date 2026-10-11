/*
Rules: E10-3-2-all-pairs; E10-3-2-int
Authority: ECMA-334 7th ed 10.3.2
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
            int input = 0;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "int-sbyte-explicit-checked-variable-2");
        }
        {
            int input = 1;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(1), "int-sbyte-explicit-checked-variable-3");
        }
        {
            int input = -1;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-1), "int-sbyte-explicit-checked-variable-4");
        }
        {
            int input = -128;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-128), "int-sbyte-explicit-checked-variable-6");
        }
        {
            int input = -127;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-127), "int-sbyte-explicit-checked-variable-7");
        }
        {
            int input = 126;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(126), "int-sbyte-explicit-checked-variable-8");
        }
        {
            int input = 127;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(127), "int-sbyte-explicit-checked-variable-9");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
