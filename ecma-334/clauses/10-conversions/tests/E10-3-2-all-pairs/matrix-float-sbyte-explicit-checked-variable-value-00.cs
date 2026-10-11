/*
Rules: E10-3-2-all-pairs; E10-3-2-float
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
            float input = 0.0f;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "float-sbyte-explicit-checked-variable-2");
        }
        {
            float input = -0.0f;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "float-sbyte-explicit-checked-variable-3");
        }
        {
            float input = 1.0f;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(1), "float-sbyte-explicit-checked-variable-4");
        }
        {
            float input = -1.0f;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-1), "float-sbyte-explicit-checked-variable-5");
        }
        {
            float input = 0.75f;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "float-sbyte-explicit-checked-variable-6");
        }
        {
            float input = -0.75f;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "float-sbyte-explicit-checked-variable-7");
        }
        {
            float input = -128.0f;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-128), "float-sbyte-explicit-checked-variable-12");
        }
        {
            float input = -127.0f;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-127), "float-sbyte-explicit-checked-variable-13");
        }
        {
            float input = 126.0f;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(126), "float-sbyte-explicit-checked-variable-14");
        }
        {
            float input = 127.0f;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(127), "float-sbyte-explicit-checked-variable-15");
        }
        {
            float input = -128.75f;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-128), "float-sbyte-explicit-checked-variable-17");
        }
        {
            float input = 127.75f;
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(127), "float-sbyte-explicit-checked-variable-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
