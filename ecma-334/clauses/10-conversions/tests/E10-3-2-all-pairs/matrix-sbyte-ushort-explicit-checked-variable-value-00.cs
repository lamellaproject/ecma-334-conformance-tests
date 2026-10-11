/*
Rules: E10-3-2-all-pairs; E10-3-2-sbyte
Authority: ECMA-334 7th ed 10.3.2
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
            sbyte input = (sbyte)(127);
            ushort result = checked((ushort)input);
            Check(result==(ushort)(127), "sbyte-ushort-explicit-checked-variable-1");
        }
        {
            sbyte input = (sbyte)(0);
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "sbyte-ushort-explicit-checked-variable-2");
        }
        {
            sbyte input = (sbyte)(1);
            ushort result = checked((ushort)input);
            Check(result==(ushort)(1), "sbyte-ushort-explicit-checked-variable-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
