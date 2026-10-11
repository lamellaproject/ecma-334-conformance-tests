/*
Rules: E10-3-2-all-pairs
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
            sbyte input = (sbyte)(-128);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "sbyte-sbyte-explicit-unchecked-variable-0");
        }
        {
            sbyte input = (sbyte)(127);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "sbyte-sbyte-explicit-unchecked-variable-1");
        }
        {
            sbyte input = (sbyte)(0);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "sbyte-sbyte-explicit-unchecked-variable-2");
        }
        {
            sbyte input = (sbyte)(1);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "sbyte-sbyte-explicit-unchecked-variable-3");
        }
        {
            sbyte input = (sbyte)(-1);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "sbyte-sbyte-explicit-unchecked-variable-4");
        }
        {
            sbyte input = (sbyte)(-127);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-127), "sbyte-sbyte-explicit-unchecked-variable-5");
        }
        {
            sbyte input = (sbyte)(126);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "sbyte-sbyte-explicit-unchecked-variable-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
