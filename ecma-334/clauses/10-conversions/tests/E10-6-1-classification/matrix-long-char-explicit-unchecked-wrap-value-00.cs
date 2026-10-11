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
            long input = long.MinValue;
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-long-char-explicit-unchecked-wrap-0");
        }
        {
            long input = 9223372036854775807L;
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-long-char-explicit-unchecked-wrap-1");
        }
        {
            long input = 0L;
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-long-char-explicit-unchecked-wrap-2");
        }
        {
            long input = 1L;
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(1), "nullable-long-char-explicit-unchecked-wrap-3");
        }
        {
            long input = -1L;
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-long-char-explicit-unchecked-wrap-4");
        }
        {
            long input = 65534L;
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(65534), "nullable-long-char-explicit-unchecked-wrap-5");
        }
        {
            long input = 65535L;
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-long-char-explicit-unchecked-wrap-6");
        }
        {
            long input = 65536L;
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-long-char-explicit-unchecked-wrap-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
