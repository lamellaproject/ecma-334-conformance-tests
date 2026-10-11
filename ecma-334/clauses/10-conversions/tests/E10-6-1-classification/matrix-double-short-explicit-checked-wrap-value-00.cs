/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 12
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
            double input = 0.0d;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-double-short-explicit-checked-wrap-2");
        }
        {
            double input = -0.0d;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-double-short-explicit-checked-wrap-3");
        }
        {
            double input = 1.0d;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(1), "nullable-double-short-explicit-checked-wrap-4");
        }
        {
            double input = -1.0d;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(-1), "nullable-double-short-explicit-checked-wrap-5");
        }
        {
            double input = 0.75d;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-double-short-explicit-checked-wrap-6");
        }
        {
            double input = -0.75d;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-double-short-explicit-checked-wrap-7");
        }
        {
            double input = -32768.0d;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(-32768), "nullable-double-short-explicit-checked-wrap-12");
        }
        {
            double input = -32767.0d;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(-32767), "nullable-double-short-explicit-checked-wrap-13");
        }
        {
            double input = 32766.0d;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(32766), "nullable-double-short-explicit-checked-wrap-14");
        }
        {
            double input = 32767.0d;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(32767), "nullable-double-short-explicit-checked-wrap-15");
        }
        {
            double input = -32768.75d;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(-32768), "nullable-double-short-explicit-checked-wrap-17");
        }
        {
            double input = 32767.75d;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(32767), "nullable-double-short-explicit-checked-wrap-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
