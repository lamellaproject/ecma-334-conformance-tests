/*
Rules: E10-3-2-all-pairs; E10-3-2-long; E12-23-numeric
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
            const long input = 0L;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "long-sbyte-explicit-checked-constant-2");
        }
        {
            const long input = 1L;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(1), "long-sbyte-explicit-checked-constant-3");
        }
        {
            const long input = -1L;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-1), "long-sbyte-explicit-checked-constant-4");
        }
        {
            const long input = -128L;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-128), "long-sbyte-explicit-checked-constant-6");
        }
        {
            const long input = -127L;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-127), "long-sbyte-explicit-checked-constant-7");
        }
        {
            const long input = 126L;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(126), "long-sbyte-explicit-checked-constant-8");
        }
        {
            const long input = 127L;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(127), "long-sbyte-explicit-checked-constant-9");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
