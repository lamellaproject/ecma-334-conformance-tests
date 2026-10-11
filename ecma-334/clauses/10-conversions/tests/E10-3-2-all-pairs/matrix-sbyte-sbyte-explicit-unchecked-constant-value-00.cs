/*
Rules: E10-3-2-all-pairs; E12-23-numeric
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
            const sbyte input = (sbyte)(-128);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "sbyte-sbyte-explicit-unchecked-constant-0");
        }
        {
            const sbyte input = (sbyte)(127);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "sbyte-sbyte-explicit-unchecked-constant-1");
        }
        {
            const sbyte input = (sbyte)(0);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "sbyte-sbyte-explicit-unchecked-constant-2");
        }
        {
            const sbyte input = (sbyte)(1);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "sbyte-sbyte-explicit-unchecked-constant-3");
        }
        {
            const sbyte input = (sbyte)(-1);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "sbyte-sbyte-explicit-unchecked-constant-4");
        }
        {
            const sbyte input = (sbyte)(-127);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-127), "sbyte-sbyte-explicit-unchecked-constant-5");
        }
        {
            const sbyte input = (sbyte)(126);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "sbyte-sbyte-explicit-unchecked-constant-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
