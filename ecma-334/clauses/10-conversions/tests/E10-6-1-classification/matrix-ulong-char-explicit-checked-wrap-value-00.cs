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
            ulong input = 0UL;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-ulong-char-explicit-checked-wrap-0");
        }
        {
            ulong input = 1UL;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(1), "nullable-ulong-char-explicit-checked-wrap-2");
        }
        {
            ulong input = 65534UL;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(65534), "nullable-ulong-char-explicit-checked-wrap-3");
        }
        {
            ulong input = 65535UL;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-ulong-char-explicit-checked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
