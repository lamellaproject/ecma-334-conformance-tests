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
            byte input = (byte)(0);
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-byte-long-explicit-checked-wrap-0");
        }
        {
            byte input = (byte)(255);
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==255L, "nullable-byte-long-explicit-checked-wrap-1");
        }
        {
            byte input = (byte)(1);
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==1L, "nullable-byte-long-explicit-checked-wrap-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
