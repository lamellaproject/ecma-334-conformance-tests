/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 5
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
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(128), "nullable-sbyte-byte-explicit-unchecked-wrap-0");
        }
        {
            sbyte input = (sbyte)(127);
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(127), "nullable-sbyte-byte-explicit-unchecked-wrap-1");
        }
        {
            sbyte input = (sbyte)(0);
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-sbyte-byte-explicit-unchecked-wrap-2");
        }
        {
            sbyte input = (sbyte)(1);
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(1), "nullable-sbyte-byte-explicit-unchecked-wrap-3");
        }
        {
            sbyte input = (sbyte)(-1);
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(255), "nullable-sbyte-byte-explicit-unchecked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
