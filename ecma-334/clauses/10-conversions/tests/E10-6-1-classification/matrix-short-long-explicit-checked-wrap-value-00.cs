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
            short input = (short)(-32768);
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==-32768L, "nullable-short-long-explicit-checked-wrap-0");
        }
        {
            short input = (short)(32767);
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==32767L, "nullable-short-long-explicit-checked-wrap-1");
        }
        {
            short input = (short)(0);
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==0L, "nullable-short-long-explicit-checked-wrap-2");
        }
        {
            short input = (short)(1);
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==1L, "nullable-short-long-explicit-checked-wrap-3");
        }
        {
            short input = (short)(-1);
            long? result = checked((long?)input);
            Check(result.HasValue && result.Value==-1L, "nullable-short-long-explicit-checked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
