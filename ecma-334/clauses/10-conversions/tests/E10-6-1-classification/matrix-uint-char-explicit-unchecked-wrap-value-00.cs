/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 6
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
            uint input = 0U;
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-uint-char-explicit-unchecked-wrap-0");
        }
        {
            uint input = 4294967295U;
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-uint-char-explicit-unchecked-wrap-1");
        }
        {
            uint input = 1U;
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(1), "nullable-uint-char-explicit-unchecked-wrap-2");
        }
        {
            uint input = 65534U;
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(65534), "nullable-uint-char-explicit-unchecked-wrap-3");
        }
        {
            uint input = 65535U;
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-uint-char-explicit-unchecked-wrap-4");
        }
        {
            uint input = 65536U;
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-uint-char-explicit-unchecked-wrap-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
