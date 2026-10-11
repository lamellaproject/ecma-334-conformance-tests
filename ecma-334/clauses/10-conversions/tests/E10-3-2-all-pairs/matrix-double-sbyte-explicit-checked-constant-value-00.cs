/*
Rules: E10-3-2-all-pairs; E10-3-2-double; E12-23-numeric
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
            const double input = 0.0d;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "double-sbyte-explicit-checked-constant-2");
        }
        {
            const double input = -0.0d;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "double-sbyte-explicit-checked-constant-3");
        }
        {
            const double input = 1.0d;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(1), "double-sbyte-explicit-checked-constant-4");
        }
        {
            const double input = -1.0d;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-1), "double-sbyte-explicit-checked-constant-5");
        }
        {
            const double input = 0.75d;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "double-sbyte-explicit-checked-constant-6");
        }
        {
            const double input = -0.75d;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "double-sbyte-explicit-checked-constant-7");
        }
        {
            const double input = -128.0d;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-128), "double-sbyte-explicit-checked-constant-12");
        }
        {
            const double input = -127.0d;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-127), "double-sbyte-explicit-checked-constant-13");
        }
        {
            const double input = 126.0d;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(126), "double-sbyte-explicit-checked-constant-14");
        }
        {
            const double input = 127.0d;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(127), "double-sbyte-explicit-checked-constant-15");
        }
        {
            const double input = -128.75d;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-128), "double-sbyte-explicit-checked-constant-17");
        }
        {
            const double input = 127.75d;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(127), "double-sbyte-explicit-checked-constant-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
