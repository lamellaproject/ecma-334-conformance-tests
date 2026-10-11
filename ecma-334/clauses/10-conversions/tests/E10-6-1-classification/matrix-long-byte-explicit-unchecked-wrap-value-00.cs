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
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-long-byte-explicit-unchecked-wrap-0");
        }
        {
            long input = 9223372036854775807L;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(255), "nullable-long-byte-explicit-unchecked-wrap-1");
        }
        {
            long input = 0L;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-long-byte-explicit-unchecked-wrap-2");
        }
        {
            long input = 1L;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(1), "nullable-long-byte-explicit-unchecked-wrap-3");
        }
        {
            long input = -1L;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(255), "nullable-long-byte-explicit-unchecked-wrap-4");
        }
        {
            long input = 254L;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(254), "nullable-long-byte-explicit-unchecked-wrap-5");
        }
        {
            long input = 255L;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(255), "nullable-long-byte-explicit-unchecked-wrap-6");
        }
        {
            long input = 256L;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-long-byte-explicit-unchecked-wrap-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
