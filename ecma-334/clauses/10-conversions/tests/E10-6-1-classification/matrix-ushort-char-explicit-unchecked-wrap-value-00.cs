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
            ushort input = (ushort)(0);
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-ushort-char-explicit-unchecked-wrap-0");
        }
        {
            ushort input = (ushort)(65535);
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-ushort-char-explicit-unchecked-wrap-1");
        }
        {
            ushort input = (ushort)(1);
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(1), "nullable-ushort-char-explicit-unchecked-wrap-2");
        }
        {
            ushort input = (ushort)(65534);
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(65534), "nullable-ushort-char-explicit-unchecked-wrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
