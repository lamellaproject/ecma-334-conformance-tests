/*
Rules: E10-3-2-all-pairs; E10-3-2-byte
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
            byte input = (byte)(0);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "byte-sbyte-explicit-unchecked-variable-0");
        }
        {
            byte input = (byte)(255);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "byte-sbyte-explicit-unchecked-variable-1");
        }
        {
            byte input = (byte)(1);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "byte-sbyte-explicit-unchecked-variable-2");
        }
        {
            byte input = (byte)(126);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "byte-sbyte-explicit-unchecked-variable-3");
        }
        {
            byte input = (byte)(127);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "byte-sbyte-explicit-unchecked-variable-4");
        }
        {
            byte input = (byte)(128);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "byte-sbyte-explicit-unchecked-variable-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
