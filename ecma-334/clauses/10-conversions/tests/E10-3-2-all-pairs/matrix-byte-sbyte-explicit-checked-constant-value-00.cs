/*
Rules: E10-3-2-all-pairs; E10-3-2-byte; E12-23-numeric
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
            const byte input = (byte)(0);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "byte-sbyte-explicit-checked-constant-0");
        }
        {
            const byte input = (byte)(1);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(1), "byte-sbyte-explicit-checked-constant-2");
        }
        {
            const byte input = (byte)(126);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(126), "byte-sbyte-explicit-checked-constant-3");
        }
        {
            const byte input = (byte)(127);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(127), "byte-sbyte-explicit-checked-constant-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
