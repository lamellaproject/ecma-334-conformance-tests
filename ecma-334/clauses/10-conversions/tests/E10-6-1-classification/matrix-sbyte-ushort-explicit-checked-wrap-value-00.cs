/*
Rules: E10-6-1-classification; E10-6-1-wrap
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
            sbyte input = (sbyte)(127);
            ushort? result = checked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(127), "nullable-sbyte-ushort-explicit-checked-wrap-1");
        }
        {
            sbyte input = (sbyte)(0);
            ushort? result = checked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(0), "nullable-sbyte-ushort-explicit-checked-wrap-2");
        }
        {
            sbyte input = (sbyte)(1);
            ushort? result = checked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(1), "nullable-sbyte-ushort-explicit-checked-wrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
