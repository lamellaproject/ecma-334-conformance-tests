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
            char input = (char)(0);
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-char-short-explicit-checked-wrap-0");
        }
        {
            char input = (char)(1);
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(1), "nullable-char-short-explicit-checked-wrap-2");
        }
        {
            char input = (char)(32766);
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(32766), "nullable-char-short-explicit-checked-wrap-3");
        }
        {
            char input = (char)(32767);
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(32767), "nullable-char-short-explicit-checked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
