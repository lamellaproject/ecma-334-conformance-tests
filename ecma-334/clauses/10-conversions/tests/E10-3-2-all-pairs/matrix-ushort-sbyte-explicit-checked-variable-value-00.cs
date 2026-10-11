/*
Rules: E10-3-2-all-pairs; E10-3-2-ushort
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 4
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
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "ushort-sbyte-explicit-checked-variable-0");
        }
        {
            ushort input = (ushort)(1);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(1), "ushort-sbyte-explicit-checked-variable-2");
        }
        {
            ushort input = (ushort)(126);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(126), "ushort-sbyte-explicit-checked-variable-3");
        }
        {
            ushort input = (ushort)(127);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(127), "ushort-sbyte-explicit-checked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
