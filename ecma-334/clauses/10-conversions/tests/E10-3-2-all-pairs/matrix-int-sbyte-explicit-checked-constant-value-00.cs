/*
Rules: E10-3-2-all-pairs; E10-3-2-int; E12-23-numeric
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
            const int input = 0;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "int-sbyte-explicit-checked-constant-2");
        }
        {
            const int input = 1;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(1), "int-sbyte-explicit-checked-constant-3");
        }
        {
            const int input = -1;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-1), "int-sbyte-explicit-checked-constant-4");
        }
        {
            const int input = -128;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-128), "int-sbyte-explicit-checked-constant-6");
        }
        {
            const int input = -127;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-127), "int-sbyte-explicit-checked-constant-7");
        }
        {
            const int input = 126;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(126), "int-sbyte-explicit-checked-constant-8");
        }
        {
            const int input = 127;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(127), "int-sbyte-explicit-checked-constant-9");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
