/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 10
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
            decimal input = 0m;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-decimal-char-explicit-checked-wrap-2");
        }
        {
            decimal input = 1m;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(1), "nullable-decimal-char-explicit-checked-wrap-3");
        }
        {
            decimal input = 0.1m;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-decimal-char-explicit-checked-wrap-5");
        }
        {
            decimal input = -0.1m;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-decimal-char-explicit-checked-wrap-6");
        }
        {
            decimal input = 1E-28m;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-decimal-char-explicit-checked-wrap-7");
        }
        {
            decimal input = -1E-28m;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-decimal-char-explicit-checked-wrap-8");
        }
        {
            decimal input = 65534m;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(65534), "nullable-decimal-char-explicit-checked-wrap-9");
        }
        {
            decimal input = 65535m;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-decimal-char-explicit-checked-wrap-10");
        }
        {
            decimal input = -0.75m;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-decimal-char-explicit-checked-wrap-12");
        }
        {
            decimal input = 65535.75m;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-decimal-char-explicit-checked-wrap-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
