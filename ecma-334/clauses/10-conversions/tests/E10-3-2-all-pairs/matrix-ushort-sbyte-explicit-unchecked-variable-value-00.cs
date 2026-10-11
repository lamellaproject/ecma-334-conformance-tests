/*
Rules: E10-3-2-all-pairs; E10-3-2-ushort
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
            ushort input = (ushort)(0);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "ushort-sbyte-explicit-unchecked-variable-0");
        }
        {
            ushort input = (ushort)(65535);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "ushort-sbyte-explicit-unchecked-variable-1");
        }
        {
            ushort input = (ushort)(1);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "ushort-sbyte-explicit-unchecked-variable-2");
        }
        {
            ushort input = (ushort)(126);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "ushort-sbyte-explicit-unchecked-variable-3");
        }
        {
            ushort input = (ushort)(127);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "ushort-sbyte-explicit-unchecked-variable-4");
        }
        {
            ushort input = (ushort)(128);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "ushort-sbyte-explicit-unchecked-variable-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
