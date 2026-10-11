/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 3
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
            sbyte? input = (sbyte)(127);
            byte result = checked((byte)input);
            Check(result==(byte)(127), "nullable-sbyte-byte-explicit-checked-unwrap-1");
        }
        {
            sbyte? input = (sbyte)(0);
            byte result = checked((byte)input);
            Check(result==(byte)(0), "nullable-sbyte-byte-explicit-checked-unwrap-2");
        }
        {
            sbyte? input = (sbyte)(1);
            byte result = checked((byte)input);
            Check(result==(byte)(1), "nullable-sbyte-byte-explicit-checked-unwrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
