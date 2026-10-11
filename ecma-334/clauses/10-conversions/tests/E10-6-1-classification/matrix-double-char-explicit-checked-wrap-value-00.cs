/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 8
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
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-double-char-explicit-checked-wrap-2");
        }
        {
            double input = -0.0d;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-double-char-explicit-checked-wrap-3");
        }
        {
            double input = 1.0d;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(1), "nullable-double-char-explicit-checked-wrap-4");
        }
        {
            double input = 0.75d;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-double-char-explicit-checked-wrap-6");
        }
        {
            double input = -0.75d;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-double-char-explicit-checked-wrap-7");
        }
        {
            double input = 65534.0d;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(65534), "nullable-double-char-explicit-checked-wrap-11");
        }
        {
            double input = 65535.0d;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-double-char-explicit-checked-wrap-12");
        }
        {
            double input = 65535.75d;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-double-char-explicit-checked-wrap-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
