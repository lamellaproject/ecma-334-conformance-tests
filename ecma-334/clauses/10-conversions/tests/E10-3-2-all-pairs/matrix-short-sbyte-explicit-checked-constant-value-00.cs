/*
Rules: E10-3-2-all-pairs; E10-3-2-short; E12-23-numeric
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
            const short input = (short)(0);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "short-sbyte-explicit-checked-constant-2");
        }
        {
            const short input = (short)(1);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(1), "short-sbyte-explicit-checked-constant-3");
        }
        {
            const short input = (short)(-1);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-1), "short-sbyte-explicit-checked-constant-4");
        }
        {
            const short input = (short)(-128);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-128), "short-sbyte-explicit-checked-constant-6");
        }
        {
            const short input = (short)(-127);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-127), "short-sbyte-explicit-checked-constant-7");
        }
        {
            const short input = (short)(126);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(126), "short-sbyte-explicit-checked-constant-8");
        }
        {
            const short input = (short)(127);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(127), "short-sbyte-explicit-checked-constant-9");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
