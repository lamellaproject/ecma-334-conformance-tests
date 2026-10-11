/*
Rules: E10-3-2-all-pairs; E10-3-2-uint; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 6
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
            const uint input = 0U;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "uint-sbyte-explicit-unchecked-constant-0");
        }
        {
            const uint input = 4294967295U;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "uint-sbyte-explicit-unchecked-constant-1");
        }
        {
            const uint input = 1U;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "uint-sbyte-explicit-unchecked-constant-2");
        }
        {
            const uint input = 126U;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "uint-sbyte-explicit-unchecked-constant-3");
        }
        {
            const uint input = 127U;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "uint-sbyte-explicit-unchecked-constant-4");
        }
        {
            const uint input = 128U;
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "uint-sbyte-explicit-unchecked-constant-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
