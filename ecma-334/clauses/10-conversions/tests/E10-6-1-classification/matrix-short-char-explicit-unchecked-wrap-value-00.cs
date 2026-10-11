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
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(32768), "nullable-short-char-explicit-unchecked-wrap-0");
        }
        {
            short input = (short)(32767);
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(32767), "nullable-short-char-explicit-unchecked-wrap-1");
        }
        {
            short input = (short)(0);
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-short-char-explicit-unchecked-wrap-2");
        }
        {
            short input = (short)(1);
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(1), "nullable-short-char-explicit-unchecked-wrap-3");
        }
        {
            short input = (short)(-1);
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-short-char-explicit-unchecked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
