/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
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
            int input = 0;
            byte? result = checked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-int-byte-explicit-checked-wrap-2");
        }
        {
            int input = 1;
            byte? result = checked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(1), "nullable-int-byte-explicit-checked-wrap-3");
        }
        {
            int input = 254;
            byte? result = checked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(254), "nullable-int-byte-explicit-checked-wrap-5");
        }
        {
            int input = 255;
            byte? result = checked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(255), "nullable-int-byte-explicit-checked-wrap-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
